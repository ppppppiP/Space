using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CarSkinSO : ScriptableObject
{
    public int SkinId;
    public string SkinRequirements;
    public RequirementsSO[] RequirementsSO;
}
