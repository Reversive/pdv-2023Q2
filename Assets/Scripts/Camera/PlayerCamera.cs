using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    #region PRIVATE_PROPERTIES
    [SerializeField] private float _verticalSensitivity;
    [SerializeField] private float _horizontalSensitivity;
    [SerializeField] private Transform _orientation;
    private float _horizontalRotation;
    private float _verticalRotation;
    private enum Direction { Horizontal, Vertical };
    #endregion

    #region UNITY_METHODS
    private void Start() => LockAndHideCursor();
    private void Update() => RotateCamera();
    #endregion

    #region PRIVATE_METHODS
    private void LockAndHideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private Vector2 GetMouseInput()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        return new Vector2(mouseX, mouseY);
    }

    private float GetRotationByDirection(Direction direction)
    {
        return direction == Direction.Horizontal ? 
            GetMouseInput().x * Time.deltaTime * _horizontalSensitivity : 
            GetMouseInput().y * Time.deltaTime * _verticalSensitivity;
    }

    private void RotateCamera()
    {
        _horizontalRotation += GetRotationByDirection(Direction.Horizontal);
        _verticalRotation -= GetRotationByDirection(Direction.Vertical);
        _verticalRotation = Mathf.Clamp(_verticalRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(_verticalRotation, _horizontalRotation, 0f);
        _orientation.rotation = Quaternion.Euler(0f, _horizontalRotation, 0f);
    }  
    #endregion

}
