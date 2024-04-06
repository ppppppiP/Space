using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarSO", menuName = "CarSO")]
public class CarSO : ScriptableObject
{
    public int CarId;
    public Sprite CarSprite;
    public CarSkinSO[] CarSkinsSO;
    public CarSpecialSO[] CarSpecialSO;
    public string CarRequirements;
    public RequirementsSO[] RequirementsSO;
}
