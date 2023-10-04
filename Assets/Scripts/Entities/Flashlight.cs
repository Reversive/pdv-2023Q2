
using UnityEngine;

public class Flashlight : MonoBehaviour, IListener
{
    #region PRIVATE_PROPERTIES
    [SerializeField] private Light _light;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private int _battery;
    [SerializeField] private int _maxBattery;
    [SerializeField] private int _chargeSpeed;
    [SerializeField] private int _dischargeSpeed;
    private AudioSource _audioSource;
    private InputManager _inputManager;
    private EventManager _eventManager;
    #endregion

    #region PRIVATE_METHODS
    private void BatteryChange(int delta)
    {
        float change = _battery + Time.deltaTime * delta;
        if (_battery < 0)
        {
            _battery = 0;
        }else if (_battery > _maxBattery)
        {
            _battery = _maxBattery;
        }
        else
        {
            _battery = (int)(change);
        }
        
    } 

    private void UpdateBattery()
    {
        if (_battery <= 0)
        {
            _light.enabled = false;
        }
        
        if (_light.enabled)
        {
            BatteryChange(-_dischargeSpeed);
        }
        else
        {
            BatteryChange(_chargeSpeed);
        }
        _eventManager.FlashlightBatteryChange(_battery, _maxBattery);

    }

    #endregion

    #region PUBLIC_PROPERTIES
    public AudioClip AudioClip => _audioClip;
    public AudioSource AudioSource => _audioSource;

    public int Battery => _battery;
    public int MaxBattery => _maxBattery;

    public int ChargeSpeed => _chargeSpeed;
    public int DischargeSpeed => _dischargeSpeed;
    
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
        _eventManager = EventManager.Instance;
        _battery = MaxBattery;
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

    private void FixedUpdate()
    {
        UpdateBattery();
    }
    #endregion
}
