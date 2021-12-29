using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractA : MonoBehaviour
{
    public GameObject pressButtonE;
    public GameObject pressedButtonE;
    public GameObject BubbleText;
    [SerializeField] private bool entered;

    private void Update()
    {
        if (entered)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pressedButtonE.SetActive(true);
                BubbleText.SetActive(true);
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                pressedButtonE.SetActive(false);
                BubbleText.SetActive(false);
            }
        }
        else
        {
            pressedButtonE.SetActive(false);
            BubbleText.SetActive(false);
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
