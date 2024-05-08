using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsManager : MonoBehaviour
{
    public GameObject MainMenuHolder;
    public GameObject SelectScreenHolder;
    public GameObject DailyQuestHolder;
    public GameObject PlanetSelectHolder;
    public GameObject SettingsHolder;
    public void GoToMainMenu() {
        DeactivateAll();
        MainMenuHolder.SetActive(true);
    }

    public void GoToSettings() {
        DeactivateAll();
        SettingsHolder.SetActive(true);
    }

    public void GoToSelectScreen() {
        DeactivateAll();
        SelectScreenHolder.SetActive(true);
    }

    public void GoToDailyQuestHolder() {
        DeactivateAll();
        DailyQuestHolder.SetActive(true);
    }

    public void GoToPlanetSelect() {
        DeactivateAll();
        PlanetSelectHolder.SetActive(true);
    }

    private void DeactivateAll() {
        MainMenuHolder.SetActive(false);
        SelectScreenHolder.SetActive(false);
        DailyQuestHolder.SetActive(false);
        SettingsHolder.SetActive(false);
        PlanetSelectHolder.SetActive(false);
    }

    public void LoadGame(int PlanetIndex) {
        SaveSystem.SetCurrentPlanetIndex(PlanetIndex);
        SceneManager.LoadScene(1);
    }
}
