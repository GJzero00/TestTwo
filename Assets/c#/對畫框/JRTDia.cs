using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JRTDia : MonoBehaviour
{

  
    
    public GameObject Button;
    public GameObject talkUI;
    
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        Button.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);

    }
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            talkUI.SetActive(true);
          
        }

    }

}
