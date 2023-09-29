
using UnityEngine;

public class Flashlight : MonoBehaviour, IListener
{
    #region PRIVATE_PROPERTIES
    [SerializeField] private Light _light;
    [SerializeField] private AudioClip _audioClip;
    private AudioSource _audioSource;
    private InputManager _inputManager;
    #endregion

    #region PUBLIC_PROPERTIES
    public AudioClip AudioClip => _audioClip;
    public AudioSource AudioSource => _audioSource;
    #endregion

    #region SOUND_METHODS
    public void InitAudioSource()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClip;
    }

    public void Play()
    {
        _audioSource.Play();
    }

    public void PlayOneShot()
    {
        _audioSource.PlayOneShot(_audioClip);
    }

    public void Stop()
    {
       _audioSource.Stop();
    }
    #endregion

    #region UNITY_METHODS
    private void Start()
    {
        _inputManager = InputManager.Instance;
        InitAudioSource();
    }

    private void Update()
    {
        if (_inputManager.IsFlashlightPressed())
        {
            _light.enabled = !_light.enabled;
            PlayOneShot();
        }

    }
    #endregion
}
