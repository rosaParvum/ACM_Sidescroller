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
    bool canCharge = true;
    

    // Start is called before the first frame update
    void Start() {
        playerAnim = transform.GetChild(0).gameObject.GetComponent<Animator>();
        physAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        float powerChange = 0.0f;
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

            //Idle recharge
            if (canCharge) {
                powerChange += rechargeRate/60;
            }
        }

        if (Input.GetButtonDown("Fire1") && canMove) {
            shoot.Invoke();
            powerChange -= 30;
        }
        power = Mathf.Clamp(power + powerChange, 0.0f, 100.0f);
        energyBar.value=power;

        if (power == 0) {
            StartCoroutine("overheat");
        }
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
}
