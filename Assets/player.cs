using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour {
    public float speed;
    [Space(20)]
    public float upBound;
    public float lowerBound;
    
    Animator playerAnim;

    // Start is called before the first frame update
    void Start() {
        playerAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetAxisRaw("Vertical")>0 && transform.position.y < upBound) {
            print(transform.position.y);
            playerAnim.SetBool("Move", true);
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        } else if (Input.GetAxisRaw("Vertical")<0 && transform.position.y > lowerBound) {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            playerAnim.SetBool("Move", true);
        } else {
            playerAnim.SetBool("Move", false);
        }
    }
}
