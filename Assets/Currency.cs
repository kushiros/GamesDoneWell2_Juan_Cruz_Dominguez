using Minimalist.Bar.Quantity;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public static Currency instance;

    [SerializeField] public TMPro.TMP_Text _currencyText;
    float _totalCurrency = 0;


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
    public void setCurrency(float currency)
    {
        _totalCurrency += currency;
        _currencyText.text = _totalCurrency.ToString();
    }
}