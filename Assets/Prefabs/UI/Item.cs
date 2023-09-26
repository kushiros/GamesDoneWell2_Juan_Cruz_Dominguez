using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Color colorToChange = Color.black;
    [SerializeField] float price = 100;
    [SerializeField] TMPro.TMP_Text priceText;



    public void ClickToBuy()
    {
        shopManager.instance.shopItem(this);
    }
    public float GetPrice()
    {
        return price;
    }
    public Color GetColor()
    {
        return colorToChange;
    }
}
