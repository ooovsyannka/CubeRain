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
            GameObject cube = Instantiate(_cube.gameObject);
            _pools.Add(cube);
            cube.SetActive(false);
        }
    }

    public GameObject GetPoolObject()
    {
        foreach (GameObject cube in _pools)
        {
            if(cube.activeInHierarchy == false)
            {
                return cube;
            }
        }

        return null;
    }
}