using DG.Tweening;
using Minimalist.Bar.Quantity;
using RengeGames.HealthBars.Extensions;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [SerializeField] GameObject winBackground;
    [SerializeField] GameObject win;
    [SerializeField] public TMPro.TMP_Text textProgress;
    Color color;
    [SerializeField] public QuantityBhv Progress;
    float progressPercent;
    private LevelsArray levelsArray;
    public bool winBool =false ;


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
        if (!winBool)
        {
            winBool = true;
            progressPercent = Progress.Amount;
            if (progressPercent >= 80f)
            {
                win.GetComponent<BouncingStars>().ThreeStars();
            }
            else if (progressPercent >= 60f)
            {
                win.GetComponent<BouncingStars>().TwoStars();
            }
            else if (progressPercent >= 40)
            {
                win.GetComponent<BouncingStars>().OneStar();
            }
            else
            {



            }
            Currency.instance.setCurrency(progressPercent);
            winBackground.SetActive(true);
            win.SetActive(true);
        }
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
    public void changeBoolToFalse()
    {
        winBool = false;
    }

}
