using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseB : MonoBehaviour
{
    [SerializeField] protected GameObject pressButtonE;
    [SerializeField] protected GameObject pressedButtonE;
    [SerializeField] protected float mForce = 20f;
    protected bool isEntered;
    protected Rigidbody2D rb2d;
    [SerializeField] protected BoxCollider2D boxCollider;
    [SerializeField] protected Transform player;
    protected bool isLeft;
    protected bool isRight;

    protected void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
        rb2d.isKinematic = true;
        boxCollider.isTrigger = true;
    }

    protected void Update()
    {
        Move();
    }

    protected void Move()
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
                StartCoroutine(AddDrag());
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                pressedButtonE.SetActive(false);
                rb2d.isKinematic = true;
                boxCollider.isTrigger = true;
            }
        }
    }

    protected IEnumerator AddDrag()
    {

        float current_drag = 0;

        while (current_drag < 10)
        {
            current_drag += Time.deltaTime * 2;
            rb2d.drag = current_drag;
            yield return null;
        }

        rb2d.velocity = Vector2.zero;
        rb2d.drag = 0;
        pressedButtonE.SetActive(false);
    }



    protected void PositionCheck()
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
            rb2d.isKinematic = true;
            boxCollider.isTrigger = true;
            isEntered = false;
        }
    }

}
