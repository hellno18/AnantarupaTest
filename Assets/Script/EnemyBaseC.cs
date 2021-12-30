using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseC : MonoBehaviour
{
    [SerializeField] protected GameObject pressButtonE;
    [SerializeField] protected GameObject pressedButtonE;
    protected bool isEntered;
    protected bool isMovingDown;
    protected Animator anim;

    protected void Start()
    {
        isMovingDown = false;
        isEntered = false;
        anim = GetComponent<Animator>();
    }

    protected void Update()
    {
        Move();
        
    }

    protected void Move()
    {
        if (isEntered && isMovingDown)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("isDown", false);
                isMovingDown = false;
                StartCoroutine(Delay());
            }

        }

        else if (isEntered && !isMovingDown)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isMovingDown = true;
                anim.SetBool("isDown", true);
                StartCoroutine(Delay());
            }
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

    protected void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(true);
            isEntered = true;
        }
    }
}
