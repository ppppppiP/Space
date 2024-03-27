using UnityEngine;

public class Mony: MonoBehaviour
{
    [SerializeField, Min(0)] int _price;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerInventory>(out PlayerInventory pla))
        {
            pla.TakeMony(_price);
        }
    }
}