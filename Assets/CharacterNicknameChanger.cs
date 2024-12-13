using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterNicknameChanger : MonoBehaviour
{
    void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = IntroductionButtonManager.Username;
    }
}
