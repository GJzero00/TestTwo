using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JRTDia : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;
    // Start is called before the first frame update
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
    // Update is called once per frame
    private void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            talkUI.SetActive(true);
        }
      
    }

}
