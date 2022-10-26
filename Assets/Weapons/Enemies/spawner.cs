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
}
