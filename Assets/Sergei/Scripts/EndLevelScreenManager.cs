using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndLevelScreenManager : MonoBehaviour
{
    public TMP_Text CurrentRunKM;
    public GameObject EndLevelHolder;
    public GameObject SettingsHolder;
    public void RestartLevel() {
        // restart level;
    }

    public void WatchAd() {
        // watch ad
    }

    public void GoToMenu() {
        SceneManager.LoadScene(1);
    }

    public void GoToSettings() {
        EndLevelHolder.SetActive(false);
        SettingsHolder.SetActive(true);
    }

    public void GoToEndLevelScreen() {
        EndLevelHolder.SetActive(true);
        SettingsHolder.SetActive(false);
    }
}
