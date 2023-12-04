using Assets.Scripts.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Batery : Interactable
{
    #region PRIVATE_PROPERTIES
    [SerializeField] private GameObject _flashlight;
    [SerializeField] private int _power;
    #endregion
    #region PUBLIC_METHODS
    protected override void Interact()
    {
        Flashlight flashlight = _flashlight.GetComponent<Flashlight>();
        flashlight.AddBattery(_power);
        gameObject.SetActive(false);
    }
    #endregion
}

