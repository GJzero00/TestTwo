using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DieUI : MonoBehaviour
{
    public GameObject player;
   
    public GameObject dieUI;


    void Start()
    {

    }

    
    void Update()
    {
        if (player != null)
        {
            dieUI.SetActive(false);
        }
        else
        {
            dieUI.SetActive(true);
        }
    }   
}
