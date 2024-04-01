using UnityEngine;

using DG.Tweening;

public class Rocks: MonoBehaviour
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

   

    private void OnEnable()
    {
       
    }

    private void Update()
    {
        if (enter == true)
        {

            _tween = transform.DOJump(_pla.transform.position, _jumpPower, _jumpsNumber, _duration).SetEase(_easy).OnComplete(()=> gameObject.SetActive(false));
            //_scaleTween = transform.DOScale(0.1f, _durationScale).OnComplete(() => _pla = null);

        }
    }

    private void OnDisable()
    {
    
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerInventory>(out PlayerInventory pla))
        {
            _pla = pla;
            enter = true;
           

        }
    }

    public void AddVideocard()
    {


        gameObject.SetActive(false);

    }
}

