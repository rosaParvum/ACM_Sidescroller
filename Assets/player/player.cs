using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class player : MonoBehaviour {

    [Header("Stats")]
    public float health;
    public float speed;
    public float power;
    public float rechargeRate;
    public Slider energyBar;
    public float dodgeSpeed;
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
    public UnityEvent dodge;

    bool canMove = true;
    bool canCharge = true;                                                                                                                                                        
    float powerChange = 0.0f;
    bool moving; 
    shipAnimStats sAs;
    float baseSpeed;

    FixedJoystick stick;
    

    // Start is called before the first frame update
    void Start() {
        playerAnim = transform.GetChild(0).gameObject.GetComponent<Animator>();
        physAnim = gameObject.GetComponent<Animator>();
        sAs = gameObject.GetComponentInChildren<shipAnimStats>();
        stick = FindObjectOfType<FixedJoystick>();
        baseSpeed = speed;
        hit.AddListener(gotHit);
    }

    // Update is called once per frame
    void Update() {
        float direction = Input.GetAxisRaw("Vertical");
        if(stick){direction+=stick.Direction.y;}

        if (sAs.inv) {speed += 20.0f;}
        if (direction>0 && transform.position.y < upBound &&canMove) {
            physAnim.SetFloat("Direction", direction);
            playerAnim.SetBool("Move", true);
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
            moving = true;
        } else if (direction<0 && transform.position.y > lowerBound&&canMove) {
            physAnim.SetFloat("Direction", direction);
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            playerAnim.SetBool("Move", true);
            moving=true;
        } else {
            playerAnim.SetBool("Move", false);
            physAnim.SetFloat("Direction", 0);
            moving=false;
        }
        if (Input.GetButtonDown("Fire1") && canMove) {
            shoot.Invoke();
        }

        if (Input.GetButtonDown("Jump") && canMove) {
            dodge.Invoke();
        }

        speed = baseSpeed;
    }

    void FixedUpdate() {

        if (canCharge){//&& !moving) {
            powerChange += rechargeRate/60;
        }

        power = Mathf.Clamp(power + powerChange, 0.0f, 100.0f);
        energyBar.value=power;
        if (power == 0) {
            StartCoroutine("overheat");
        }
        powerChange = 0.0f;
    }

    IEnumerator overheat() {
        energyBar.gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(255.0f,0.0f,0.0f,255.0f);
        canMove = false;
        yield return new WaitForSeconds(2.0f);
        canMove = true;
        energyBar.gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(255.0f,255.0f,255.0f,255.0f);
    }

    public void gotHit() {
        canMove = false;
    }

    public void expend(float energy) {
        power -= energy;
    }

    public void InvokeShoot() {
        if (canMove) {
            shoot.Invoke();
        }
    }

    public void InvokeHit() {
        hit.Invoke();
    }

    public void InvokeDodge() {
        if (canMove) {
            dodge.Invoke();
        }
    }
}
