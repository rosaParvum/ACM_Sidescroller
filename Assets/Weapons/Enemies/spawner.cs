using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public bool canSpawn=true;

    public GameObject Spawn(GameObject prefab) {
        if (canSpawn) {
            return Instantiate(prefab, transform);
        } else {
            return null;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag=="Enemy") {canSpawn = false;}
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.tag=="Enemy") {canSpawn = true;}
    }
}
