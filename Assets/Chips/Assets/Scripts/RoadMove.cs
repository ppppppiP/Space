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

    private void Update()
    {
        _time+= Time.deltaTime;
        if (_time >= Timer)
        {
            Destroy(gameObject);
            LeanPool.Despawn(EndlessRoad.instance._road);
        }
    }

    private void Move()
    {
        transform.Translate(-transform.forward * RoadSpeed.Instance.Speed * Time.deltaTime);
    }

   
}