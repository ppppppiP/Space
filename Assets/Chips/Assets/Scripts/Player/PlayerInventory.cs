using JetBrains.Annotations;
using UnityEngine;

public class PlayerInventory: MonoBehaviour
{
    public int _mony { get; private set; }
    public bool Tires = true;
    public bool Wings = true;
    public bool BoolBar = true, 
                Magnit,
                Train,
                Portal,
                Turbibe,
                X2;
    [SerializeField] float _time = 10f;
    float _timer;
    EquipmentObjects _objects;

    public static PlayerInventory Instance;
    private void Awake()
    {
        Instance = this;
        _objects= GetComponent<EquipmentObjects>();
    }

    private void Update()
    {
        if (!Tires || !Wings || !BoolBar)
        {
            _objects.TiresObject.SetActive(!Tires);
            _objects.WingsObject.SetActive(!Wings);
            _objects.BoolBarObject.SetActive(!BoolBar);
            _timer += Time.deltaTime;
            if(_timer >= _time)
            {
                _timer = 0;
                Tires = true;
                Wings = true;
                BoolBar = true;
                _objects.TiresObject.SetActive(!Tires);
                _objects.WingsObject.SetActive(!Wings);
                _objects.BoolBarObject.SetActive(!BoolBar);
            }
        }
    }

    public void TakeMoney(int mony)
    {
        if (mony < 0)
            return;
        _mony += mony;
    }

    public void SetEquipment()
    {
        if(Tires == true)
        {
            
        }
    }
}

