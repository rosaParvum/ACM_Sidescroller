using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class bullet : MonoBehaviour
{
    public float velocity;
    public UnityEvent onSpawn;
    Rigidbody2D bulletPhys;
    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, 3.0f);
        bulletPhys = gameObject.GetComponent<Rigidbody2D>();
        bulletPhys.AddForce(Vector2.right*velocity);
    }


    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag != gameObject.tag) {
            switch (col.gameObject.tag) {
                case "Player":
                    if(!col.gameObject.GetComponentInChildren<shipAnimStats>().inv) {col.gameObject.GetComponent<player>().hit.Invoke();Destroy(gameObject);}
                    break;
                case "Enemy":
                    col.gameObject.GetComponent<EnemyAI>().hit.Invoke();
                    Destroy(gameObject);
                    break;
            }
        }
    }

    public void LookAtPlayer() {
        transform.right = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
    }
}
