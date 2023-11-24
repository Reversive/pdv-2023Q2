using Assets.Scripts.Strategy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    #region PRIVATE_PROPERTIES
    private Camera _camera;
    [SerializeField] private float _interactDistance = 3f;
    private InputManager _inputManager;
    private PlayerUI _playerUI;
    [SerializeField] private LayerMask _layerMask;
    #endregion

    #region UNITY_METHODS
    private void Start()
    {
        _inputManager = InputManager.Instance;
        _camera = Camera.main;
        _playerUI = GetComponent<PlayerUI>();
    }

    private void Update()
    {
        _playerUI.SetText(string.Empty);
        Ray r = new Ray(_camera.transform.position, _camera.transform.forward);
        bool hit = Physics.Raycast(r, out RaycastHit hitInfo, _interactDistance, _layerMask);
        if (hit && hitInfo.collider.gameObject.TryGetComponent(out Interactable interactObj))
        {
            
            _playerUI.SetText(interactObj.InteractText);
            if (_inputManager.IsInteractPressed())
            {
                interactObj.BaseInteract();
            }

        }
    }
    #endregion
}
