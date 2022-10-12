using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class player : MonoBehaviour {
    public float speed;
    [Space(20)]
    [Header("Set Boundaries")]
    public float upBound;
    public float lowerBound;
    
    Animator playerAnim;
    Animator physAnim;

    [Space(20)]
    [Header("Reaction Events")]
    public UnityEvent hit;
    public UnityEvent shoot; 
    
    bool canMove = true;

    // Start is called before the first frame update
    void Start() {
        playerAnim = transform.GetChild(0).gameObject.GetComponent<Animator>();
        physAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        float direction = Input.GetAxisRaw("Vertical");
        if (direction>0 && transform.position.y < upBound &&canMove) {
            physAnim.SetFloat("Direction", direction);
            playerAnim.SetBool("Move", true);
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        } else if (direction<0 && transform.position.y > lowerBound&&canMove) {
            physAnim.SetFloat("Direction", direction);
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            playerAnim.SetBool("Move", true);
        } else {
            playerAnim.SetBool("Move", false);
            physAnim.SetFloat("Direction", 0);
        }

        if (Input.GetButtonDown("Fire1")) {
            shoot.Invoke();
        }
        if (Input.GetButtonDown("Fire2")) {
            hit.Invoke();
        }
    }

    public IEnumerator gotHit() {
        canMove = false;
        yield return new WaitForSeconds(1.0f);
        canMove = true;
    }
}
