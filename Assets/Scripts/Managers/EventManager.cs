using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    #region PRIVATE_PROPERTIES
    private static EventManager _instance;
    #endregion

    #region PUBLIC_PROPERTIES
    public static EventManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

    #region UNITY_EVENTS
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
            _instance = this;
        }
    }
    #endregion

    #region GAME_MANAGER
    public event Action<bool> OnGameOver;

    public void EventGameOver(bool isVictory) 
    {
        if (OnGameOver != null) OnGameOver(isVictory);
    }
    #endregion


    #region UI_Elements_Update

    public event Action<int, int> OnFlashlightBatteryChange;

    public void FlashlightBatteryChange(int currentBattery, int maxBattery)
    {
        if (OnFlashlightBatteryChange != null) OnFlashlightBatteryChange(currentBattery,maxBattery);
    }

    #endregion
    
    #region UI_Sounds_Update

    public event Action<AudioClip> OnChangePlayerAudio;

    public void ChangePlayerAudio(AudioClip music)
    {
        if (OnChangePlayerAudio != null) OnChangePlayerAudio(music);
    }

    #endregion

}