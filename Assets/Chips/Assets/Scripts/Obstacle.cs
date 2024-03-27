using UnityEngine;

public class Obstacle: MonoBehaviour
{
    [SerializeField] int _damage;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerHP>(out PlayerHP pla)) 
        {
            pla.TakeDamage(_damage);
        }
    }
}