using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class MoveCharacter : MonoBehaviour
{
    [SerializeField] private Vector3Variable MoveDirection;

    public float speed = 10;

    CharacterController controller;

    private void Awake ()
    {
        TryGetComponent<CharacterController> (out controller);
    }

    // Update is called once per frame
    void Update ()
    {
        // transform.position, transform.position + MoveDirection.Value, speed * Time.deltaTime
        var move = transform.TransformDirection (speed * Time.deltaTime * MoveDirection.Value);
        controller.SimpleMove (speed * MoveDirection.Value);
        transform.LookAt (transform.position + MoveDirection.Value);
    }
}