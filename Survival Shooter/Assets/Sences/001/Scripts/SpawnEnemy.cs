using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float SpawnTime = 3;
    private float Timer = 0;

    void Start()
    {
        InvokeRepeating("ACC", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= SpawnTime)
        {
            Timer -= SpawnTime;
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject.Instantiate(EnemyPrefab, transform.position, transform.rotation);
    }

    void ACC()
    {
        SpawnTime -= 0.05f;
    }
}
