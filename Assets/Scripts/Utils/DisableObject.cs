using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    #region PRIVATE_PROPERTIES
    [SerializeField] private GameObject _object;
    [SerializeField] private float _activeTime;
    #endregion

    #region UNITY_METHODS
    private void Update()
    {
        if(_object.activeSelf)
        {
            StartCoroutine(Disable());
        }
    }
    #endregion

    #region ENUMERATOR
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(_activeTime);
        _object.SetActive(false);
    }
    #endregion
}
