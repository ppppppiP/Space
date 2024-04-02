﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Chips.Assets.Scripts
{

    enum EquipmentType
    {
        Magnit,
        Train,
        Portal,
        Turbibe
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

    public class Equipment : MonoBehaviour
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
                _time += Time.deltaTime;
                if (_time <= _timer)
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
}
