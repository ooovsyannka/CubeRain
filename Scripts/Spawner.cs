using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _delaySpawn ;
    [SerializeField] private Pool _pool ;

    private void Awake()
    {
        InvokeRepeating(nameof(Spawn), 0, _delaySpawn);
    }

    private void Spawn()
    {
        GameObject cube = _pool.GetPoolObject();

        if (cube != null)
        {
            cube.transform.position = GetrandomSpawnPosition();
            cube.SetActive(true);
            cube.GetComponent<Renderer>().material.color = Color.cyan;
            cube.GetComponent<Cube>().ResetCollisionValue();
        }
    }

    private Vector3 GetrandomSpawnPosition()
    {
        float division = 2f;
        float randomPositionX = Random.Range(0, _spawnPosition.localScale.x / division);
        float randomPositionZ = Random.Range(0, _spawnPosition.localScale.z / division);
        float maxHeight = 20;
        float height = _spawnPosition.position.y + maxHeight;

        return new Vector3(randomPositionX, height, randomPositionZ);
    }
}
