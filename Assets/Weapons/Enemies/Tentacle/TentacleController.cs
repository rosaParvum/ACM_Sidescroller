using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TentacleController : MonoBehaviour {
    public UnityEvent hit;
    public UnityEvent die;
    public int health;
    public float speed;
    public float damage;
    [HideInInspector]
    public spawner spawnColumn;

    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject,12);
    }

    void Update() {
        transform.Translate(-transform.right*speed*Time.deltaTime);
    }

    public void gotHit() {
        health -= 1;
        //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh
        if (health == 0) {
            //spawnColumn.canSpawn=true;
            die.Invoke();
            Destroy(gameObject);
        }
    }

    public void wounded(GameObject wound) {
        Destroy(Instantiate(wound,transform.position,transform.rotation), 2);
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            col.GetComponent<player>().InvokeHit(damage);
        }
    }

    public void Spawn() {

    }
}
