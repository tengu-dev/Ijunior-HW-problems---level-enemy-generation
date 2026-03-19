using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    public Enemy Spawn()
    {
        var enemy = Instantiate(_enemyPrefab);
        enemy.transform.position = transform.position;
        enemy.gameObject.SetActive(true);
        return enemy;
    }

    private void OnValidate()
    {
        if (_enemyPrefab == null)
            throw new System.ArgumentNullException(nameof(_enemyPrefab));
    }
}
