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
    

    void Start() {
        StartCoroutine(ShootClock());
    }

    public void Fire() {
        GameObject bulletSpawned = Instantiate(bullet, transform.position, new Quaternion(0.0f,0.0f,0.0f,0.0f));
        bulletSpawned.transform.parent = gameObject.transform;
    }

    public void gotHit() {
        health -= 1;
        //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh
        if (health == 0) {
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
