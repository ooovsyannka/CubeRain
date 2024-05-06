using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private int _maxSize;

    private List<GameObject> _pools = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < _maxSize; i++)
        {
            GameObject prefab = Instantiate(_cube.gameObject);
            _pools.Add(prefab);
            prefab.SetActive(false);
        }
    }

    public GameObject GetPoolObject()
    {
        foreach (GameObject prefab in _pools)
        {
            if(prefab.activeInHierarchy == false)
            {
                return prefab;
            }
        }

        return null;
    }
}