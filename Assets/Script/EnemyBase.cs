using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class EnemyBase : MonoBehaviour
{
    protected bool isEntered;
    [SerializeField] protected GameObject pressButtonE;
    [SerializeField] protected GameObject pressedButtonE;


    public abstract void Interact();

    protected virtual void Start()
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
