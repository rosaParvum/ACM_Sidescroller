using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerColorSet : MonoBehaviour
{
    bool isPicking = true;
    Color shipColor;

    // Start is called before the first frame update
    void Start()
    {
        ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("shipColor", "828282"), out shipColor);
        print (shipColor);
        if (gameObject.GetComponent<player>()) {
            gameObject.GetComponent<SpriteRenderer>().material.color = shipColor;
            isPicking = false;
        }
    }

    public void loadMenu() {
        FindObjectOfType<GameManager>().loadScene("menu");
    }

    public void ChangeColor() {
        shipColor = FindObjectOfType<FlexibleColorPicker>().color;
        gameObject.GetComponent<Image>().material.color = shipColor;
    }

    public void SaveColor() {
        PlayerPrefs.SetString("shipColor", ColorUtility.ToHtmlStringRGBA(shipColor));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
