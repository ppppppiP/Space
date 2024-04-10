using System.Collections;
using UnityEngine;

public class MagnitEquipment: MonoBehaviour
{
    
    public float multiplier;
    [SerializeField] float _timer;
    public bool IsActive;
    public static MagnitEquipment Instance;

    private void Awake()
    {
        Instance = this;
    }

    public float MiltiplyColiderScale(float multiplier)
    {
        
        if (IsActive)
        {
            StartCoroutine(MagnitTimer());
            return multiplier = this.multiplier;
            
        }
        else
        {
            return 1;

        }
    }

    private IEnumerator MagnitTimer() {
        yield return new WaitForSeconds(_timer);
        IsActive = false;
    }

}
