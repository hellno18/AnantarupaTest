using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected bool isEntered;
    [SerializeField] protected GameObject pressButtonE;
    [SerializeField] protected GameObject pressedButtonE;
    
    //object a
    [SerializeField] protected GameObject bubbleText;

    //object b
    [SerializeField] protected float mForce;
    protected Rigidbody2D rb2d;
    [SerializeField] protected BoxCollider2D boxCollider;
    [SerializeField] protected Transform player;
    protected bool isLeft;
    protected bool isRight;

    //object c
    protected bool isMovingDown;
    protected Animator anim;

    //object d
    protected bool isGround;
    [SerializeField] protected BoxCollider2D col;


    //object e
    protected bool isShrink;
    [SerializeField] protected Transform obj;

    protected virtual void Start()
    {
        
    }

    protected void Update()
    {
        Move();
    }


    protected virtual void Move()
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

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(true);
            isEntered = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(false);
            isEntered = false;
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(true);
            isEntered = true;
        }
    }

}
