using DG.Tweening;
using UnityEngine;

public class RoadSpeed2 : MonoBehaviour
{
    public bool CanMove = true;
    public float Speed = 100f;
    [SerializeField] float _speedUp = 0.1f;
    [SerializeField] float _maxSpeed = 500f;
    Tween _tween;
    
    public static RoadSpeed2 Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (CanMove)
        {
            if (Speed < _maxSpeed)
                Speed += _speedUp * Time.deltaTime;
        }
        else
        {
            SetZeroSpeed();
        }
    }

    private void SetZeroSpeed()
    {
        Speed = Mathf.MoveTowards(Speed, 0, 100);
    }

}
