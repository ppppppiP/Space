﻿using System.Collections;
using UnityEngine;
using Zenject;

public class PortalTeleporter: MonoBehaviour
{
    [SerializeField] Transform _playerPosition;
    [SerializeField] Transform _newPosition;
    [Inject] SpecialEquipmentObserver _observ;
    [SerializeField] float _timer;
    Vector3 defoultPos;

    public static PortalTeleporter Instance;

    private void Awake()
    {
        defoultPos = _playerPosition.transform.position;
        Instance = this;
    }

    private void OnEnable()
    {
        SpecialEquipmentObserver.OnPortalEnter += Teleport;
    }

    //private void OnDisable()
    //{
    //    _observ.OnPortalEnter -= Teleport;
    //}

    public void Teleport(Transform player)
    {
        Debug.Log("tpp");
        Debug.Log(_playerPosition.transform.position);
        player.transform.position = _newPosition.transform.position;
        StartCoroutine(teleportToDefoult());
        
        Debug.Log(_newPosition.transform.position);
    }

    IEnumerator teleportToDefoult()
    {
        yield return new WaitForSeconds(_timer);
        _playerPosition.transform.position = defoultPos;
    }
}