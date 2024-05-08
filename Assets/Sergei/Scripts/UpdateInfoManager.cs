using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class UpdateInfoManager : MonoBehaviour
{
    public SelectScreenManager SelectScreenManager;
    public GameObject UpdateHolder1;
    public TMP_Text UpdateText1;
    public GameObject UpdateHolder2;
    public TMP_Text UpdateText2;
    public GameObject UpdateHolder3;
    public TMP_Text UpdateText3;

    private void Update() {
        if (SelectScreenManager.CurrentCar >= 0 && SelectScreenManager.CurrentCar <= 2) {
            if (SelectScreenManager.CurrentCar == 0) {
                SetFirstCarUpgrades();
            }
            else if (SelectScreenManager.CurrentCar == 1) {
                SetSecondCarUpgrades();
            }
            else if (SelectScreenManager.CurrentCar == 2) {
                SetThirdCarUpgrades();
            }
        }
    }

    private void SetFirstCarUpgrades() {
        UpdateHolder3.SetActive(false);
        UpdateText1.text = "Бронепоезд";
        UpdateText2.text = "Магнит";
    }

    private void SetSecondCarUpgrades() {
        UpdateHolder3.SetActive(false);
        UpdateText1.text = "Космолет-ранец";
        UpdateText2.text = "Монеты Х2";
    }

    private void SetThirdCarUpgrades() {
        UpdateHolder3.SetActive(true);
        UpdateText1.text = "Бесконечные крылья";
        UpdateText2.text = "Монеты Х2";
        UpdateText3.text = "Магнит";
    }
}
