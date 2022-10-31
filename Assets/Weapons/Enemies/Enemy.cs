using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy:ScriptableObject {
    public GameObject prefab;
    public float frequency;

    public GameObject Spawn(spawner[] spawners, string pos = "random") {
        GameObject spawned = null;
        spawner chosen = spawners[0];
        Back:
        switch (pos) {
            case "random":
                int posNo = Random.Range(1,4);
                switch (posNo) {
                    case 1: pos = "top"; break;
                    case 2: pos = "mid"; break;
                    case 3: pos = "bot"; break;
                }
                goto Back;
            case "top":
                chosen = spawners[0];
                break;
            case "mid":
                chosen = spawners[1];
                return spawned;
            case "bot":
                chosen = spawners[2];
                break;
        }
        spawned = chosen.Spawn(prefab);
        if(spawned!=null){
            spawned.GetComponent<EnemyAI>().spawnColumn = chosen;
            return spawned;
        } else {
            goto Back;
        }
    }
}