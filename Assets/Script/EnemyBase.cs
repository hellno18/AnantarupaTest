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


    public void SetEnter(bool x)
    {
         isEntered = x ;
    }

    public bool GetEnter()
    {
        return isEntered;
    }

    public void ShowEUI()
    {
        pressButtonE.SetActive(true);
    }

    public void UnShowEUI()
    {
        pressButtonE.SetActive(false);
    }

    public void ShowPressedE()
    {
        pressedButtonE.SetActive(true);
    }

    public void UnShowPressedE()
    {
        pressedButtonE.SetActive(false);
    }
}
