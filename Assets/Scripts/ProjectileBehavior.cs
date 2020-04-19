using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1;
    [SerializeField] private UnityAtoms.BaseAtoms.StringConstant playerTag;

    GameObject player;
    Vector3 moveHeading;

    void Start ()
    {
        TryGetComponent<Rigidbody> (out rb);
        player = UnityAtoms.Tags.AtomTags.FindByTag (playerTag.Value);
    }

    private void Update ()
    {
        moveHeading = (transform.position - player.transform.position).normalized;

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