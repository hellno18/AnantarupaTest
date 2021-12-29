using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractC : MonoBehaviour
{
    public GameObject pressButtonE;
    public GameObject pressedButtonE;
    private bool entered;

    private void Update()
    {
        if (entered)
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                pressButtonE.SetActive(false);
                pressedButtonE.SetActive(true);
               
               
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                pressedButtonE.SetActive(false);
            }
        }
        else
        {
            pressedButtonE.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(true);
        }
        entered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(false);
        }
        entered = false;
    }
}
