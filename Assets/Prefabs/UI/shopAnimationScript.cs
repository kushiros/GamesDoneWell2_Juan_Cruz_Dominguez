using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class shopAnimationScript : MonoBehaviour
{
    [SerializeField] float fadeTime = 1f;
    [SerializeField] CanvasGroup _ShopCanvasGroup;
    [SerializeField] RectTransform _ShopRectTransform;
    [SerializeField] GameObject itemsParent;
    [SerializeField] GameObject shop;




    public void PanelFadeIn()
    {
        _ShopCanvasGroup.alpha = 0f;
        _ShopRectTransform.transform.localPosition = new Vector3(0f, -500f, 0f);
        _ShopRectTransform.DOAnchorPos(new Vector2(0f,0f),fadeTime,false).SetEase(Ease.OutElastic);
        _ShopCanvasGroup.DOFade(1, fadeTime);
        StartCoroutine("ItemsAnimation");
    }

    public void PanelFadePut()
    {
        _ShopCanvasGroup.alpha = 1f;
        _ShopRectTransform.transform.localPosition = new Vector3(0f, 0, 0f);
        _ShopRectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
        _ShopCanvasGroup.DOFade(1, fadeTime).OnComplete(() => { 
            shop.SetActive(false);
            DOTween.ClearCachedTweens();
        });
        
    }

    IEnumerator ItemsAnimation()
    {
        for (int i = 0; i < itemsParent.transform.childCount; i++)
        {
            itemsParent.transform.GetChild(i).localScale = Vector3.zero;
        }
        for (int i = 0; i < itemsParent.transform.childCount; i++)
        {
            itemsParent.transform.GetChild(i).DOScale(1f,fadeTime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.25f);
        }
        DOTween.ClearCachedTweens();
    }
}

