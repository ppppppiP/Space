using UnityEngine;
using Lean.Pool;

public enum Speeds
{
    Speed0,
    Speed1,
    Speed2,
    Speed3,
}

public class RoadMove: MonoBehaviour
{
    [SerializeField] float Timer = 30f;
    float _time;
    float speed;
    [SerializeField] Speeds numberOfSpeed;

    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        switch (numberOfSpeed)
        {
            case Speeds.Speed0:
                speed = RoadSpeed.Instance.Speed;
                break;
                ///////////
            case Speeds.Speed1:
                speed = RoadSpeed1.Instance.Speed;
                break;
                ///////////
            case Speeds.Speed2:
                speed = RoadSpeed2.Instance.Speed;
                break;
                ///////////
            case Speeds.Speed3:
                speed = RoadSpeed3.Instance.Speed;
                break;
        }

        

        transform.Translate(-transform.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RoadDespawner>())
        {
            LeanPool.Despawn(gameObject);
        }
    }

   

}
