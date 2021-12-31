using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractD : EnemyBase
{
    [SerializeField] private float mForce;
    private bool isGround;
    [SerializeField] private BoxCollider2D col;
    [SerializeField] private Rigidbody2D rb2d;
    protected override void Start()
    {
        mForce = 1f;
        rb2d = GetComponent<Rigidbody2D>();
    }

    public override void Interact()
    {
        Jump();
    }

    private  void Jump()
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

    protected override void OnTriggerEnter2D(Collider2D other)
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

    protected override void OnTriggerExit2D(Collider2D other)
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
