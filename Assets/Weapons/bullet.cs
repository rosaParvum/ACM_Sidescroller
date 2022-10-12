using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    void Update (){
        transform.Translate(Vector3.right*Time.deltaTime*velocity, Space.World);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag != gameObject.tag) {
            switch (col.gameObject.tag) {
                case "Player":
                    col.gameObject.GetComponent<player>().hit.Invoke();
                    break;
                case "Enemy":
                    col.gameObject.GetComponent<EnemyAI>().hit.Invoke();
                    break;
            }
            Destroy(gameObject);
        }
    }
}
