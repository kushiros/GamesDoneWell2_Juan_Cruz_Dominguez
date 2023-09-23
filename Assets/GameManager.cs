using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [SerializeField] GameObject lose;
    [SerializeField] GameObject win;
    private LevelsArray levelsArray;


    private void Awake()
    {
            if (instance == null || instance == this)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            levelsArray = GetComponent<LevelsArray>();
            }
            else
            {
            Destroy(gameObject);
        }

        }
    // Start is called before the first frame update
    

    public void Win()
    {
        win?.SetActive(true);
    }
    public void Lose()
    {
        lose?.SetActive(true);
    }

    public void resetScene()
    {
        DOTween.KillAll();
        levelsArray.updateActualLevel();
        
    }

    public void changeLevel()
    { 
        levelsArray.updateNextLevel();
    }


}
