using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

public class BossController : MonoBehaviour {
    Transform thePlayer;
    Transform eye;
    public GameObject wormBarrage;

    #if UNITY_EDITOR // conditional compilation is not mandatory
    [ButtonMethod]
    private void Laser() {
        StartCoroutine(LaserAttack());
    }
    #endif

    void Start() {
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        eye = transform.GetChild(0).GetChild(0).GetChild(0);
    }

    void Update() {
        eye.right = -(thePlayer.position - eye.transform.position);
    }

    IEnumerator LaserAttack() {
        Transform laser = transform.GetChild(0).GetChild(0).GetChild(1);
        laser.rotation = eye.rotation;
        laser.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(4);
        laser.gameObject.SetActive(false);
        Instantiate(wormBarrage,laser.position,laser.rotation).transform.eulerAngles.SetZ(-laser.eulerAngles.z);
    }

    public void demoOver() {
        FindObjectOfType<GameManager>().loadScene("demoOver");
    }
}

