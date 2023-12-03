using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
   #region FLASHLIGHT_LOGIC
   [SerializeField] private Image _batteryBar;
   [SerializeField] private TextMeshProUGUI _batteryPercent;
   [SerializeField] private List<Sprite> _batteryImages;
   [SerializeField] private GameObject _pauseMenu;
   private InputManager _inputManager;
   private MenuManager _menuManager;

   private void OnFlashlightBatteryChange(int currentBat, int maxBat)
   {
      float percentage = (float)currentBat / (float)maxBat;

        int index = Mathf.FloorToInt((1f - percentage) * _batteryImages.Count);
        index = Mathf.Clamp(index, 0, _batteryImages.Count - 1);
        if(_batteryPercent != null)
            _batteryBar.sprite = _batteryImages[index];
    }

    IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(3f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _menuManager.LoadLoseGameScene();

    }

    private void OnGameOver(bool isVictory)
    {
        
    }
    #endregion

    #region UNITY_EVENTS

    private void Start()
   {
      //_menuManager = GetComponent<MenuManager>();
      EventManager.Instance.OnFlashlightBatteryChange += OnFlashlightBatteryChange;
      EventManager.Instance.OnGameOver += OnGameOver;
      _inputManager = GetComponent<InputManager>();
   }

    private void Update()
    {
        if(_inputManager.IsPausePressed())
        {
            _pauseMenu.SetActive(!_pauseMenu.activeSelf);
            if (_pauseMenu.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f;
            }
        }
    }

    #endregion
}
