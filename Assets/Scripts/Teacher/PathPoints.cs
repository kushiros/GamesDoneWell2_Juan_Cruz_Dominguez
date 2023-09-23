using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoints : MonoBehaviour 
{
    [SerializeField] GameObject destinyPath;
    [SerializeField] int priority;
    private Vector3 dest;

    private void Start()
    {
        dest = destinyPath.transform.localPosition;
        deleteMeshRenderer();
        
    }
    // Start is called before the first frame update
    public int getPriority()
    {
        return priority;
    }

    public Vector3 getDestinyPath()
    {
        Vector3 dest = destinyPath.transform.localPosition;
        return dest;
    }
    private void deleteMeshRenderer()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        
        Destroy(meshRenderer);
        Destroy(meshFilter);
    }
}
