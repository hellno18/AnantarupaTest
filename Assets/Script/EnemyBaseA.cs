using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseA : MonoBehaviour
{
    protected bool isEntered;
    [SerializeField] protected GameObject pressButtonE;
    [SerializeField] protected GameObject pressedButtonE;
    [SerializeField] protected GameObject bubbleText;

    protected void Update()
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


    protected IEnumerator DelayBubble()
    {

        yield return new WaitForSeconds(1);
        pressedButtonE.SetActive(false);
        bubbleText.SetActive(false);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(true);
            isEntered = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(false);
            isEntered = false;
        }
    }

}
