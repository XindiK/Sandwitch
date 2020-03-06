using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeChange : MonoBehaviour
{
   public GameObject[] Disk;
    public float trailTime;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Disk");
        trailTime = 0.5f;
        for (int i = 1; i < 5; i++)
        {
         //   Disk[i] = GameObject.Find("Particle" + i);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Disk");
        for (int i = 0; i < 4; i++) {
            Disk[i].GetComponent<TrailRenderer>().time = trailTime;
        }
       // Disk.GetComponent<TrailRenderer>().time = trailTime;
    }
}
