using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //declare player component
    public float MovementSpeed = 1;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    private void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        // rotation player
        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
    }
}
