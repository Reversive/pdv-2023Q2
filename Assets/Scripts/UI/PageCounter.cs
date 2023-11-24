using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageCounter : MonoBehaviour
{
    #region PRIVATE_PROPERTIES
    private PageManager _pageManager;
    [SerializeField] private GameObject _counter;
    #endregion

    #region UNITY_METHODS
    private void Start()
    {
        _pageManager = GetComponent<PageManager>();
    }

    private void Update()
    {
        _counter.GetComponent<Text>().text = _pageManager.CollectedPages + "/8";
    }
    #endregion
}
