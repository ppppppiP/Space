using UnityEngine;

public class PlayerInventory: MonoBehaviour
{
    public int _mony { get; private set; }

    public static PlayerInventory Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void TakeMony(int mony)
    {
        if (mony < 0)
            return;
        _mony += mony;
    }
}
