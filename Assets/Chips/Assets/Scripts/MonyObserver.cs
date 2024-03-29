using UnityEngine;
using System;

public class MonyObserver: MonoBehaviour
{
    public  Action<int> OnMonyTake; 
    public static MonyObserver Instance;
    private void Awake()
    {
        Instance = this;
    }
}