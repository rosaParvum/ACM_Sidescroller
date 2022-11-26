using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class bullet : MonoBehaviour
{
    public float velocity;
    public float damage;
    public UnityEvent onSpawn;
    Rigidbody2D bulletPhys;
    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, 3.0f);
        bulletPhys = gameObject.GetComponent<Rigidbody2D>();
        bulletPhys.AddForce(transform.right*velocity);
    }


    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag != gameObject.tag && col.gameObject.tag != "Untagged" && !col.gameObject.name.Contains("Bullet") && !col.gameObject.name.Contains("Worm")) {
            switch (col.gameObject.tag) {
                case "Player":
                    //print(col.gameObject);
                    if(!col.gameObject.GetComponentInChildren<shipAnimStats>().inv) {
                        player pl = col.gameObject.GetComponent<player>();
                        pl.expend(damage);
                        pl.hit.Invoke();
                        Destroy(gameObject);
                    }
                    break;
                case "Enemy":
                    //print(col.gameObject);
                    if (col.GetComponent<EnemyAI>()) {col.GetComponent<EnemyAI>().hit.Invoke();}
                    if (col.GetComponent<TentacleController>()) {col.GetComponent<TentacleController>().hit.Invoke();}
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
