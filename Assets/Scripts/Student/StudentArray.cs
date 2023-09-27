using Minimalist.Bar.Quantity;
using Minimalist.Bar.UI;
using System;
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
    [SerializeField] QuantityBhv progressBar;
    bool cheaters;
    
    // Start is called before the first frame update

    private void Start()
    {
        progressBar = FindAnyObjectByType<QuantityBhv>();
        progressBar.FillAmount = complete;

    }
    // Update is called once per frame
    void Update()
    {
        
        if ((cheaters = allCheaters()) == false)
        {
            GameManager.instance.Win();
        }
        else if  ((getCompleteTotal() >= getToCompleteTotal()) && (cheaters != allCheaters()))
        {
            GameManager.instance.Win();

        }
        else if (allExamsComplete())
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
        progressBar.FillAmount = complete / toComplete;


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

    public bool allCheaters()
    {
        bool allCheaters = false;

        foreach (Student elemento in studentArray)
        {
            if (!elemento.getCheater())
            {
                allCheaters = true;
                break; // Sale del bucle tan pronto como encuentra un elemento falso.
            }
        }

        return allCheaters;
    }
    public bool allExamsComplete()
    {
        bool allComplete = true;

        foreach (Student elemento in studentArray)
        {
            if (!elemento.getExamComplete())
            {
                allComplete = false;
                break; // Sale del bucle tan pronto como encuentra un elemento falso.
            }
        }

        return allComplete;
    }
}
