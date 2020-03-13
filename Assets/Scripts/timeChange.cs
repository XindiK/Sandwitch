using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeChange : MonoBehaviour
{
    public GameObject[] Disk; //Contains the particles the trail renderer follows
    public float trailTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("volume is " + GetComponent<MicrophoneInput>().averagedVolume);
        trailTime = calculateTrailTime();
        Debug.Log("Trail time:" + trailTime);
        for (int i = 0; i < 4; i++) {
            Disk[i].GetComponent<TrailRenderer>().time = trailTime;
        }
    }

    //returns the time a trail should take to fade, depending on the kind of shape that is drawn
    float calculateTrailTime()
    {
        // if user is not speaking to the mic, trail time should be almost 0 (full shape not drawn, but path is being traced)

        //values of XE-5 are no-input, values above 0.0001 are quiet talking 
        //tested in a quiet room, may need to adjust threshold for a loud room with background noise
        if (GetComponent<MicrophoneInput>().volumeBelowThreshold(0.0001f))
        {
            return 0.01f;
        }
        else
            // if ratio is 1, very shorter trail time (enough to draw the shape)
            //larger ratio needs larger trail time
            return GetComponent<MicrophoneInput>().averagedVolume *1000;
            //return 0.5f;
            
    }
}
