using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuSetup : MonoBehaviour
{
    public GameObject gmPrefab;
    GameManager gm;
    public Button play;
    public Button ship;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<GameManager>()) {
            gm = FindObjectOfType<GameManager>();
        } else {
            gm = Instantiate(gmPrefab).GetComponent<GameManager>();
        }
        play.onClick.AddListener(delegate {gm.loadScene("pew pew");});
        ship.onClick.AddListener(delegate {gm.loadScene("ship");});
    }
}
