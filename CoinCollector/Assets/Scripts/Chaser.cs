using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    // Variable to track the player object
    public Transform targetTransform;
    float speed = 7f;

    // Update is called once per frame
    void Update()
    {
        // Calculate chaser position based on current target position
        Vector3 displacementFromTarget = targetTransform.position - transform.position;
        Vector3 directionToTarget = displacementFromTarget.normalized;
        Vector3 velocity = directionToTarget * speed;

        // Update position only if distance from target is > 1.5
        if (displacementFromTarget.magnitude > 1.5f)
        {
            transform.Translate(velocity * Time.deltaTime);
        }

    }
}
