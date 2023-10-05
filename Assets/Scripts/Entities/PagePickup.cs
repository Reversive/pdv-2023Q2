using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PagePickup : MonoBehaviour
{
    #region PRIVATE_PROPERTIES
    [SerializeField] private GameObject _collectTxtObject;
    [SerializeField] private GameObject _pageInteractText;
    [SerializeField] private Text _collectText;
    [SerializeField] private AudioSource _audioSource;
    private InputManager _inputManager;
    private PageManager _pageManager;
    private bool _isInRange;
    #endregion

    #region UNITY_METHODS
    private void Start()
    {
        _inputManager = InputManager.Instance;
        _pageManager = PageManager.Instance;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            _pageInteractText.SetActive(true);
            _isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            _pageInteractText.SetActive(false);
            _isInRange = false;
        }
    }

    private void Update()
    {
        if (_isInRange && _inputManager.IsInteractPressed())
        {
            _pageManager.CollectedPages++;
            _collectText.text = _pageManager.CollectedPages + "/8 Pages";
            _collectTxtObject.SetActive(true);
            _audioSource.Play();
            gameObject.SetActive(false);
            _isInRange = false;
            _pageInteractText.SetActive(false);
        }
    }
    #endregion
}
