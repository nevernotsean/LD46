using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class SyncVariableWithPosition : MonoBehaviour
{
    [SerializeField] private Vector3Reference _reference;
    [SerializeField] private Vector3 offset;

    [SerializeField] private bool SetVariableFromPosition = false;

    void LateUpdate ()
    {
        if (SetVariableFromPosition)
            _reference.Value = transform.position + offset;
        else
            transform.position = _reference.Value + offset;
    }
}