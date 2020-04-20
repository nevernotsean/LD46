using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private IntReference Health;
    [SerializeField] private VoidBaseEventReference DeathEvent;

    private void Awake ()
    {
        // var healthVariable = (IntVariable) Health.Value.;
        // healthVariable.Changed.Register (HandleHealthUpdate);
    }

    public void TakeDamage ()
    {
        Health.Value = Health.Value - 1;
    }

    public void HandleHealthUpdate (int health)
    {
        if (health <= 0) DeathEvent.Event.Raise ();
    }
}