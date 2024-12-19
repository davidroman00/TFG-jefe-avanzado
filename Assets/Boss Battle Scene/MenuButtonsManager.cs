
using UnityEngine;

public class MenuButtonsManager : MonoBehaviour
{
    [SerializeField]
    CharacterReferences _characterReferences;
    MouseCursorManager _mouseCursorManager;

    void Awake()
    {
        _mouseCursorManager = FindFirstObjectByType<MouseCursorManager>();
    }
    public void ResumeGame()
    {
        _characterReferences.PauseMenu.SetActive(false);
        _characterReferences.CharacterControlls.Player.Enable();
        _characterReferences.CharacterControlls.UI.Disable();

        _mouseCursorManager.HideMouse();
        Time.timeScale = 1;
    }
    public void ShowOptionsMenu()
    {
        _characterReferences.OptionsMenu.SetActive(true);
        _characterReferences.PauseMenu.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
