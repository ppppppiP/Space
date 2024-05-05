using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Chips.Assets.Scripts
{

    enum EquipmentType
    {
        Magnit,
        Train,
        Portal,
        Turbibe,
        X2
    }

    

    public interface IEquipment
    {
        public void SetEquipment(bool a, PlayerInventory pla);
    }
    public class Magnit : IEquipment
    {
        public void SetEquipment(bool a, PlayerInventory pla)
        {
            pla.Magnit = a;
           
        }
    }

    public class Train : IEquipment
    {
        public void SetEquipment(bool a, PlayerInventory pla)
        {
            pla.Train = a;
        }
    }

    public class EquipmentX2 : IEquipment
    {
        public void SetEquipment(bool a, PlayerInventory pla)
        {
            pla.X2 = a;
        }
    }

    public class Portal : IEquipment
    {
        public void SetEquipment(bool a, PlayerInventory pla)
        {
            pla.Portal = a;
        }
    } 
    public class Turbine : IEquipment
    {
        public void SetEquipment(bool a, PlayerInventory pla)
        {
            pla.Turbibe = a;
        }
    }

    public class SpecialEquipment : MonoBehaviour
    {
        bool _isActive = true;
        IEquipment equip;
        [SerializeField] EquipmentType _equipmentType;
        
        [Inject] SpecialEquipmentObserver _observ;
       


        bool _isEnter;
        PlayerInventory _inventory;
        EquipmentObjects _objects;

        private void Start()
        {
            switch (_equipmentType)
            {
                case EquipmentType.Magnit:
                    equip = new Magnit();
                    break;
                case EquipmentType.Train:
                    equip = new Train();
                    break;
                case EquipmentType.Portal:
                    equip = new Portal();
                    break;
                case EquipmentType.Turbibe:
                    equip = new Turbine();
                    break;
            }
        }

        private void Update()
        {
            if (_isEnter)
            {
                //_time += Time.deltaTime;
                //if (_time <= _timer)
                //{
                //    _isActive = false;
                //}
                //else
                //{

                //    

                //    _objects.TiresObject.SetActive(!_isActive);
                //    _objects.WingsObject.SetActive(!_isActive);
                //    _objects.BoolBarObject.SetActive(!_isActive);
                    
                //}
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

        

        private void OnDisable()
        {
            _isActive = true;
            _isEnter = false;
        }

        private void OnTriggerExit(Collider other)
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.TryGetComponent<PlayerInventory>(out PlayerInventory inventory))
            {
                _objects = other.GetComponent<EquipmentObjects>();
                _isEnter = true;
                _isActive = false;
                _inventory = inventory;

                if(equip is Portal)
                {
                    PortalTeleporter.Instance.Teleport(other.transform);
                }
                else
                if(equip is Turbine)
                {
                    Rocket.Instance.RocketJump();
                }
                else
                if(equip is Magnit)
                {
                    MagnitEquipment.Instance.IsActive = true;
                }
                else
                if(equip is EquipmentX2)
                {
                    X2.Instance.Muliply();
                }
                else
                if(equip is Train)
                {
                    SingleTrain.Instance.SetTrainActive();
                }
            }
        }
    }
}

public class SingleTrain: MonoBehaviour 
{
    public bool IsTrainActive;
    [SerializeField] float m_Timer;

    public static SingleTrain Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SetTrainActive()
    {
        IsTrainActive = true;
        StartCoroutine(Duration());
    }

    IEnumerator Duration()
    {
        yield return new WaitForSeconds(m_Timer);
        IsTrainActive = false;
    }

}