using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float maxSpeed = 5f;
    public GameObject explode;

    private Rigidbody rb;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; 
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 force = new Vector3(h, 0, v);
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(force * movementSpeed);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "enemy")
        {
            Die();
        }

        if (col.tag == "Goal")
        {
            gameManager.completelevel1();
        }
    }

    void Die()
    {
        PlayExplosion();
        transform.position = startPos;

    }

    void PlayExplosion()
    {
        GameObject clone = Instantiate(explode);
        clone.transform.position = transform.position;
        ParticleSystem explosion = clone.GetComponent<ParticleSystem>();
        explosion.Play();
    }
}
