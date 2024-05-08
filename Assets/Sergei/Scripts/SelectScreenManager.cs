using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SelectScreenManager : MonoBehaviour
{
    public TMP_Text Resource1;
    public TMP_Text Resource2;
    public TMP_Text Resource3;
    public TMP_Text Feature1Text;
    public TMP_Text Feature2Text;
    public TMP_Text Feature3Text;
    public Slider Feature1Slider;
    public Slider Feature2Slider;
    public Slider Feature3Slider;
    public TMP_Text CurrentCarKMAge;
    public TMP_Text PlayOpenBtnText;
    public GameObject[] _carObjs;
    public GameObject[] _skinObjs;
    public GameObject UpdateInfo;
    public TMP_Text[] UpgradesText;
    public GameObject RequirementInfo;
    public SnapToItem CarSnapToItem;
    public SnapToItem SkinSnapToItem;
    public int CurrentCar;
    private int _currentSkin;

    private void Update() {
        CurrentCar = CarSnapToItem.CurrentItem;
        _currentSkin = SkinSnapToItem.CurrentItem;
        UpdateResourcesDisplay();
        UpdateFeaturesDisplay();
        SetCurrentCarKMAge();
        foreach (GameObject image in _skinObjs) {
            if (CurrentCar >= 0 && CurrentCar <= 2) {
                image.GetComponent<SkinUI>().SkinImage.sprite = _carObjs[CurrentCar].GetComponent<CarUI>().CarImage.sprite;
            }
        }
        if (CurrentCar >= 0 && CurrentCar <= 2) {
            if (_carObjs[CurrentCar].GetComponent<CarUI>().IsOpen == true) {
                SetUpCurrentCarSkins(carOpen: true);
                ManageInfoHolder(carOpen: true);
                SetPlayOpenBtnText(carOpen: true);
            }
            else if (_carObjs[CurrentCar].GetComponent<CarUI>().IsOpen == false) {
                SetUpCurrentCarSkins(carOpen: false);
                ManageInfoHolder(carOpen: false);
                SetPlayOpenBtnText(carOpen: false);
            }
        }
        // Debug.Log("Current car = " + _currentCar + " upgrade 1 = " + SaveSystem.GetCarUpgradeLevel(_currentCar, 1));
        // Debug.Log("Current car = " + _currentCar + " upgrade 2 = " + SaveSystem.GetCarUpgradeLevel(_currentCar, 2));
        // Debug.Log("Current car = " + _currentCar + " upgrade 3 = " + SaveSystem.GetCarUpgradeLevel(_currentCar, 3));
        ChangeUpgradesCostText();
        // Debug.Log(CurrentCar + " current car");
        // Debug.Log(_currentSkin + " current skin");
        SaveSystem.SetCurrentCarIndex(CurrentCar);
        SaveSystem.SetCurrentSkinIndex(_currentSkin);
    }
    
    public void UpdateResourcesDisplay() {
        Resource1.text = SaveSystem.GetResourceNumber(1).ToString();
        Resource2.text = SaveSystem.GetResourceNumber(2).ToString();
        Resource3.text = SaveSystem.GetResourceNumber(3).ToString();
    }

    private void UpdateFeaturesDisplay() {
        Feature1Text.text = SaveSystem.GetCarUpgradeLevel(CurrentCar, 1).ToString();
        Feature1Slider.value = (float)SaveSystem.GetCarUpgradeLevel(CurrentCar, 1) / 10;

        Feature2Text.text = SaveSystem.GetCarUpgradeLevel(CurrentCar, 2).ToString();
        Feature2Slider.value = (float)SaveSystem.GetCarUpgradeLevel(CurrentCar, 2) / 10;

        Feature3Text.text = SaveSystem.GetCarUpgradeLevel(CurrentCar, 3).ToString();
        Feature3Slider.value = (float)SaveSystem.GetCarUpgradeLevel(CurrentCar, 3) / 10;
    }

    private void SetCurrentCarKMAge() {
        int currentCarKMAge = SaveSystem.GetCurrentCarKMAge(CurrentCar);
        int numberOfOpenCars = SaveSystem.GetNumberOfOpenCars();
        if (CurrentCar < numberOfOpenCars)
            CurrentCarKMAge.text = $"{currentCarKMAge} (km)";
        else
            CurrentCarKMAge.text = $"";
    }

    private void SetUpCurrentCarSkins(bool carOpen) {
        int OpenSkins = SaveSystem.GetNumberOfCarOpenSkins(CurrentCar);
        if (carOpen == true) {
            for (int i = 0; i < _skinObjs.Length; i++) {
                if (i < OpenSkins) {
                    _skinObjs[i].GetComponent<SkinUI>().SkinClosedImage.SetActive(false);
                }
                else {
                    _skinObjs[i].GetComponent<SkinUI>().SkinClosedImage.SetActive(true);
                }
            }
        }
        else if (carOpen == false) {
            foreach (GameObject image in _skinObjs) {
                image.GetComponent<SkinUI>().SkinClosedImage.SetActive(true);
            }
        }
    }

    private void ManageInfoHolder(bool carOpen) {
        if (carOpen == true) {
            int OpenSkinsNum = SaveSystem.GetNumberOfCarOpenSkins(CurrentCar);
            if (_currentSkin < OpenSkinsNum) {
                UpdateInfo.SetActive(true);
                RequirementInfo.SetActive(false);
            }
            else {
                UpdateInfo.SetActive(false);
                RequirementInfo.SetActive(true);
            }
        }
        else if (carOpen == false) {
            UpdateInfo.SetActive(false);
            RequirementInfo.SetActive(true);
        }
    }
    // attached to upgrade buttons
    public void IncreaseCarUpgradeLevel(int carUpgradeNumber) {
        int neededResourceAmount = SaveSystem.GetResourceNumber(carUpgradeNumber);
        if (neededResourceAmount >= SaveSystem.GetCarUpgradeLevel(CurrentCar, carUpgradeNumber)) {
            ChangeResouces(carUpgradeNumber);
            SaveSystem.IncreaseCarUpgradeLevel(CurrentCar, carUpgradeNumber);
        }
    }

    private void ChangeUpgradesCostText() {
        for (int i = 0; i < 3; i++) {
            UpgradesText[i].text = SaveSystem.GetCarUpgradeLevel(CurrentCar, i + 1).ToString();
        }
    }

    private void ChangeResouces(int resourceNumber) {
        int neededResourceAmount = SaveSystem.GetResourceNumber(resourceNumber);
        Debug.Log("neededResourceAmount - " + neededResourceAmount);
        Debug.Log("SaveSystem.GetCarUpgradeLevel(_currentCar, resourceNumber) - " + SaveSystem.GetCarUpgradeLevel(CurrentCar, resourceNumber));
        if (neededResourceAmount >= SaveSystem.GetCarUpgradeLevel(CurrentCar, resourceNumber)) {
            SaveSystem.SetRecourseNumber(resourceNumber, -SaveSystem.GetCarUpgradeLevel(CurrentCar, resourceNumber));
        }
    }

    private void SetPlayOpenBtnText(bool carOpen) {
        if (carOpen == true) {
            int OpenSkinsNum = SaveSystem.GetNumberOfCarOpenSkins(CurrentCar);
            if (_currentSkin < OpenSkinsNum) {
                PlayOpenBtnText.text = "Play";
            }
            else {
                PlayOpenBtnText.text = "Open";
            }
        }
        else {
            PlayOpenBtnText.text = "Open";
        }
    }

    public void ManagePlayOpenBtnLogic() {
        int OpenCarsNum = SaveSystem.GetNumberOfOpenCars();
        int OpenCurrentCarSkinsNum = SaveSystem.GetNumberOfCarOpenSkins(CurrentCar);
        if(CurrentCar < OpenCarsNum && _currentSkin < OpenCurrentCarSkinsNum) {
            GetComponent<MenuButtonsManager>().GoToDailyQuestHolder();
        }
        else if (CurrentCar == OpenCarsNum) {
            int resource1 = SaveSystem.GetResourceNumber(1);
            if (resource1 >= 300) {
                SaveSystem.SetRecourseNumber(1, -300);
                SaveSystem.IncreaseNumberOfOpenCars();
            }
        }
        else if (_currentSkin == OpenCurrentCarSkinsNum) {
            int resource2 = SaveSystem.GetResourceNumber(2);
            if (resource2 >= 10) {
                SaveSystem.SetRecourseNumber(2, -10);
                // SaveSystem.IncreaseNumberOfOpenCars();
                SaveSystem.IncreaseNumberOfCarOpenSkins(CurrentCar);
            }
        }
    }
}
