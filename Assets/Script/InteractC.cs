using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractC : EnemyBase
{
    private bool isMovingDown;
    private Animator anim;

    protected override void Start()
    {
        isMovingDown = false;
        isEntered = false;
        anim = GetComponent<Animator>();
    }

    public override void Interact()
    {
        GoesIntoFloor();
    }

    private void GoesIntoFloor()
    {
        if (isEntered && isMovingDown)
        {
            
           anim.SetBool("isDown", false);
           isMovingDown = false;
           StartCoroutine(Delay());
            

        }

        else if (isEntered && !isMovingDown)
        {
            isMovingDown = true;
            anim.SetBool("isDown", true);
            StartCoroutine(Delay());
            
        }


        if (isEntered)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pressButtonE.SetActive(false);
                pressedButtonE.SetActive(true);
            }

        }
        else
        {
            pressedButtonE.SetActive(false);
        }
    }

    protected IEnumerator Delay()
    {

        float count = 0;

        while (count < 2)
        {
            count += Time.deltaTime * 1;
            yield return null;
        }
        pressedButtonE.SetActive(false);
    }


    


}
