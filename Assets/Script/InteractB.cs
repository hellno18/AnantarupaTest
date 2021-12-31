using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractB : EnemyBase
{
    [SerializeField] private float mForce;
    private Rigidbody2D rb2d;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Transform player;
    private bool isLeft;
    private bool isRight;

    

    protected override void Start()
    {
        mForce = 50f;
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
        rb2d.isKinematic = true;
        boxCollider.isTrigger = true;
        
    }

    public override void Interact()
    {
        GoesAway();
    }

    private void GoesAway()
    {
        if (isEntered)
        {
            PositionCheck();
            if (Input.GetKeyDown(KeyCode.E))
            {
                pressButtonE.SetActive(false);
                pressedButtonE.SetActive(true);
                rb2d.isKinematic = false;
                boxCollider.isTrigger = false;
                if (isLeft)
                    rb2d.AddForce(Vector2.left * mForce);
                if (isRight)
                    rb2d.AddForce(Vector2.right * mForce);
                isEntered = false;
                StartCoroutine(AddDrag());
            }
        }
        
        if (Input.GetKeyUp(KeyCode.E))
        {
            pressedButtonE.SetActive(false);
            rb2d.isKinematic = true;
            boxCollider.isTrigger = true;
        }
    }

    private IEnumerator AddDrag()
    {
       
        float current_drag = 0;

        while (current_drag < 4)
        {
            current_drag += Time.deltaTime * 2;
            rb2d.drag = current_drag;
            yield return null;
        }

        rb2d.velocity = Vector2.zero;
        rb2d.drag = 0;
        pressedButtonE.SetActive(false);
    }



    private void PositionCheck()
    {
        if (player.position.x < this.gameObject.transform.position.x)
        {
            isRight = true;
            isLeft = false;

        }
        else
        {
            isLeft = true;
            isRight = false;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(true);
            isEntered = true;
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(false);
            rb2d.isKinematic = true;
            boxCollider.isTrigger = true;
            isEntered = false;
        }
    }
}
