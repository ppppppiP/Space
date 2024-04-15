using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TeleportTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TeleportToRandomPosition>() != null)
        {
            other.gameObject.GetComponent<TeleportToRandomPosition>().Teleport();
        }
    }
}
