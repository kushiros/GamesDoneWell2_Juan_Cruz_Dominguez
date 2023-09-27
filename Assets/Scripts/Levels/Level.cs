using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    StudentArray array;

    // Start is called before the first frame update
    void Start()
    {
        array = GetComponentInChildren<StudentArray>();
        LevelManager.instance.SetStudentArray(array);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
