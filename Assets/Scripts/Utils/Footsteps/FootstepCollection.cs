using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New footstep collection", menuName = "Create new footstep collection")]
public class FootstepCollection : ScriptableObject
{
    public List<AudioClip> footstepSounds = new List<AudioClip>();

}
