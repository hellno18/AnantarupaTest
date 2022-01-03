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
           
            pressedButtonE.SetActive(true);
            rb2d.velocity = new Vector2(0, Mathf.Sqrt(-2.0f * Physics2D.gravity.y * mForce));
        }
        else
        {
            pressedButtonE.SetActive(false);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGround = true;
        }
        
    }


    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGround = false;
        }

    }
    public override void SetEnter(bool x)
    {
        base.SetEnter(x);
        ChangeCollision();
        UnShowPressedE();
    }


    public void ChangeCollision()
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
