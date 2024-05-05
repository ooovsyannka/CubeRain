using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _maxSize;

    public static Pool Instance;

    private List<GameObject> _pools = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(Instance);
    }

    private void Start()
    {
        for (int i = 0; i < _maxSize; i++)
        {
            GameObject prefab = Instantiate(_prefab);
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
