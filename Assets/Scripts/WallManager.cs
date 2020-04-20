using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class WallManager : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private Vector3Variable wallPlacementPosition;

    public void CreateNewWall ()
    {
        Instantiate (wallPrefab, wallPlacementPosition.Value, Quaternion.identity);
    }
}