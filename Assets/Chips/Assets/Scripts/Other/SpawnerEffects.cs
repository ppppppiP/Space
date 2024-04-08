using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEffects : MonoBehaviour
{
    [SerializeField] GameObject effectPrefabe;
    [SerializeField] float _time = 1.5f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHP>(out PlayerHP hP))
        {
            GameObject o = LeanPool.Spawn(effectPrefabe, hP.transform.position, Quaternion.identity);
            StartCoroutine(Despawner(o));
        }
    }

    IEnumerator Despawner(GameObject o)
    {
        yield return new WaitForSeconds(_time);
        LeanPool.Despawn(o);
    }
}
