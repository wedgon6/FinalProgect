using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBattlegroundCold : MonoBehaviour
{
    [SerializeField] private Player _target;

    [SerializeField] private GameObject _enemyTypeOne;
    [SerializeField] private GameObject _enemyTypeTwo;
    [SerializeField] private GameObject _boss;

    [SerializeField] private Transform[] _spawnPointEneysTypeOne;
    [SerializeField] private Transform[] _spawnPointEneysTypeTwo;
    [SerializeField] private Transform _spawnPointBoss;

    [SerializeField] private GameObject _teleportPosition;

    public Player Target => _target;

    private void Awake()
    {
        InstantiatetEnemys(_enemyTypeOne, _spawnPointEneysTypeOne);
        InstantiatetEnemys(_enemyTypeTwo, _spawnPointEneysTypeTwo);
        InstantiatetEnemys(_boss, _spawnPointBoss);
    }

    private void InstantiatetEnemys(GameObject template,Transform[] spawnPoint)
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Enemy enemy = Instantiate(template, spawnPoint[i]).GetComponent<Enemy>();
            enemy.Init(_target);
            Debug.Log("Вызван инит");
        }
    }

    private void InstantiatetEnemys(GameObject template, Transform spawnPoint)
    {
        Enemy enemy = Instantiate(template, spawnPoint).GetComponent<Enemy>();
        enemy.Init(_target);
        Boss boss = enemy.GetComponent<Boss>();
        boss.GetTeleportPosition(_teleportPosition);
    }
}
