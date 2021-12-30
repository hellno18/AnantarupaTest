using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected bool isEntered;
    [SerializeField] protected GameObject pressButtonE;
    [SerializeField] protected GameObject pressedButtonE;
 
    
    protected virtual void Start()
    {
        
    }

    protected void Update()
    {
        ShowBubble();
        GoesAway();
        GoesIntoFloor();
        Jump();
        Shrink();
    }


    protected virtual void ShowBubble()
    {
        
    }

    protected virtual void GoesAway()
    {

    }

    protected virtual void GoesIntoFloor()
    {

    }

    protected virtual void Jump()
    {

    }

    protected virtual void Shrink()
    {

    }


    protected virtual void OnTriggerEnter2D(Collider2D other)
    {

    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {

    }

    protected virtual void OnTriggerStay2D(Collider2D other)
    {

    }

}
