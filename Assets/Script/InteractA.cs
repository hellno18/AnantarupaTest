using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractA : EnemyBase
{
    [SerializeField] private GameObject bubbleText;

    protected override void ShowBubble()
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

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(true);
            isEntered = true;
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(false);
            isEntered = false;
        }
    }

}
