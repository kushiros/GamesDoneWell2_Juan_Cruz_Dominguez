using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shake : MonoBehaviour

{
    public AnimationCurve curve;
    public float shakeDuration =1;
    public float shakeStrength = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doShakeCamera()
    {
            Camera.main.DOShakePosition(shakeDuration, shakeStrength, fadeOut: true);
      
    }
}
