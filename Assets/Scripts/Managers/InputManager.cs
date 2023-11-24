using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region PRIVATE_PROPERTIES
    private PlayerControls _playerControls;
    private static InputManager _instance;
    #endregion

    #region PUBLIC_PROPERTIES
    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

    #region UNITY_METHODS
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        _playerControls = new PlayerControls();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
    public Vector2 GetMovementInput()
    {
        return _playerControls.Player.Movement.ReadValue<Vector2>();
    }
    public Vector2 GetMouseDelta()
    {
        return _playerControls.Player.Look.ReadValue<Vector2>();
    }

    public bool IsJumpPressed()
    {
        return _playerControls.Player.Jump.triggered;
    }

    public bool IsFlashlightPressed()
    {
        return _playerControls.Player.Flashlight.triggered;
    }

    public bool IsInteractPressed()
    {
        return _playerControls.Player.Pickup.triggered;
    }
    #endregion
}
