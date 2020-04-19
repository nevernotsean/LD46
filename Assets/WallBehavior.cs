using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    // Update is called once per frame
    void Update ()
    {
        transform.LookAt (new Vector3 (0, transform.position.y, 0), Vector3.up);
    }
}