using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    #region  total km on planets
    public static int GetTotalMoonKM() {
        return PlayerPrefs.GetInt("TotalMoonKM", 0);
    }

    public static void SetTotalMoonKM(int km) {
        PlayerPrefs.SetInt("TotalMoonKM", km);
    }

    public static int GetTotalMarsKM() {
        return PlayerPrefs.GetInt("TotalMarsKM", 0);
    }

    public static void SetTotalMarsKM(int km) {
        PlayerPrefs.SetInt("TotalMarsKM", km);
    }
    #endregion
    #region music and volume values
    public static float GetMusicVolume() {
        return PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }
    public static void SetMusicVolume(float volume) {
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public static float GetEffectsVolume() {
        return PlayerPrefs.GetFloat("EffectsVolume", 0.5f);
    }

    public static void SetEffectsVolume(float volume) {
        PlayerPrefs.SetFloat("EffectsVolume", volume);
    }
    #endregion

    #region current planet index
    public static int GetCurrentPlanetIndex() {
        return PlayerPrefs.GetInt("CurrentPlanetIndex", 0);
    }

    public static void SetCurrentPlanetIndex(int currentPlanetIndex) {
        PlayerPrefs.SetInt("CurrentPlanetIndex", currentPlanetIndex);
    }
    #endregion

    #region current car & skin
    public static int GetCurrentCarIndex() {
        return PlayerPrefs.GetInt("CurrentCarIndex", 0);
    }

    public static void SetCurrentCarIndex(int carIndex) {
        PlayerPrefs.SetInt("CurrentCarIndex", carIndex);
    }

    public static int GetCurrentSkinIndex() {
        return PlayerPrefs.GetInt("CurrentSkinIndex", 0);
    }
    public static void SetCurrentSkinIndex(int skinIndex) {
        PlayerPrefs.SetInt("CurrentSkinIndex", skinIndex);
    }
    #endregion
    
    #region resources
    public static int GetResourceNumber(int resourceNumber) {
        return PlayerPrefs.GetInt($"Resource{resourceNumber}", 0);
    }

    public static void SetRecourseNumber(int resourceNumber, int addValue)  {
        PlayerPrefs.SetInt($"Resource{resourceNumber}", GetResourceNumber(resourceNumber) + addValue);
        if (GetResourceNumber(resourceNumber) < 0) {
            PlayerPrefs.SetInt($"Resource{resourceNumber}", 0);
        }
    }
    #endregion

    #region car km age
    public static int GetCurrentCarKMAge(int carId) {
        return PlayerPrefs.GetInt($"Car{carId}KMAge", 10000);
    }

    public static void SetCurrentCarKMAge(int carId, int KMage) {
        PlayerPrefs.SetInt($"Car{carId}KMAge", KMage);
    }
    #endregion

    #region open skins
    public static int GetNumberOfCarOpenSkins(int carId) {
        return PlayerPrefs.GetInt($"NumberOfCar{carId}OpenSkins", 1);
    }

    public static void IncreaseNumberOfCarOpenSkins(int carId) {
        PlayerPrefs.SetInt($"NumberOfCar{carId}OpenSkins", GetNumberOfCarOpenSkins(carId) + 1);
    }
    #endregion

    #region upgrades
    public static int GetCarUpgradeLevel(int carId, int UpgradeNumber) {
        return PlayerPrefs.GetInt($"GetCar{carId}Upgrade{UpgradeNumber}Level", 1);
    }

    public static void IncreaseCarUpgradeLevel(int carId, int UpgradeNumber) {
        PlayerPrefs.SetInt($"GetCar{carId}Upgrade{UpgradeNumber}Level", GetCarUpgradeLevel(carId,UpgradeNumber) + 1);
        // upgrade level cap goes here
    }
    #endregion

    #region  open cars
    public static int GetNumberOfOpenCars() {
        return PlayerPrefs.GetInt("NumberOfOpenCars", 1);
    }

    public static void IncreaseNumberOfOpenCars() {
        PlayerPrefs.SetInt("NumberOfOpenCars", GetNumberOfOpenCars() + 1);
    }
    #endregion

    private void Start() {
        SetCurrentCarKMAge(0, 10000);
        SetCurrentCarKMAge(1, 20000);
        SetCurrentCarKMAge(2, 30000);
        PlayerPrefs.SetInt("NumberOfOpenCars", 1);
        for (int i = 0; i < 3; i++) {
            PlayerPrefs.SetInt($"NumberOfCar{i}OpenSkins", 1);
            for (int j = 0; j < 3; j++) {
                PlayerPrefs.SetInt($"GetCar{i}Upgrade{j + 1}Level", 1);
            }
        }
        PlayerPrefs.SetInt($"Resource{1}", 999);
        PlayerPrefs.SetInt($"Resource{2}", 100);
        PlayerPrefs.SetInt($"Resource{3}", 100);
    }
}
