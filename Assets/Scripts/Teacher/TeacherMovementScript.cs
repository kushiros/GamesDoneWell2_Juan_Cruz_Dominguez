using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class TeacherMovementScript : MonoBehaviour
{

    [SerializeField] PathPoints[] PathPoint;
    [SerializeField] Vector3[] PathPointPriority;
    [SerializeField] int TotalPriority; 
    // Start is called before the first frame update
    void Awake()
    {
        Vector3[] PathPointPriority = new Vector3[getTotalPositions()];
        getPositions();
        TotalPriotityCalculation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void getPositions()
    {
        for(int i = 0; i < PathPointPriority.Length; i++) {
            PathPointPriority[i] = PathPoint[i].getDestinyPath();
        }
        

    }
    private void TotalPriotityCalculation()
    {
        foreach (PathPoints element in PathPoint)
        {
            TotalPriority += element.getPriority();
        }
        
    }
    private int getTotalPositions()
    {
        int quantity = 0;
        foreach (PathPoints element in PathPoint)
        {
            quantity++;
        }
        return quantity;
    }
    
    public Vector3 getPosition(int position) {
        return PathPointPriority[position-1];
    }


}
