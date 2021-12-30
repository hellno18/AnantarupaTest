using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseD : MonoBehaviour
{
    [SerializeField] protected GameObject pressButtonE;
    [SerializeField] protected GameObject pressedButtonE;
    [SerializeField] protected float mForce = 1f;
    protected bool isEntered;
    protected bool isGround;
    protected Rigidbody2D rb2d;
    [SerializeField] BoxCollider2D col;

    protected void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        Move();
    }

    protected void Move()
    {
        if (isEntered)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pressedButtonE.SetActive(true);
                rb2d.velocity = new Vector2(0, Mathf.Sqrt(-2.0f * Physics2D.gravity.y * mForce));

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

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(true);
            isEntered = true;
            ChangeCollision();
        }
        if (other.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(false);
            isEntered = false;
            ChangeCollision();
        }
        if (other.CompareTag("Ground"))
        {
            isGround = false;
        }

    }

    protected void ChangeCollision()
    {
        if (isEntered && isGround)
        {
            rb2d.isKinematic = true;
            col.isTrigger = true;
        }
        else
        {
            rb2d.isKinematic = false;
            col.isTrigger = false;
        }
    }
}
