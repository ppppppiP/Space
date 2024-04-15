using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToRandomPosition : MonoBehaviour
{
    [SerializeField] List<Transform> _teleportPositions;
    [SerializeField] Vector3 _offset;
    [SerializeField] LayerMask _layerMask;

    public void Teleport()
    {
        gameObject.transform.position = _teleportPositions[Random.Range(0, _teleportPositions.Count)].position + _offset;
    }
}
