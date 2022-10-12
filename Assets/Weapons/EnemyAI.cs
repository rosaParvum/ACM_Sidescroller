using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float fireSpeed;
    public GameObject bullet;

    void Start() {
        StartCoroutine(ShootClock());
    }
    IEnumerator ShootClock() {
        while (true) {
            GameObject bulletSpawned = Instantiate(bullet, transform.position, new Quaternion(0.0f,0.0f,0.0f,0.0f));
            bulletSpawned.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(fireSpeed);
        }
    }
}
