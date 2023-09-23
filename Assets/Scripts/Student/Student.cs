using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Student : MonoBehaviour
{
    float complete = 0;
    [SerializeField]float toComplete = 1;
    float cheatingInterval = 0.5f;
    [SerializeField] bool cheating = false;


    // Update is called once per frame



    IEnumerator Cheating()
    {
        if (complete >= toComplete)
        {
            
            yield break;
        }
        yield return new WaitForSeconds(cheatingInterval);
        if (complete < toComplete)
        {
            complete += cheatingInterval;
            LevelManager.instance.GetShakeCamera().doShakeCamera();
            LevelManager.instance.updateCheatingTotal(cheatingInterval);
            Debug.Log(complete);
            StartCoroutine(Cheating());

        }
    }

    private void OnMouseDown()
    {
        StartCoroutine("Cheating");
        cheating = true;
        
    }
    private void OnMouseUp()
    {
        StopAllCoroutines();
        cheating = false;
        
    }

    public bool getCheating() { return cheating; }


    public float getToCompleteTotal()
    {
        return toComplete;
    }
    public float getCompleteTotal()
    {
        return complete;
    }
}
