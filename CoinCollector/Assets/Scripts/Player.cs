using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody myRigidBody;
    float speed = 10f;
    Vector3 velocity;
    int coinCount = 0;

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input vector
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        // Calculate the amount to move the player
        Vector3 direction = input.normalized;

        // Used for RigidBody collision
        velocity = direction * speed;

        // Used for regular movement
        // Vector3 velocity = direction * speed;
        // Vector3 moveAmount = velocity * Time.deltaTime;
        // transform.Translate(moveAmount);

    }

    // Called every 20ms
    // Used for RigidBody collision
    private void FixedUpdate()
    {
        myRigidBody.position += velocity * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider triggerCollider)
    {
        if (triggerCollider.tag == "Coin")
        {
            Destroy(triggerCollider.gameObject);
            coinCount++;
            print("Coins : " + coinCount);
        }
    }
}
