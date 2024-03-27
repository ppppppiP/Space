using UnityEngine;

public class PlayerInventory: MonoBehaviour
{
    int _mony;


    public void TakeMony(int mony)
    {
        if (mony < 0)
            return;
        _mony += mony;
    }
}
