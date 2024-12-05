using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSettingsMenuButtonManager : MonoBehaviour
{
    [SerializeField]
    GameObject _settingsMenu;
    public void BackButton()
    {
        _settingsMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
