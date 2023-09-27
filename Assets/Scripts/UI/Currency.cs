using DG.Tweening;
using Minimalist.Bar.Quantity;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public static Currency instance;


    [SerializeField]float _totalCurrency = 0;

    [SerializeField] GameObject pileOfCoinParent;

    [SerializeField] Vector3[] initialPos;

    [SerializeField] Quaternion[] initialRot;
    [SerializeField] int CoinNo;
    [SerializeField] TMPro.TMP_Text total;
    [SerializeField] TMPro.TMP_Text gained;

    private void Awake()
    {
        if (instance == null || instance == this)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        initialPos = new Vector3[CoinNo];
        initialRot = new Quaternion[CoinNo];
        for(int i = 0; i < pileOfCoinParent.transform.childCount; i++) {
            initialPos[i] = pileOfCoinParent.transform.GetChild(i).position;
            initialRot[i] = pileOfCoinParent.transform.GetChild(i).rotation;
        }
    }

    private void Reset()
    {
        {
            for (int i = 0; i < pileOfCoinParent.transform.childCount; i++)
            {
                pileOfCoinParent.transform.GetChild(i).position = initialPos[i];
                pileOfCoinParent.transform.GetChild(i).rotation = initialRot[i];
            }
        }
    }
    public void RewardPileOfCoin(int noCoin)
    {
        gained.text = $"you gained: {noCoin *10}";
        Reset();
        var delay = 0f;
        pileOfCoinParent.SetActive(true);

        for (int i = 0; i < noCoin; i++)
        {
            pileOfCoinParent.transform.GetChild(i).DOScale(1f,0.3f).SetDelay(delay).SetEase(Ease.OutBack);

            pileOfCoinParent.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector2(170f,600),0.5f).SetDelay(delay + 0.5f)
                .SetEase(Ease.OutBack);

            pileOfCoinParent.transform.GetChild(i).DORotate(Vector3.zero, 0.5f).SetDelay(delay + 0.5f).
                SetEase(Ease.Flash).OnComplete(CountCoinsByComplete);

           pileOfCoinParent.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(delay + 0.8f).SetEase(Ease.OutBack);

            delay += 0.1f;
        }
    }

    void CountCoinsByComplete()
    {
        _totalCurrency += 10;
        total.text = _totalCurrency.ToString();
    }
    public float getCurrency()
    {
        return _totalCurrency;
    }

    public void setCurrency(float addCurrency)
    {
        _totalCurrency += addCurrency ;
        total.text = _totalCurrency.ToString();
    }
}