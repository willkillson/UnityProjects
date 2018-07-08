using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform _enemyPreFab;
    public Transform _spawnPoint; 
    public Text waveCountDownText;

    public float timeBetweenEnemies = 3.0f;
    public float timeBetweenWaves = 5.0f;
    private float _countdowntimer = 2.0f;

    private int _waveIndex = -1;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (_countdowntimer <= 0)
        {
            // SpawnWave();
            StartCoroutine(SpawnWave());
            _countdowntimer = timeBetweenWaves;
        }
        _countdowntimer -= 1 * Time.deltaTime;
        if(_waveIndex>= 100)
        {
            _waveIndex = 0;
        }
        waveCountDownText.text = Mathf.Floor(_countdowntimer+1).ToString();
       
    }

    IEnumerator SpawnWave()
    {
        //Debug.Log("Spawning wave " + _waveIndex);
        _waveIndex++;
        for (int i = 0;i<= _waveIndex;i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
      //  return;
    }

    void SpawnEnemy()
    {

        Instantiate(_enemyPreFab, _spawnPoint.position, _spawnPoint.rotation);
    }
}
