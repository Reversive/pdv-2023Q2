
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    #region PRIVATE_PROPERTIES
    [SerializeField] private Light _light;
    private InputManager _inputManager;
    #endregion

    #region UNITY_METHODS
    private void Start()
    {
        _inputManager = InputManager.Instance;
    }

    private void Update()
    {
        if (_inputManager.IsFlashlightPressed())
        {
            _light.enabled = !_light.enabled;
        }
    }
    #endregion
}
