using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;

public class TeacherCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject studentGameObject;
    [SerializeField] Student[] students;

    [SerializeField] bool cheating = false;
    [SerializeField] bool teacherCheating;
    void Start()
    {
        int i = 0;
        foreach(var _studentGameObject in studentGameObject.GetComponents<Student>())
        {
            students[i] = _studentGameObject;
            i++;
        }
        
    }


    private void Update()
    {
        

    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Student"))
        {
            if(collision.gameObject.GetComponent<Student>().getCheating()) { GameManager.instance.Lose();  }
        }
    }


}
    



