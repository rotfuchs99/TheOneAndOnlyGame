using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    private UIController uiController;
    
    // Start is called before the first frame update
    void Start()
    {
        //only use find if you are sure that you only have one of that component in the scene
        uiController = FindObjectOfType<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Trigger detected");

        if (other.tag == "goal")
        {
            //Debug.Log("reached goal!! you win?");
            uiController.GameWin();
        }
        
        if (other.tag == "defeat")
        {
            //Debug.Log("you lost!");
            uiController.GameLost();
        }

        if (other.tag == "coin")
        {
            uiController.AddCoin();
            Destroy(other.gameObject);
        }

    }
}
