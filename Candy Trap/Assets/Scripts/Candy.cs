using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public bool inner; //differentiate between outer candies and inner candies

    public Transform target; // Big object
    Vector3 targetDirection;


    public int radius = 5;
    public int forceAmount = 100;
    public float gravity = 0;
    private Rigidbody2D rb;

    private float distance;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // Use this for initialization
    void Start()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(1,1);
    }

    // Update is called once per frame
    void Update()
    {

        targetDirection = target.position - transform.position; // Save direction
        distance = targetDirection.magnitude; // Find distance between this object and target object
        targetDirection = targetDirection.normalized; // Normalize target direction vector

        if (distance < radius)
        {
            rb.AddForce(targetDirection * forceAmount * Time.deltaTime);
        }

		transform.Rotate (new Vector3 (0, 0, 500) * Time.deltaTime);


    }

    public float maxSpeed = 200f;//Replace with your max speed
    void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}