using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractA : MonoBehaviour
{
    [SerializeField] private GameObject pressButtonE;
    [SerializeField] private GameObject pressedButtonE;
    [SerializeField] private GameObject bubbleText;
    private bool isEntered;

    private void Update()
    {
        if (isEntered)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pressedButtonE.SetActive(true);
                bubbleText.SetActive(true);
                StartCoroutine(DelayBubble());
            }

        }
        else
        {
            pressedButtonE.SetActive(false);
            bubbleText.SetActive(false);
        }
    }


    private IEnumerator DelayBubble()
    {
        
        yield return new WaitForSeconds(1);
        pressedButtonE.SetActive(false);
        bubbleText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(true);
            isEntered = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(false);
            isEntered = false;
        } 
    }
}
