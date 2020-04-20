using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using UnityAtoms.FSM;
using UnityAtoms.Tags;

public class EnemyBehavior : MonoBehaviour
{
    CharacterController controller;

    [SerializeField] private FiniteStateMachineReference StateMachineRef;

    [SerializeField] private StringConstant playerTag;

    [SerializeField] private FloatReference _shootingRange = new FloatReference (3f);

    [SerializeField] private float distance;

    GameObject player;

    [SerializeField] private float speed = 10f;
    void Awake ()
    {
        gameObject.TryGetComponent<CharacterController> (out controller);

        AtomTags.OnInitialization (() => player = AtomTags.FindByTag (playerTag.Value));

        StateMachineRef.Machine.OnUpdate ((deltaTime, value) =>
        {
            distance = Vector3.Distance (player.transform.position, transform.position);

            if (value == "CHASING")
            {
                if (player != null)
                    MoveTowardsPlayer ();

            }
            else if (value == "ATTACKING")
            {

            }
        }, gameObject);

        StateMachineRef.Machine.DispatchWhen (
            command: "ATTACK",
            (value) => player != null && value == "CHASING" && (_shootingRange.Value >= Vector3.Distance (player.transform.position, transform.position)),
            gameObject
        );

        StateMachineRef.Machine.DispatchWhen (
            command: "CHASE", (value) => player.transform != null && value == "ATTACKING" && (_shootingRange.Value < Vector3.Distance (player.transform.position, transform.position)), gameObject);
    }

    void MoveTowardsPlayer ()
    {
        controller.SimpleMove ((player.transform.position - transform.position).normalized * speed);
    }
}