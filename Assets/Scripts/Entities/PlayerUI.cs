using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void SetText(string text)
    {
        _text.text = text;
    }
}
