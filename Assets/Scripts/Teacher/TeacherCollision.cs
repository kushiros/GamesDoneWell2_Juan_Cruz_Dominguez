using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;

public class TeacherCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject studentGameObject;
    [SerializeField] Student[] students;

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
            Student student = collision.gameObject.GetComponent<Student>();
            if (student.getCheating()) {
                student.setCheaterTrue();
                
            }
        }
    }


}
    



