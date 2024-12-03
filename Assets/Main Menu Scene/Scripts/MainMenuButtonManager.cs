
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField]
    GameObject _mainMenu;
    [SerializeField]
    GameObject _settingsMenu;
    public void PlayButton()
    {
        SceneManager.LoadScene(2);
    }
    public void SettingsButton()
    {
        _mainMenu.SetActive(false);
        _settingsMenu.SetActive(true);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
