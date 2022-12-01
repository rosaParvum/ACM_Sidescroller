using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("waitNLoad");
    }

    IEnumerator waitNLoad() {
        yield return new WaitForSeconds(6);
        FindObjectOfType<GameManager>().loadScene("menu");
    }

}
