
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField]
    GameObject _settingsMenu;
    public void PlayButton()
    {
        SceneManager.LoadScene(2);
    }
    public void SettingsButton()
    {
        gameObject.SetActive(false);
        _settingsMenu.SetActive(true);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
