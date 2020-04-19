using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using UnityAtoms.Tags;

public class EnemyWaveManager : MonoBehaviour
{
    public GameObject prefab;
    public GameObjectValueList _list;
    public IntVariable limit;
    public float delay = 2.0f;
    public StringConstant emitterTag;

    private GameObject[] emitters;

    private void Awake ()
    {
        emitters = AtomTags.FindAllByTag (emitterTag.Value);
    }

    IEnumerator Start ()
    {
        while (true)
        {
            if (_list.Count < limit.Value)
                yield return new WaitForEndOfFrame ();

            var randomEmitter = emitters[Random.Range (0, emitters.Length - 1)];

            var instant = Instantiate (prefab, randomEmitter.transform.position, Quaternion.identity, randomEmitter.transform);

            yield return new WaitForSeconds (delay);
        }
    }
}