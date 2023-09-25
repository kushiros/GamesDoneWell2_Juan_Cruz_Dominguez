using Minimalist.Bar.Quantity;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public static Currency instance;

    [SerializeField] public TMPro.TMP_Text _currencyText;
    [SerializeField] public TMPro.TMP_Text _winCurrencyText;
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
        _winCurrencyText.text = $"You Won: " +
            $"{currency.ToString()}";


        _currencyText.text = _totalCurrency.ToString();
    }
}