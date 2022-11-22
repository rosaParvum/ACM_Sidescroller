using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    public void GameOver() {
        FindObjectOfType<GameManager>().loadScene("menu");
    }
}
