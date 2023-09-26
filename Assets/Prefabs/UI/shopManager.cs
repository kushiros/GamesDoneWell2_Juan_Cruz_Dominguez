using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopManager : MonoBehaviour

{
    public static shopManager instance;
    [SerializeField] GameObject[] shopItems;
    [SerializeField] float totalCurrency;
    GameObject  myStudentPrefab; GameObject instanciaPrefab;    // Start is called before the first frame update
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

    public void shopItem(Item item)
    {
        totalCurrency = Currency.instance.getCurrency();
        if(item.GetPrice() <= totalCurrency)
        {
            Currency.instance.setCurrency(-item.GetPrice());

        }
    }
}
