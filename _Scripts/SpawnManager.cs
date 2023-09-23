using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private GameObject _enemyContainer;
    private bool _isPlayerDead;
    [SerializeField] Transform[] _spawnPoints;


    private void Start()
    {
        StartCoroutine(SpawnRoutine());

    }

    IEnumerator SpawnRoutine()
    {
        while(_isPlayerDead == false)
        {
            int _randomZom = Random.Range(0, _enemyPrefab.Length);
            int positionToSpawn = Random.Range(0, _spawnPoints.Length);
            var pointToSpawnTo = _spawnPoints[positionToSpawn];

            GameObject newEnemy = Instantiate(_enemyPrefab[_randomZom], pointToSpawnTo.position, Quaternion.identity);
            yield return new WaitForSeconds(5);

            newEnemy.transform.parent = _enemyContainer.transform;
        }
    }



}
