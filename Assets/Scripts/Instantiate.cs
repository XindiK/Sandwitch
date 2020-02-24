﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public int pieceCount = 5;    
    public GameObject prefab;
    public Vector3 centerPos;
    public Vector3 sphereScale;
    public float radius;

    public GameObject BigSphere;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateCircle();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateCircle()
    {
        float angle = 180f / (float)pieceCount;
        for (int i = 0; i < pieceCount; i++)
        {
            Quaternion rotation = Quaternion.AngleAxis(i * angle, Vector3.forward);
            Vector3 direction = rotation * Vector3.forward;
            centerPos = BigSphere.transform.localPosition; //position of parent sphere.
            sphereScale = BigSphere.transform.localScale;
            GameObject disk = Instantiate(prefab, centerPos, rotation);
            disk.transform.SetParent(BigSphere.transform, false);
        }
    }
}