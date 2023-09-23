using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    [SerializeField] GameObject pathPoints;
    [SerializeField] GameObject teacher;

    [SerializeField] TeacherMovementScript points;

    int eventNumber;

    float timeSinceLastWait = 0f;  // Variable para rastrear el tiempo desde la �ltima espera
    bool waiting = false;  // Variable para indicar si est�s esperando
    int targetPositionIndex = -1;


    void Start()
    {
        points = pathPoints.GetComponent<TeacherMovementScript>();
        transport();
        Quaternion targetRotation = Quaternion.LookRotation(points.getPosition(2) - transform.position);
        transform.DORotateQuaternion(targetRotation, 0.0001f);

    }

    void Update()
    {
        if (!waiting)
        {
            if (teacher.transform.position == points.getPosition(1))
            {
                waiting = true;
                timeSinceLastWait = 0f;
                targetPositionIndex = 2;
            }
            else if (teacher.transform.position == points.getPosition(2))
            {
                waiting = true;
                timeSinceLastWait = 0f;
                targetPositionIndex = 1;
            }
        }
        else
        {
            timeSinceLastWait += Time.deltaTime;  

           
            if (timeSinceLastWait >= 2f)  
            {
               
                waiting = false; 
                timeSinceLastWait = 0f;


                _ = moveToX(targetPositionIndex);
            }
        }
    }

    async Task moveToX(int i)
    {
        if(waiting == false) {

            
            await transform.DOMove(points.getPosition(i), 3).AsyncWaitForCompletion();

            if (teacher.transform.position == points.getPosition(2))
            {
                Quaternion targetRotation = Quaternion.LookRotation(points.getPosition(i-1) - transform.position);
                transform.DORotateQuaternion(targetRotation, 0.5f);
            }

            else if (teacher.transform.position == points.getPosition(1)) {
                Quaternion targetRotation = Quaternion.LookRotation(points.getPosition(i+1) - transform.position);
                transform.DORotateQuaternion(targetRotation, 0.5f);
            }


            await awaitXSeconds();
        }
        

    }

    async Task awaitXSeconds()
    {
        float waitTime = Random.Range(4f, 5f);
        

        await Task.Delay((int)(waitTime * 1000)); // Delay in milliseconds

        
    }

    void transport()
    {
        Vector3 position = points.getPosition(1);
        teacher.transform.position = position;
    }


    int randomEvent(int i)
    {
        int number = 0;
        if (i == 1)
            number = 2;
        else if (i == 2)
            number = 1;
        return number;
    }
}
