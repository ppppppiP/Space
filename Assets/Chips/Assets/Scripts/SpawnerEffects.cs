using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEffects : MonoBehaviour
{
    [SerializeField] GameObject effectPrefabe;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerHP>(out PlayerHP hP))
        LeanPool.Spawn(effectPrefabe, hP.transform.position, Quaternion.identity);
    }
}
