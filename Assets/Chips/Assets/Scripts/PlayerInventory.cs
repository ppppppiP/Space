using UnityEngine;

public class PlayerInventory: MonoBehaviour
{
    public int _mony { get; private set; }
    [HideInInspector] public bool Tires;
    [HideInInspector] public bool Wings;
    [HideInInspector] public bool BoolBar;

    public static PlayerInventory Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void TakeMoney(int mony)
    {
        if (mony < 0)
            return;
        _mony += mony;
    }
}
