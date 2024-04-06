using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpecialSO : ScriptableObject
{
    public enum PriceType {
        ResourceOne, ResourceTwo, ResourceThree
    }
    public string CarSpecialText;
    public CarSpecialLevelCostSO carSpecialLevelCostSO;
    public CarSpecialLevelUpgradeSO CarSpecialLevelUpgradeSO;
}
