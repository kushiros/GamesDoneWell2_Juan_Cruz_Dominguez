using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bounce : MonoBehaviour

{
    public AnimationCurve curve;
    public Vector3 _scaleTo;
    public Vector3 _originalScale;
    // Start is called before the first frame update
    void Start()
    {
        _originalScale = transform.localScale;
        _scaleTo = _originalScale *1.2f;
        transform.DOScale(_scaleTo,0.7f)
            .SetEase(Ease.InOutFlash)
            .SetLoops(-1,LoopType.Yoyo);
    }

    // Update is called once per frame

}