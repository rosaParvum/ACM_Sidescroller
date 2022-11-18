using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    [Header("Stats")]
    public float fireSpeed;
    public int health;
    [Space(20)]
    [Header("Reaction Events")]
    public UnityEvent shoot;
    public UnityEvent hit;
    GameObject frame;
    [HideInInspector]
    public spawner spawnColumn;
    gun myGun;
    Transform thePlayer;
    

    void Start() {
        myGun = transform.GetChild(0).GetComponent<gun>();
        thePlayer = GameObject.Find("Player").transform;
        spawnColumn.canSpawn=false;
        StartCoroutine(ShootClock());
        frame = GameObject.FindGameObjectWithTag("Frame");

        shoot.Invoke();
    }

    void Update() {
        myGun.transform.right = thePlayer.position - myGun.transform.position;
        myGun.currentAngle = myGun.transform.eulerAngles.z;
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
