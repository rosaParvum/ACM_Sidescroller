using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TentacleController : MonoBehaviour {
    public UnityEvent hit;
    public UnityEvent die;
    public int health;
    public float speed;
    [HideInInspector]
    public spawner spawnColumn;

    // Start is called before the first frame update
    void Start() {
        
    }

    void Update() {
        transform.Translate(new Vector3(speed*Time.deltaTime,0.0f,0.0f));
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
        Destroy(Instantiate(wound,transform.position,transform.rotation), 1);
    }

    public void Spawn() {
        
    }
}
