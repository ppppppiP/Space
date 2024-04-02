using UnityEngine;
using Lean.Pool;
public class RoadMove: MonoBehaviour
{
    [SerializeField] float Timer = 30f;
    float _time;

    private void FixedUpdate()
    {
        Move();
    }

   

    private void Move()
    {
        transform.Translate(-transform.forward * RoadSpeed.Instance.Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RoadDespawner>())
        {
            LeanPool.Despawn(gameObject);
        }
    }

}
