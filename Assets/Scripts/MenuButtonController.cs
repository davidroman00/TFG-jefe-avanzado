using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuButtonController : MonoBehaviour
{
    [SerializeField]
    PlayerInputController _playerInputController;
    [SerializeField]
    GameObject _pauseMenu;
    [SerializeField]
    GameObject _optionsMenu;
    [SerializeField]
    TextMeshProUGUI _interactKeybindText;
    InputActionRebindingExtensions.RebindingOperation _interactRebind;

    public void ResumeGame()
    {
        _playerInputController.CharacterControlls.UI.Disable();
        _playerInputController.CharacterControlls.Player.Enable();
        _pauseMenu.SetActive(false);

        Time.timeScale = 1.0f;
        Cursor.visible = false;
    }
    public void ShowOptions()
    {
        _optionsMenu.SetActive(true);
        _pauseMenu.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void BackButton()
    {
        _pauseMenu.SetActive(true);
        _optionsMenu.SetActive(false);
    }
    public void InteractKeybindChange()
    {
        _interactRebind = _playerInputController.CharacterControlls.Player.Interact.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(.1f)
            .OnComplete(_ => OnBindingComplete())
            .Start();
    }

    void OnBindingComplete()
    {
        int bindingIndex = _playerInputController.CharacterControlls.Player.Interact.GetBindingIndexForControl(_playerInputController.CharacterControlls.Player.Interact.controls[0]);

        _interactKeybindText.text = InputControlPath.ToHumanReadableString(_playerInputController.CharacterControlls.Player.Interact.bindings[bindingIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);

        _interactRebind.Dispose();
    }
}
