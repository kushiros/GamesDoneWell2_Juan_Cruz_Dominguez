using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;

public class TeacherCollision : MonoBehaviour
{
    // Start is called before the first frame update

    Color collissionColor = new Color(178f/255f, 55f / 255f, 34f / 255f);


    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Student"))
        {
            Student student = collision.gameObject.GetComponent<Student>();
            if (student.getCheating()) {
                student.setCheaterTrue();
                student.GetComponentInParent<color>().setColor(collissionColor);
                
            }
        }
    }


}
    



