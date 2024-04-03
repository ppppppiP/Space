﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
using Zenject;
using Lean.Pool;

public class Mony : MonoBehaviour
{
    Tween _tween;
    Tween _scaleTween;
    [SerializeField] float _jumpPower;
    
    [SerializeField] float _duration;
    
    [SerializeField] Ease _easy;
     

    PlayerInventory _pla;

    bool enter;

    System.Action a;

    private void OnEnable()
    {
        a += AddVideocard;
    }

    //private void Update()
    //{ 
    //    if (enter == true)
    //    {


    //        //_scaleTween = transform.DOScale(0.1f, _durationScale).OnComplete(() => _pla = null);
            
    //    }
    //}

    private void OnDisable()
    {
      
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerInventory>(out PlayerInventory pla))
        {_pla = pla;
            enter = true;
            Debug.Log(MonyPrice.Instance.Price);
            _tween = transform.DOMoveY(_jumpPower ,_duration).SetEase(_easy).OnComplete(a.Invoke);
  PlayerInventory.Instance.TakeMoney(MonyPrice.Instance.Price);
        }
    }

    public void AddVideocard()
    {
        
        MonyImpact.instance.ViweTakeMony(_pla._mony);
        LeanPool.Despawn(gameObject);
        
    }
}
