using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] StudentArray studentArray;
    [SerializeField] Shake shakeCamera;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void updateCheatingTotal(float addComplete)
    {
        studentArray.updateCompleteTotal(addComplete);
    }

    public void SetStudentArray(StudentArray studentArray)
    {
        this.studentArray = studentArray;
    }
    public void SetShakeCamera(Shake shakeCameraVariable)
    {
        this.shakeCamera = shakeCameraVariable;
    }
    public Shake GetShakeCamera()
    {
        return shakeCamera;
    }
}
