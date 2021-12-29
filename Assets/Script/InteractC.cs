using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractC : MonoBehaviour
{
    public GameObject pressButtonE;
    public GameObject pressedButtonE;
    private bool isEntered;
    private bool isMovingDown;
    private Animator anim;

    private void Start()
    {
        isMovingDown = false;
        isEntered = false;
        anim = GetComponent<Animator>();
    }

    private void Update()
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
       
        else if(isEntered && !isMovingDown)
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


    private IEnumerator Delay()
    {

        float count = 0;

        while (count < 2)
        {
            count += Time.deltaTime * 1;
            yield return null;
        }
        pressedButtonE.SetActive(false);
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
