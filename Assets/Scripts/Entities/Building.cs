using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    public AudioClip AudioClip => _audioClip;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_audioClip != null)
            {
                EventManager.Instance.ChangePlayerAudio(_audioClip);
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.Instance.ChangePlayerAudio(null);
        }
    }
}
