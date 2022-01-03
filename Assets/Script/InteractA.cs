using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractA : EnemyBase
{
    [SerializeField] private GameObject bubbleText;

    public override void Interact()
    {
        ShowBubble();
    }

    private void ShowBubble()
    {
        if (isEntered)
        {
            
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

    

}
