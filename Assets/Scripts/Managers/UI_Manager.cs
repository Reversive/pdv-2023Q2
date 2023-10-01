using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
   #region FLASHLIGHT_LOGIC
   [SerializeField] private Image _batteryBar;
   [SerializeField] private Text _batteryPercent;

   private void OnFlashlightBatteryChange(int currentBat, int maxBat)
   { 
      float percentage = (float)currentBat / (float)maxBat;
      _batteryBar.fillAmount = (float)currentBat / (float)maxBat;
      _batteryPercent.text = $"{ (currentBat * 100 /maxBat)}%";

   }
   #endregion
   
   #region UNITY_EVENTS

   private void Start()
   {
      EventManager.instance.OnFlashlightBatteryChange += OnFlashlightBatteryChange;
   }

   #endregion
}
