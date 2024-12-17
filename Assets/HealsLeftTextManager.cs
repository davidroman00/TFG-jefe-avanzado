using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealsLeftTextManager : MonoBehaviour
{
    TextMeshProUGUI _text;
    CharacterStats _charStats;
    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _charStats = FindFirstObjectByType<CharacterStats>();
    }
    void Update()
    {
        _text.text = _charStats.HealCharges.ToString();
    }
}
