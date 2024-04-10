using UnityEngine;

public class MonyPrice: MonoBehaviour
{
    public int Price = 10;
    [SerializeField] int PriceUp = 10;
    [SerializeField] float MaxTime = 10f;
    float _timer;

    public static MonyPrice Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        _timer+= Time.deltaTime;
        if (_timer > MaxTime)
        {
            Price += PriceUp;
            _timer= 0;
        }
    }
}

