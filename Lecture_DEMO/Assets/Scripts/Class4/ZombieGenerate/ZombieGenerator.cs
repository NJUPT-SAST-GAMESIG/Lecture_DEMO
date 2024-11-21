using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ZombieGenerator : MonoBehaviour
{
    public Transform[] spawnPoints = new Transform[5];
    private GameObject _zombiePrefab;
    [SerializeField] private Slider waveSlider;
    private Transform _zombieParent; 
    private float lastGenerateTime = 0;
    public float generateCD = 6;
    private bool isWave = false;
    private void Start()
    {
        _zombiePrefab = Resources.Load<GameObject>("ZombiesPrefab/Zombie");
        _zombieParent = GameObject.Find("Canvas/Zombies").transform;
        waveSlider.onValueChanged.AddListener(StartZombieWave);
    }

    private void Update()
    {
        waveSlider.value += Time.deltaTime/120;
        if(!(Time.time > generateCD + lastGenerateTime))
            return;
        lastGenerateTime = Time.time;
        GenerateZombies(Random.Range(0,5));
    }

    public void GenerateZombies(int pointIndex)
    {
        GameObject zombie = Instantiate(_zombiePrefab,_zombieParent);
        zombie.transform.position = spawnPoints[pointIndex].position;
    }

    private void StartZombieWave(float value)
    {
        if(value < 0.4f)
            return;
        if(isWave)
            return;
        StartCoroutine(GenerateZombieWave(10));
        isWave = true;
    }

    private IEnumerator GenerateZombieWave(int zombieNum)
    {
        int tempNum = 0;
        while (tempNum < zombieNum)
        {
            yield return new WaitForSeconds(1.5f);
            GenerateZombies(Random.Range(0,5));
            tempNum++;
        }
    }
}