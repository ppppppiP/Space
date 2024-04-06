using DG.Tweening;
using System.Collections;
using UnityEngine;
using Zenject;

public class Rocket: MonoBehaviour
{
    [Inject] SpecialEquipmentObserver _observ;
    [SerializeField] Transform _playerTransform;
    Vector3 _groundPosition;
    [SerializeField] Transform _height;
    [SerializeField] float _duration;
    [SerializeField] float _timer;
    Tween _tween;
    Tween _tween2;
    bool _isUp;

    private void Awake()
    {
        _groundPosition = _playerTransform.position;
        Debug.Log(_groundPosition.y);
        

    }

    private void OnEnable()
    {
        SpecialEquipmentObserver.OnRocketEnter += RocketJump;
    }
    //private void OnDisable()
    //{
    //    _observ.OnRocketEnter -= RocketJump;
    //}
    public void RocketJump()
    {
        Debug.Log(_groundPosition.y);
        _tween = _playerTransform.DOMoveY(_height.position.y, _duration);
        
        StartCoroutine(RocketJumpDuration());
    }

    IEnumerator RocketJumpDuration()
    {
        yield return new WaitForSeconds(_timer);
        Debug.Log(_groundPosition.y);
        _tween2 = _playerTransform.DOMoveY(_groundPosition.y, _duration);
    }
}