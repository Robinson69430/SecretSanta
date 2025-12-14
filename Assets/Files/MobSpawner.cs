using UnityEngine;
using System.Collections.Generic;

public class MobSpawner : MonoBehaviour
{
    public GameObject mobPrefab;
    public float spawnInterval = 3f;
    public int maxMobs = 10;
    public Vector2 spawnZoneSize = new Vector2(20f, 20f);

    private float nextSpawnTime;
    private List<GameObject> mobs = new List<GameObject>();
    public GameManager gm;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        mobs.RemoveAll(m => m == null);

        if (Time.time >= nextSpawnTime && mobs.Count < maxMobs)
        {
            SpawnMob();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnMob()
    {
        float randomX = Random.Range(-spawnZoneSize.x / 2, spawnZoneSize.x / 2);
        float randomY = Random.Range(-spawnZoneSize.y / 2, spawnZoneSize.y / 2);

        Vector3 spawnPos = new Vector3(
            transform.position.x + randomX,
            transform.position.y + randomY,
            -1f
        );

        GameObject mob = Instantiate(mobPrefab, spawnPos, Quaternion.identity);
        mobs.Add(mob);

        MobBehavior behavior = mob.GetComponent<MobBehavior>();
        if (behavior != null)
        {
            behavior.OnMobDestroyed += () =>
            {
                mobs.Remove(mob);
                gm.hit++;
                Debug.Log(gm.hit);
            };
        } 
    }



    
}