using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemyies : MonoBehaviour
{
    [SerializeField] private Player _target;

    [SerializeField] private List<EnemyTempalte> _enemies;

    [SerializeField] private GameObject _teleportPosition;

    public Player Target => _target;

    private void Awake()
    {
        InstantiatetEnemys();
    }

    private void InstantiatetEnemys()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            for (int j = 0; j < _enemies[i].SpawnPoints.Length; j++)
            {
                Enemy enemy = Instantiate(_enemies[i].Enemy, _enemies[i].SpawnPoints[j]);
                enemy.Init(_target);

                if (enemy.TryGetComponent<Boss>(out Boss boss))
                    boss.GetTeleportPosition(_teleportPosition);
            }
        }
    }
}

[System.Serializable]
public class EnemyTempalte
{
    public Enemy Enemy;
    public Transform[] SpawnPoints;
}
