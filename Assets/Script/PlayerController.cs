using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 1;
    private Rigidbody2D rb2d;
    [SerializeField] private GameObject obstacleRay;
    private bool isEntered;
    [SerializeField] private GameObject pressE;

    // Start is called before the first frame update

    private void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.E))
            CheckInteraction();
     
    }

    private void Move()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        // rotation player
        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
    }

    private void CheckInteraction()
    {
        RaycastHit2D hit = Physics2D.Raycast(obstacleRay.transform.position, -Vector2.left, 1f);
        if (hit.collider !=null)
        {
            hit.transform.GetComponent<EnemyBase>().Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {

            other.gameObject.GetComponent<EnemyBase>().SetEnter(true);
            other.gameObject.GetComponent<EnemyBase>().ShowUI();

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyBase>().SetEnter(false);
            other.gameObject.GetComponent<EnemyBase>().UnShowUI();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

    }
}


