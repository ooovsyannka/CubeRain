using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _delaySpawn ;

    private void Awake()
    {
        InvokeRepeating(nameof(Spawn), 0, _delaySpawn);
    }

    private void Spawn()
    {
        GameObject cube = Pool.Instance.GetPoolObject();

        if (cube != null)
        {
            cube.transform.position = GetrandomSpawnPosition();
            cube.SetActive(true);
            cube.GetComponent<Renderer>().material.color = Color.cyan;
            cube.GetComponent<Cube>().SetCollisionValue();
        }
    }

    private Vector3 GetrandomSpawnPosition()
    {
        float randomPositionX = Random.Range(0, _spawnPosition.localScale.x);
        float randomPositionZ = Random.Range(0, _spawnPosition.localScale.z);
        float maxHeight = 20;
        float height = _spawnPosition.position.y + maxHeight;

        return new Vector3(randomPositionX, height, randomPositionZ);
    }
}
