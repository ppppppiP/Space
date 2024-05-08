using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetsManager : MonoBehaviour
{
    public TMP_Text MoonRequirementText;
    public GameObject MoonBlocker;
    public TMP_Text PlutoRequirementText;
    public GameObject PlutoBlocker;
    private void Start() {
        int moonKM = SaveSystem.GetTotalMoonKM();
        int marsKM = SaveSystem.GetTotalMarsKM();
        if (moonKM < 7000) {
            MoonRequirementText.text = $"To open: 7000 km on Moon (now {moonKM})";
        }
        else {
            MoonRequirementText.enabled = false;
            MoonBlocker.SetActive(false);
        }

        if (marsKM < 7000) {
            PlutoRequirementText.text = $"To open: 7000 km on Mars (now {marsKM})";
        }
        else {
            PlutoRequirementText.enabled = false;
            PlutoBlocker.SetActive(false);  
        }
    }
}
