using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSwapper : MonoBehaviour
{
    #region PRIVATE_PROPERTIES
    private TerrainChecker _terrainChecker;
    private PlayerController _pc;
    private string _currentLayerName;
    [SerializeField] private FootstepCollection[] footstepCollections;
    #endregion

    #region UNITY_METHODS
    void Start()
    {
        _terrainChecker = new TerrainChecker();
        _pc = GetComponent<PlayerController>();
    }

    public void CheckLayers()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 3))
        {
            if (hit.transform.GetComponent<Terrain>() != null)
            {
                Terrain t = hit.transform.GetComponent<Terrain>();
                if (_currentLayerName != _terrainChecker.GetLayerName(transform.position, t))
                {
                    _currentLayerName = _terrainChecker.GetLayerName(transform.position, t);
                    foreach (FootstepCollection collection in footstepCollections)
                    {
                        if (_currentLayerName == collection.name)
                        {
                            _pc.SwapFootsteps(collection);
                        }
                    }
                }
            }
            if(hit.transform.GetComponent<SurfaceType>() != null)
            {
                FootstepCollection collection = hit.transform.GetComponent<SurfaceType>().FootstepCollection;
                _currentLayerName = collection.name;
                _pc.SwapFootsteps(collection);
            }
        }
    }

    #endregion
}
