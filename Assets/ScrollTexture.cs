using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public float speed = 3;
    private Material groundMaterial;
    private Vector3 offset;

    void Start()
    {
        groundMaterial = GetComponent<MeshRenderer>().material;
        offset = new Vector3(0, 0, 0);
    }

    void Update()
    {
        offset += Vector3.forward * speed;
        groundMaterial.SetVector("_Offset", offset);
    }
}
