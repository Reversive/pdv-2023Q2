using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region PRIVATE_PROPERTIES
    private static InputManager _instance;
    private PlayerControls _playerControls;
    #endregion

    #region UNITY_METHODS
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        _playerControls = new PlayerControls();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnEnable()
    {
        _playerControls.Enable();
    }
    private void OnDisable()
    {
        _playerControls.Disable();
    }
    #endregion

    #region PUBLIC_METHODS
    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }
    public Vector2 GetPlayerMovement()
    {
        return _playerControls.Player.Movement.ReadValue<Vector2>();
    }
    #endregion
}
