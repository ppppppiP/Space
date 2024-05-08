using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RequirementInfoManager : MonoBehaviour
{
    public SelectScreenManager selectScreenManager;
    public TMP_Text tMP_Text;
    private string RequirementText = "";

    private void Update() {
        int numberOfOpenCars = SaveSystem.GetNumberOfOpenCars();
        int currentCar = selectScreenManager.CurrentCar;
        if (currentCar == 1 && numberOfOpenCars == 1) {
            RequirementText = "Чтоб открыть: 300 золота@Спец. оборудование:@1) Космолет-ранец@2) Монеты Х2";
            RequirementText = RequirementText.Replace("@", System.Environment.NewLine);

            tMP_Text.text = RequirementText;
        }
        else if (currentCar == 2 && numberOfOpenCars <= 2) {
            RequirementText = "Чтоб открыть: 400 золота@Спец. оборудование:@1) Бесконечные крылья@2) Монеты Х2@3) Магнит";
            RequirementText = RequirementText.Replace("@", System.Environment.NewLine);

            tMP_Text.text = RequirementText;
        }
        else {
            RequirementText = "Чтобы открыть:@7000 км по Луне@или 10 кристалов";
            RequirementText = RequirementText.Replace("@", System.Environment.NewLine);
            tMP_Text.text = RequirementText;
        }
    }
}
