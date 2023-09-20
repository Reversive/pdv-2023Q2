using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCamera : MonoBehaviour
{
    #region PUBLIC_PROPERTIES
    [SerializeField] private Transform _mirrorCamera;
    #endregion

    #region UNITY_METHODS
    private void Update()
    {
        transform.position = _mirrorCamera.position;
    }
    #endregion
}
