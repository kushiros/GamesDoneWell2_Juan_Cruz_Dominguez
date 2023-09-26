using DG.Tweening;
using Minimalist.Bar.Quantity;

using UnityEngine;
using UnityEngine.UIElements;

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
    Vector3 backgroundScale;


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
        backgroundScale = winBackground.transform.localScale;

    }
    // Start is called before the first frame update
    


    public void Win()
    {
        if (!winBool)
        {

            
            winBackground.SetActive(true);
            win.SetActive(true);
            
            winBackground.transform.localScale = Vector3.zero;
            int _coins = (int)Mathf.Floor(progressPercent / 10);
            winBackground.transform.DOScale(backgroundScale, 0.3f).SetEase(Ease.OutBounce).OnComplete(() => {
                DOTween.ClearCachedTweens();
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
                Currency.instance.RewardPileOfCoin(_coins); }) ;
           
            

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
