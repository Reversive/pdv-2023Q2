using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    #region PRIVATE_PROPERTIES
    private static PageManager _instance;
    private int _collectedPages;
    #endregion
    #region PUBLIC_PROPERTIES
    public static PageManager Instance { get { return _instance; } }
    public int CollectedPages
    {
        get { return _collectedPages; }
        set { _collectedPages = value; }
    }
    #endregion

    #region UNITY_METHODS
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);
    }
    private void Start()
    {
        _collectedPages = 0;
    }
    #endregion




}
