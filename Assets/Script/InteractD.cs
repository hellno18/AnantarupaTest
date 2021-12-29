using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractD : MonoBehaviour
{
    public GameObject pressButtonE;
    public GameObject pressedButtonE;
    public float mForce = 1f;
    [SerializeField] private bool isEntered;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isEntered)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pressedButtonE.SetActive(true);
                rb2d.isKinematic = false;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(true);
            isEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressButtonE.SetActive(false);
            isEntered = false;
        }
    }
}
