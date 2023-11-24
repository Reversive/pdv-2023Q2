using Assets.Scripts.Strategy;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Page : Interactable
{
    #region PRIVATE_PROPERTIES
    [SerializeField] private GameObject _collectTxtObject;
    [SerializeField] private TextMeshProUGUI _uiCounter;
    [SerializeField] private TextMeshProUGUI _collectText;
    [SerializeField] private AudioSource _audioSource;
    private bool _isInRange;
    private PageManager _pageManager;
    #endregion

    #region UNITY_METHODS
    private void Start()
    {
        _pageManager = PageManager.Instance;
    }
    #endregion

    #region PUBLIC_METHODS
    protected override void Interact()
    {
        _pageManager.CollectedPages++;
        _collectText.text = _pageManager.CollectedPages + "/8 Pages";
        _uiCounter.text = _pageManager.CollectedPages + "/8";
        _collectTxtObject.SetActive(true);
        _audioSource.Play();
        gameObject.SetActive(false);
    }
    #endregion
}
