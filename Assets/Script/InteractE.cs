using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractE : EnemyBase
{
    private bool isShrink;
    [SerializeField] private Transform obj;
    [SerializeField] private BoxCollider2D col;
    [SerializeField] private Rigidbody2D rb2d;

    protected override void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isShrink = false;
    }

    public override void Interact()
    {
        Shrink();
    }

    private void Shrink()
    {
        if (isEntered)
        {

           
           pressedButtonE.SetActive(true);

           if (!isShrink)
           {
              col.isTrigger = false;
              rb2d.isKinematic = false;
              obj.transform.localScale = new Vector3(0.5f, 0.5f, 0);
              isShrink = true;

              StartCoroutine(Delay());
                    
           }
           else
           {
              col.isTrigger = false;
              rb2d.isKinematic = false;
              obj.transform.localScale = new Vector3(1, 1, 0);
              isShrink = false;
              StartCoroutine(Delay());
                    
           }
            
            
        }
        else
        {
            pressedButtonE.SetActive(false);
        }
    }

    protected IEnumerator Delay()
    {
        float count = 0;

        while (count < 0.8)
        {
            count += Time.deltaTime * 1;
            yield return null;
        }
        rb2d.isKinematic = true;
        col.isTrigger = true;
        pressedButtonE.SetActive(false);
    }

}
