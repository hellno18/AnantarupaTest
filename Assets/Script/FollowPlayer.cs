using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //delcare element 
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [Range(1,10)]
    [SerializeField] private float smoothFactor = 3;

    private void FixedUpdate()
    {
        Follow();
    }

    private void Follow(){
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = targetPosition;
    }

}
