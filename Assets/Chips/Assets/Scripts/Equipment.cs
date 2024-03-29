using UnityEngine;

enum EquipmentType
{
    Tires,
    Wings,
    BoolBar
}
public interface IEquipment
{
    public void SetEquipment(bool a, PlayerInventory pla);
}
public class Tires: IEquipment
{
    public void SetEquipment(bool a, PlayerInventory pla)
    {
        pla.Tires = a;
    }
}

public class Wings : IEquipment
{
    public void SetEquipment(bool a, PlayerInventory pla)
    {
        pla.Wings = a;
    }
}

public class BoolBar : IEquipment
{
    public void SetEquipment(bool a, PlayerInventory pla)
    {
        pla.BoolBar = a;
    }
}

public class Equipment: MonoBehaviour
{
    bool _isActive = true;
    IEquipment equip;
    [SerializeField] EquipmentType _equipmentType;
    [SerializeField] float _timer;
    [SerializeField] GameObject TiresObject;
    [SerializeField] GameObject WingsObject;
    [SerializeField] GameObject BoolBarObject;
    float _time;
    bool _isEnter;
    PlayerInventory _inventory;

    private void Start()
    {
        switch (_equipmentType)
        {
            case EquipmentType.Tires:
                equip = new Tires();
                break;
            case EquipmentType.Wings:
                equip = new Wings();
                break;
            case EquipmentType.BoolBar:
                equip = new BoolBar();
                break;
        }
    }

    private void Update()
    {
        if (_isEnter)
        {
            _time += Time.deltaTime;
            if(_time <= _timer)
            {
                _isActive = false;
            }
            else
            {
                _isActive = true;
                _isEnter = false;

                TiresObject.SetActive(false);
                WingsObject.SetActive(false);
                BoolBarObject.SetActive(false);
            } 
            switch (equip)
            {
            case Tires:
                equip.SetEquipment(_isActive, _inventory);
                    TiresObject.SetActive(true);
                break;
            case Wings:
                equip.SetEquipment(_isActive, _inventory);
                    WingsObject.SetActive(true);
                break;
            case BoolBar:
                equip.SetEquipment(_isActive, _inventory);
                    BoolBarObject.SetActive(true);
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.TryGetComponent<PlayerInventory>(out PlayerInventory inventory))
        {
            _isEnter = true;
            _isActive = false;
            _inventory = inventory;
        }

    }
}
