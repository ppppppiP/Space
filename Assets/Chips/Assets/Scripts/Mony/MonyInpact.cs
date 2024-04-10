using UnityEngine;

using DG.Tweening;
using TMPro;
using Lean.Pool;
using Zenject;

public class MonyImpact: MonoBehaviour
{
    Tween tween;
    [SerializeField] TextMeshProUGUI _monyText;
    [SerializeField] Ease _ease;
    public static MonyImpact instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        MonyObserver.Instance.OnMonyTake += ViweTakeMony;
    }

    

    public void ViweTakeMony(int mony)
    {
        _monyText.text = mony.ToString(); 
        
    }
}
