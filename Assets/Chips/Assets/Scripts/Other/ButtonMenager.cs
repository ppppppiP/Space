using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenager: MonoBehaviour
{

    public void GoMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
