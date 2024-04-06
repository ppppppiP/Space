using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsManager : MonoBehaviour
{
    public GameObject MainMenuHolder;
    public GameObject SelectScreenHolder;
    public GameObject DailyQuestHolder;

    public void GoToMainMenu() {
        DeactivateAll();
        MainMenuHolder.SetActive(true);
    }

    public void GoToSelectScreen() {
        DeactivateAll();
        SelectScreenHolder.SetActive(true);
    }

    public void GoToDailyQuestHolder() {
        DeactivateAll();
        DailyQuestHolder.SetActive(true);
    }

    private void DeactivateAll() {
        MainMenuHolder.SetActive(false);
        SelectScreenHolder.SetActive(false);
        DailyQuestHolder.SetActive(false);
    }

    public void LoadGame() {
        SceneManager.LoadScene(0);
    }
}
