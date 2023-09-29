using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    #region PRIVATE_PROPERTIES
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    private InputManager _inputManager;
    [SerializeField] private float _playerSpeed = 2.0f;
    [SerializeField] private float _jumpHeight = 1.0f;
    [SerializeField] private float _gravityValue = -9.81f;
    private Transform _cameraTransform;
    #endregion

    #region UNITY_METHODS
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _inputManager = InputManager.Instance;
        _cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        _groundedPlayer = _controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        Vector2 movement = _inputManager.GetMovementInput();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = _cameraTransform.forward * move.z + _cameraTransform.right * move.x;
        _controller.Move(move * Time.deltaTime * _playerSpeed);

        if (_inputManager.IsJumpPressed() && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }
    #endregion
}
