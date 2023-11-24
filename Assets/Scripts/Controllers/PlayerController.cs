using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    #region PRIVATE_PROPERTIES
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    private InputManager _inputManager;
    private AudioSource _audioSource;
    private FootstepSwapper _footstepSwapper;
    private float _stepCycle;
    private float _nextStep;
    private float _stepInterval;
    [SerializeField] private float _playerSpeed = 2.0f;
    [SerializeField] private float _jumpHeight = 1.0f;
    [SerializeField] private float _gravityValue = -9.81f;
    [SerializeField] private List<AudioClip> _footstepSounds = new List<AudioClip>();
    private Transform _cameraTransform;
    #endregion

    #region UNITY_METHODS
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _inputManager = InputManager.Instance;
        _audioSource = GetComponent<AudioSource>();
        _cameraTransform = Camera.main.transform;
        _footstepSwapper = GetComponent<FootstepSwapper>();
        _stepCycle = 0f;
        _nextStep = _stepCycle / 2f;
        _stepInterval = 1.5f;
    }

    void FixedUpdate()
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
        ProgressStepCycle();
    }
    #endregion

    #region PUBLIC_METHODS
    public void SwapFootsteps(FootstepCollection collection)
    {
        _footstepSounds.Clear();
        for(int i = 0; i < collection.footstepSounds.Count; i++)
        {
            _footstepSounds.Add(collection.footstepSounds[i]);
        }
    }
    #endregion

    #region PRIVATE_METHODS
    private void PlayFootStepSound()
    {
        _footstepSwapper.CheckLayers();
        if (!_groundedPlayer)
        {
            return;
        }
        int index = Random.Range(0, _footstepSounds.Count);
        _audioSource.clip = _footstepSounds[index];
        _audioSource.PlayOneShot(_audioSource.clip);
        _footstepSounds[index] = _footstepSounds[0];
        _footstepSounds[0] = _audioSource.clip;
    }

    private void ProgressStepCycle()
    {
        if (_controller.velocity.sqrMagnitude > 0 && (_inputManager.GetMovementInput().x != 0 || _inputManager.GetMovementInput().y != 0))
        {
            _stepCycle += (_controller.velocity.magnitude + _playerSpeed) * Time.fixedDeltaTime;
        }
        if (!(_stepCycle > _nextStep))
        {
            return;
        }

        _nextStep = _stepCycle + _stepInterval;

        PlayFootStepSound();
    }
    #endregion
}
