using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceType : MonoBehaviour
{
    [SerializeField] private FootstepCollection _footstepCollection;

    public FootstepCollection FootstepCollection { get { return _footstepCollection; } }
}
