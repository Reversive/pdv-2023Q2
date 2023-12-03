using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    #region PRIVATE_PROPERTIES
    private static PageManager _instance;
    private int _collectedPages;
    private MenuManager _menuManager;
    [SerializeField] private List<GameObject> _pages;
    [SerializeField] private Animator _transition;
    #endregion
    #region PUBLIC_PROPERTIES
    public static PageManager Instance { get { return _instance; } }
    public int CollectedPages
    {
        get { return _collectedPages; }
        set { _collectedPages = value; }
    }
    #endregion

    IEnumerator LoadGameWin()
    {
        _transition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _collectedPages = 0;
        _menuManager.LoadWinGameScene();

    }

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
        _menuManager = GetComponent<MenuManager>();
        List<int> activated = new List<int>();
        while(activated.Count < 8)
        {
            int rand = Random.Range(0, _pages.Count);
            if (!activated.Contains(rand))
            {
                activated.Add(rand);
                _pages[rand].gameObject.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if(_collectedPages == 1)
        {
            StartCoroutine(LoadGameWin());
        }
    }
    #endregion
}
