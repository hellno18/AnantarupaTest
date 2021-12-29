using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractB : MonoBehaviour
{
    public GameObject pressButtonE;
    public GameObject pressedButtonE;
    public float mforce = 20f;
    [SerializeField] private bool entered;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Transform player;
    private bool isLeft;
    private bool isRight;

    private void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
        rb2d.isKinematic = true;
        boxCollider.isTrigger = true;
    }

    private void Update()
    {
        if (entered)
        {
            PositionCheck();
            if (Input.GetKeyDown(KeyCode.E))
            {
                pressButtonE.SetActive(false);
                pressedButtonE.SetActive(true);
                rb2d.isKinematic = false;
                boxCollider.isTrigger = false;
                if(isLeft)
                    rb2d.AddForce(Vector2.left * mforce);
                if(isRight)
                    rb2d.AddForce(Vector2.right * mforce);
                StartCoroutine(AddDrag());
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                pressedButtonE.SetActive(false);
                rb2d.isKinematic = true;
                boxCollider.isTrigger = true;
            }
        }
        else
        {
            pressedButtonE.SetActive(false);
        }
    }

    private IEnumerator AddDrag()
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(true);
        }
        entered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(false);
            rb2d.isKinematic = true;
            boxCollider.isTrigger = true;
        }
        entered = false;
    }

}
