using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    private const float MinSpawnRate = 0.01f;

    [SerializeField] private List<Spawner> _spawners = new();
    [SerializeField, Min(MinSpawnRate)] private float _spawnRateSeconds = 2f;
    [SerializeField] private Transform _enemyTarget;

    private Coroutine _spawnCoroutine;

    private void OnEnable()
    {
        _spawnCoroutine = StartCoroutine(DirectNewEnemies(_spawnRateSeconds));
    }

    private void OnDisable()
    {
        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);
    }

    private void OnValidate()
    {
        if (_spawners == null)
            throw new System.ArgumentNullException();

        if (_enemyTarget == null)
            throw new System.ArgumentNullException();

        if (_spawners.Count == 0)
            Debug.LogError($"{nameof(_spawners)} is not set. Remove component or set {nameof(_spawners)}");
    }

    private IEnumerator DirectNewEnemies(float spawnRateSeconds)
    {
        while (true)
        {
            var await = new WaitForSeconds(spawnRateSeconds);
            int pickedSpawnerIndex = UserUtilities.GenerateRandomInt(0, _spawners.Count - 1);

            Enemy enemy = _spawners[pickedSpawnerIndex].Spawn();
            enemy.Move(_enemyTarget.position);
            yield return await;
        }
    }
}
