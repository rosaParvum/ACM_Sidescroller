using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    Animator selfAnim;
    public GameObject Bullet;

    public float currentAngle = 0.0f;
    public float direction;
    void Start () {
        selfAnim = gameObject.GetComponent<Animator>();
    }
    
    //WHAT THE FUCK ARE THESE ARGUMENTS???
    //WHY THE FUCK IS THERE A QUESTION MARK
    //WHY IS THE VALUE NULL

    // update: i fucking nuked that shit and all's good in the world
    public void fire() {
        //if (brot==null) {brot = new Quaternion(0.0f,0.0f,0.0f,0.0f);}
        if(selfAnim){selfAnim.SetTrigger("Fire");}
        GameObject bulletSpawned = Instantiate(Bullet, transform.position, Quaternion.Euler(0.0f,direction,currentAngle));
    }
}
 