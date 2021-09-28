using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireSound : MonoBehaviour
{
    AudioSource aus;

    // Start is called before the first frame update
    void Start()
    {
        aus=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)
        || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            aus.Play();

            if(aus.isPlaying==false)
            {
            aus.Play();
            }
        }
        else
        {
            aus.Stop();
        }
    }
}
