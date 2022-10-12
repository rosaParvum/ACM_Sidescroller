using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    Animator selfAnim;
    public GameObject Bullet;
    void Start () {
        selfAnim = gameObject.GetComponent<Animator>();
    }
    public void fire() {
        selfAnim.SetTrigger("Fire");
        GameObject bulletSpawned = Instantiate(Bullet, transform.position, new Quaternion(0.0f,0.0f,0.0f,0.0f));
        bulletSpawned.transform.parent = gameObject.transform;
    }
}
