using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class color : MonoBehaviour
{
    // Fade the color from red to green
    // back and forth over the defined duration

    [SerializeField] Color colorStart;
    [SerializeField] Color colorEnd;
    [SerializeField] GameObject[] colors;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        for(int i= 0; i < colors.Length; i++)
        {
            rend = colors[i].GetComponent<Renderer>();
            rend.material.color = colorStart;
        }
    }
    public void setColor(Color _sendColor)
    {
        rend.material.DOColor(_sendColor,0.5f);
        colors[0].GameObject().transform.DOFlip();

    }

}
