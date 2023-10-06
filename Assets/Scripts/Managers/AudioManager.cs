using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource AudioSource;


    #region UNITY_EVENTS

    private void Start()
    {
        EventManager.Instance.OnChangePlayerAudio += ChangePlayerAudio;
    }

    #endregion

    public void ChangePlayerAudio(AudioClip music)
    {
        AudioSource.Stop();
        if (music != null)
        {
            AudioSource.clip = music;
            AudioSource.Play();
        }
        
    }
}
