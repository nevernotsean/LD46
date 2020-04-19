using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomCinemachineHelper : MonoBehaviour
{
    Cinemachine.CinemachineTargetGroup targetGroup;
    public float weight = 1;
    public float radius = 1;

    private void Awake ()
    {
        gameObject.TryGetComponent<Cinemachine.CinemachineTargetGroup> (out targetGroup);
    }

    public void AddMember (GameObject go)
    {
        var index = targetGroup.FindMember (go.transform);
        if (index < 1)
            targetGroup.AddMember (go.transform, weight, radius);
    }

    public void RemoveMember (GameObject go)
    {
        var index = targetGroup.FindMember (go.transform);
        if (index >= 0)
            targetGroup.RemoveMember (go.transform);
    }
}