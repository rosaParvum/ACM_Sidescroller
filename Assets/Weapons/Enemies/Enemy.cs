using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy:ScriptableObject {
    public GameObject prefab;
    public float frequency;
    public bool special;

    public GameObject Spawn(spawner[] spawners) {
        GameObject spawned = null;
        spawner chosen = spawners[Random.Range(0,spawners.Length)];
        spawned = chosen.Spawn(prefab);
        if(spawned!=null){
            spawned.GetComponent<EnemyAI>().spawnColumn = chosen;
            return spawned;
        } else {
            return null;
        }
    }
    public void SpecialSpawn(spawner spawnpoint) {
        spawnpoint.Spawn(prefab);
    }
}