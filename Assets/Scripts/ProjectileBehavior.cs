using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1;
    Vector3 moveHeading;

    void Start ()
    {
        TryGetComponent<Rigidbody> (out rb);
    }

    private void Update ()
    {
        moveHeading = (transform.position - Vector3.zero).normalized;

        transform.LookAt (moveHeading, transform.up);

        rb.MovePosition (transform.position + transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter (Collision other)
    {
        other.gameObject.TryGetComponent<HealthManager> (out HealthManager health);

        if (health != null)
            health.TakeDamage ();

        Destroy (gameObject);
    }
}