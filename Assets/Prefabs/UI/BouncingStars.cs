using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingStars : MonoBehaviour
{
    [SerializeField] private Transform[] _shapes = new Transform[3];
    [SerializeField] int stars=0;



    // Update is called once per frame

    public void OneStar()
    {
        _shapes[0].DOScale(new Vector3(40, 40, 40), 0.5f).SetEase(Ease.OutBounce);
        DOTween.ClearCachedTweens();
    }

    public void TwoStars()
    {
        _shapes[0].DOScale(new Vector3(40, 40, 40), 0.5f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            _shapes[1].DOScale(new Vector3(40, 40, 40), 0.5f).SetEase(Ease.OutBounce);
        });
        DOTween.ClearCachedTweens();
    }
    public void ThreeStars()
    {
        _shapes[0].DOScale(new Vector3(40, 40, 40), 0.5f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            _shapes[1].DOScale(new Vector3(40, 40, 40), 0.5f).SetEase(Ease.OutBounce).OnComplete(() =>
            {
                _shapes[2].DOScale(new Vector3(40, 40, 40), 0.5f).SetEase(Ease.OutBounce);
            });
        });
        DOTween.ClearCachedTweens();
    }
    public void SetStar(int star)
    {
        stars = star; 

    }
    public void toZero()
    {
        foreach (Transform shape in _shapes)
        {
            shape.transform.DOScale(Vector3.zero,0.1f);
        }
    }
}
