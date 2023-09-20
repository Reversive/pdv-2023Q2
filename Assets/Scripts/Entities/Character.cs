using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IMoveable
{
    #region PUBLIC_PROPERTIES
    public float MovementSpeed => _movementSpeed;
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] private float _movementSpeed = 5f;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private Transform orientation;

    #endregion

    #region PUBLIC_METHODS
    public void Translate(Vector3 direction) => transform.Translate(direction * Time.deltaTime * _movementSpeed);
    #endregion

    #region UNITY_METHODS
    private void Update()
    {
        UpdateInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    #endregion

    #region PRIVATE_METHODS
    private void UpdateInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    private void MovePlayer()
    {
        Vector3 moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        Translate(moveDirection);
    }
    #endregion
}
