using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StudentArray : MonoBehaviour

{ 
    public static StudentArray studentArrayInstance;
    private void Awake()
    {

        arrayPosition = 0;
        Student[] studentArray = new Student[getTotalPositions()];
        setToCompleteTotal();

    }
    [SerializeField] Student[] studentArray;
    private int arrayPosition;
    [SerializeField] float complete = 0;
    [SerializeField] float toComplete;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (getCompleteTotal() >= getToCompleteTotal())
        {
            GameManager.instance.Win();
            
        }
    }


    private int getTotalPositions()
    {
        int quantity = 0;
        foreach (Student student in studentArray)
        {
            quantity++;
        }
        return quantity;
    }
    public void updateCompleteTotal(float addComplete)
    {
        complete += addComplete;     
        
    }

    public void setToCompleteTotal()
    {
        
        foreach (Student student in studentArray)
        {
            toComplete += student.getToCompleteTotal();
        }
    }

    public float getToCompleteTotal()
    {
        return toComplete;
    }

    public float getCompleteTotal()
    {
        return complete;
    }

    public void setStudentOnArray(Student student)
    {
        studentArray[arrayPosition] = student;
    }
}
