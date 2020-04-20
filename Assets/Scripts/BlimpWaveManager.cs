using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using UnityAtoms.Tags;

public class BlimpWaveManager : MonoBehaviour
{
  public GameObject prefab;
  public GameObjectValueList _list;
  public IntVariable limit;
  public float delay = 2.0f;

  public float radius = 20.0f;

  IEnumerator Start ()
  {
    while (true)
    {
      if (_list.Count <= limit.Value)
      {
        var randomCircle = Random.insideUnitCircle.normalized * radius;

        var randomPos = Vector3.one;
        randomPos.x = randomPos.x + randomCircle.x;
        randomPos.z = randomPos.z + randomCircle.y;

        var instant = Instantiate (prefab, randomPos, Quaternion.identity, transform);
      }
      yield return new WaitForSeconds (delay);
    }
  }
}