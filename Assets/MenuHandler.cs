using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject _mainButtons;
    [SerializeField] private GameObject _settingsButtons;

    public void OnClickSettings()
    {
        _settingsButtons.SetActive(true);
        _mainButtons.SetActive(false);
    }

    public void OnClickBack()
    {
        _settingsButtons.SetActive(false);
        _mainButtons.SetActive(true);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
