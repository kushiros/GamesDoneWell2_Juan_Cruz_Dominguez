using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsArray : MonoBehaviour
{
    [SerializeField] GameObject[] myPrefabLevelArray;
    [SerializeField] GameObject level0;   
    [SerializeField] private int actualLevel;
    [SerializeField] private int totalLevels;
    [SerializeField] private int actualLevelUI;
    [SerializeField] private TMPro.TMP_Text LevelUIText;

    private void Start()
    {
        actualLevel = 0;
        actualLevelUI = 1;
        LevelUIText.text = actualLevelUI.ToString();
        setTotalLevels();
        Instantiate(level0, new Vector3(0, 0, 0), Quaternion.identity);
    }
    private void ChangeLevel()
    {

        Instantiate(myPrefabLevelArray[actualLevel], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(GameObject.FindGameObjectWithTag("Level"));

    }

    public void updateNextLevel()
    {

        actualLevel = (actualLevel+1) % totalLevels;
        actualLevelUI = actualLevelUI + 1;
        LevelUIText.text = actualLevelUI.ToString();
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
