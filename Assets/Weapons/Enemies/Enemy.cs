using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy:ScriptableObject {
    public GameObject prefab;
    public float frequency;

    public void Spawn(spawner[] spawners, string pos = "random") {
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
                spawners[0].Spawn(prefab);
                break;
            case "mid":
                spawners[1].Spawn(prefab);
                break;
            case "bot":
                spawners[2].Spawn(prefab);
                break;
        }
    }
}