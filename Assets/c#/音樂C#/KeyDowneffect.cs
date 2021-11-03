using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDowneffect : MonoBehaviour
{
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.DownArrow))
           || (Input.GetKeyDown(KeyCode.W) )|| (Input.GetKeyDown(KeyCode.S)))
        {
            audioSource.Play();    
        }
    }
}
