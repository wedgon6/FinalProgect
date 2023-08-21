using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _target;

    [SerializeField] private Enemy _enemyTypeOne;
    [SerializeField] private Enemy _enemyTypeTwo;
    [SerializeField] private Enemy _boss;

    [SerializeField] private Transform[] _spawnPointEneysTypeOne;
    [SerializeField] private Transform[] _spawnPointEneysTypeTwo;
    [SerializeField] private Transform _spawnPointBoss;

    public Player Target => _target;

    private void Awake()
    {
        InstantiatetEnemys(_enemyTypeOne, _spawnPointEneysTypeOne);
        InstantiatetEnemys(_enemyTypeTwo, _spawnPointEneysTypeTwo);
        InstantiatetEnemys(_boss, _spawnPointBoss);
    }

    private void Start()
    {
        //InstantiatetEnemys(_enemyTypeOne, _spawnPointEneysTypeOne);
        //InstantiatetEnemys(_enemyTypeTwo,_spawnPointEneysTypeTwo);
        //InstantiatetEnemys(_boss, _spawnPointBoss);
    }

    private void InstantiatetEnemys(Enemy enemy,Transform[] spawnPoint)
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Instantiate(enemy, spawnPoint[i]);
            enemy.Init(_target);
            Debug.Log("Вызван инит");
        }
    }

    private void InstantiatetEnemys(Enemy enemy, Transform spawnPoint)
    {
        Instantiate(enemy, spawnPoint);
        enemy.Init(_target);
    }
}
