using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleSphere : MonoBehaviour
{
    public Transform prefab;
    public float rotationPitch;
    public float startingScale = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(prefab, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        }
        rotationPitch = GetComponent<myMixer>().getPitchFromRotation();
        prefab.localScale = new Vector3(startingScale, startingScale, startingScale);
        
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("rotationPitch in scale: " + rotationPitch);
        prefab.localScale = new Vector3(startingScale*rotationPitch, startingScale * rotationPitch, startingScale * rotationPitch);
    }
}
