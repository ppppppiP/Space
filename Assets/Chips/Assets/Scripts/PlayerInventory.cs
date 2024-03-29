using UnityEngine;

public class PlayerInventory: MonoBehaviour
{
    public int _mony { get; private set; }
    public bool Tires;
    public bool Wings;
    public bool BoolBar;

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
