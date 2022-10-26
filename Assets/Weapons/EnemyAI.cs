using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    [Header("Stats")]
    public float fireSpeed;
    public GameObject bullet;
    public int health;
    [Space(20)]
    [Header("Reaction Events")]
    public UnityEvent shoot;
    public UnityEvent hit;
    GameObject frame;
    [HideInInspector]
    public spawner spawnColumn;
    

    void Start() {
        spawnColumn.canSpawn=false;
        StartCoroutine(ShootClock());
        frame = GameObject.FindGameObjectWithTag("Frame");
    }

    public void Fire() {
        GameObject bulletSpawned = Instantiate(bullet, transform.position, new Quaternion(0.0f,0.0f,0.0f,0.0f));
        bulletSpawned.transform.parent = transform.parent.parent.parent;
    }

    public void gotHit() {
        health -= 1;
        //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh
        if (health == 0) {
            spawnColumn.canSpawn=true;
            Destroy(gameObject);
        }
    }

    IEnumerator ShootClock() {
        while (true) {
            shoot.Invoke();
            yield return new WaitForSeconds(fireSpeed);
        }
    }
}
