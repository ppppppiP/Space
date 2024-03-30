
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
using Zenject;

public class Mony : MonoBehaviour
{
    Tween _tween;
    Tween _scaleTween;
    [SerializeField] float _jumpPower;
    [SerializeField] int _jumpsNumber;
    [SerializeField] float _duration;
    [SerializeField] float _durationScale;
    [SerializeField] Ease _easy;
     

    PlayerInventory _pla;

    bool enter;

    System.Action a;

    private void OnEnable()
    {
        a += AddVideocard;
    }

    private void Update()
    { 
        if (enter == true)
        {


            //_scaleTween = transform.DOScale(0.1f, _durationScale).OnComplete(() => _pla = null);
            _tween = transform.DOJump(_pla.transform.position, _jumpPower, _jumpsNumber, _duration).SetEase(_easy).OnComplete(a.Invoke);
        }
    }

    private void OnDisable()
    {
        PlayerInventory.Instance.TakeMoney(MonyPrice.Instance.Price);
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerInventory>(out PlayerInventory pla))
        {_pla = pla;
            enter = true;
            Debug.Log(MonyPrice.Instance.Price);
            

        }
    }

    public void AddVideocard()
    {
        
        MonyImpact.instance.ViweTakeMony(_pla._mony);
        gameObject.SetActive(false);
        
    }
}
