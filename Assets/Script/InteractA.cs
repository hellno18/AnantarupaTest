using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractA : EnemyBase
{
    protected override void Move()
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

}
