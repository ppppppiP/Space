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

    float _time;
    bool _isEnter;
    PlayerInventory _inventory;
    EquipmentObjects _objects;

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
                
                _objects.TiresObject.SetActive(!_isActive);
                _objects.WingsObject.SetActive(!_isActive);
                _objects.BoolBarObject.SetActive(!_isActive);
                Debug.LogAssertion("sdfgsdf");
            } 
            switch (equip)
            {
            case Tires:
                equip.SetEquipment(_isActive, _inventory);
                    _objects.TiresObject.SetActive(!_isActive);
                break;
            case Wings:
                equip.SetEquipment(_isActive, _inventory);
                    _objects.WingsObject.SetActive(!_isActive);
                break;
            case BoolBar:
                equip.SetEquipment(_isActive, _inventory);
                    _objects.BoolBarObject.SetActive(!_isActive);
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.TryGetComponent<PlayerInventory>(out PlayerInventory inventory))
        {
            _objects = other.GetComponent<EquipmentObjects>();
            _isEnter = true;
            _isActive = false;
            _inventory = inventory;
        }

    }
}
