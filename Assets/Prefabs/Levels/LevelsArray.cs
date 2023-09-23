using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsArray : MonoBehaviour
{
    [SerializeField] GameObject[] myPrefabLevelArray;
    [SerializeField] private int actualLevel;
    [SerializeField] private int totalLevels;

    private void Start()
    {
        actualLevel = 0;
        setTotalLevels();
        Instantiate(myPrefabLevelArray[actualLevel], new Vector3(0, 0, 0), Quaternion.identity);
    }
    private void ChangeLevel()
    {

        Instantiate(myPrefabLevelArray[actualLevel], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(GameObject.FindGameObjectWithTag("Level"));

    }

    public void updateNextLevel()
    {
        actualLevel = (actualLevel+1) % totalLevels;
        ChangeLevel();
        


    }

    public void updateActualLevel()
    {
        ChangeLevel();
    }

    private void setTotalLevels()
    {
        totalLevels = myPrefabLevelArray.Length;
    }
}
