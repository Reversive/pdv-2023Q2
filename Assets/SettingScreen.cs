using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingScreen : MonoBehaviour
{
    [SerializeField] private Toggle _fullscreenToggle;
    [SerializeField] private Toggle _vsyncToggle;
    [SerializeField] private List<ResItem> _resolutions;
    [SerializeField] private TMP_Text _resolutionLabel;
    private int currentResIndex;

    private void Start()
    {
        _fullscreenToggle.isOn = Screen.fullScreen;
        _vsyncToggle.isOn = QualitySettings.vSyncCount == 1;
        bool foundRes = false;
        for (int i = 0; i < _resolutions.Count; i++)
        {
            if (Screen.width == _resolutions[i].horizontal && Screen.height == _resolutions[i].vertical)
            {
                currentResIndex = i;
                foundRes = true;
                UpdateResLabel();
                break;
            }
        }

        if (!foundRes)
        {
            _resolutions.Add(new ResItem { horizontal = Screen.width, vertical = Screen.height });
            currentResIndex = _resolutions.Count - 1;
            UpdateResLabel();
        }
    }

    private void Update()
    {
        
    }

    public void UpdateResLabel()
    {
        _resolutionLabel.text = _resolutions[currentResIndex].horizontal + " x " + _resolutions[currentResIndex].vertical;
    }

    public void ResLeft()
    {
        currentResIndex--;
        if (currentResIndex < 0)
            currentResIndex = _resolutions.Count - 1;
        UpdateResLabel();
    }

    public void ResRight()
    {
        currentResIndex++;
        if (currentResIndex > _resolutions.Count - 1)
            currentResIndex = 0;
        UpdateResLabel();
    }

    public void Apply()
    {
        Screen.fullScreen = _fullscreenToggle.isOn;
        QualitySettings.vSyncCount = _vsyncToggle.isOn ? 1 : 0;
        Screen.SetResolution(_resolutions[currentResIndex].horizontal, _resolutions[currentResIndex].vertical, _fullscreenToggle.isOn);
    }

}

[System.Serializable]
public class  ResItem
{
    public int horizontal, vertical;
}
