using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpeed : MonoBehaviour
{
    public float Speed = 100f;
    [SerializeField] float _speedUp = 0.1f;
    [SerializeField] float _maxSpeed = 500f;
    public static RoadSpeed Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(Speed<_maxSpeed)
            Speed += _speedUp * Time.deltaTime; 
    }
}
