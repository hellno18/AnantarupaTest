using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractE : EnemyBase
{
    protected override void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isShrink = false;
    }
    protected override void Move()
    {
        if (isEntered)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                pressedButtonE.SetActive(true);

                if (!isShrink)
                {
                    col.isTrigger = false;
                    rb2d.isKinematic = false;
                    obj.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                    isShrink = true;

                    StartCoroutine(Delay());
                }
                else
                {
                    col.isTrigger = false;
                    rb2d.isKinematic = false;
                    obj.transform.localScale = new Vector3(1, 1, 0);
                    isShrink = false;

                    StartCoroutine(Delay());
                }
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

    protected IEnumerator Delay()
    {
        float count = 0;

        while (count < 0.8)
        {
            count += Time.deltaTime * 1;
            yield return null;
        }
        rb2d.isKinematic = true;
        col.isTrigger = true;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(true);
            isEntered = true;
            rb2d.isKinematic = true;
            col.isTrigger = true;
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(false);
            isEntered = false;
            rb2d.isKinematic = false;
            col.isTrigger = false;
        }
    }
}
