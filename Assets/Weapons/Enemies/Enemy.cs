using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy:ScriptableObject {
    public GameObject prefab;
    public float frequency;

    public GameObject Spawn(spawner[] spawners, string pos = "random") {
        GameObject spawned = null;
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
                Debug.Log(pos);
                spawned = spawners[0].Spawn(prefab);
                if(spawned!=null){spawned.GetComponent<EnemyAI>().spawnColumn = spawners[0];}
                return spawned;
            case "mid":
                Debug.Log(pos);
                spawned = spawners[1].Spawn(prefab);
                if(spawned!=null){spawned.GetComponent<EnemyAI>().spawnColumn = spawners[1];}
                return spawned;
            case "bot":
                Debug.Log(pos);
                spawned = spawners[2].Spawn(prefab);
                if(spawned!=null){spawned.GetComponent<EnemyAI>().spawnColumn = spawners[2];}
                return spawned;
        }
        return null;
    }
}