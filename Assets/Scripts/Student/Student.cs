using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using RengeGames.HealthBars;
using Unity.VisualScripting;

public class Student : MonoBehaviour
{
    float complete = 0;
    [SerializeField]float toComplete = 1;
    float cheatingInterval = 0.5f;
    [SerializeField] bool cheating = false;
    [SerializeField] RadialSegmentedHealthBar graficalComplete;


    // Update is called once per frame

    private void Start()
    {
        setToCompleteGraphic();
    }

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
            setCompleteGraphic();
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
    public void setToCompleteGraphic()
    {
        graficalComplete.SetRemovedSegments(getToCompleteTotal());
        graficalComplete.SetSegmentCount(getToCompleteTotal());
    }
    public void setCompleteGraphic()
    {
        graficalComplete.SetRemovedSegments(getToCompleteTotal()-getCompleteTotal());
    }
}
