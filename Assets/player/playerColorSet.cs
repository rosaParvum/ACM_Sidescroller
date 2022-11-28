using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class playerColorSet : MonoBehaviour
{
    bool isPicking = true;
    Color shipColor;
    public Material playerMat;

    // Start is called before the first frame update
    void Start()
    {
        shipColor = LoadColor();
        //print (shipColor);
        if (gameObject.GetComponent<player>()) {
            playerMat.color = shipColor;
        } else {
            FindObjectOfType<FlexibleColorPicker>().color = shipColor;
        }
    }

    public void loadMenu() {
        FindObjectOfType<GameManager>().loadScene("menu");
    }

    public void ChangeColor() {
        shipColor = FindObjectOfType<FlexibleColorPicker>().color;
        gameObject.GetComponent<Image>().material.SetColor("_Color", shipColor);
    }

    public void Confirm() {
        SaveColor(shipColor);
    }

    public void SaveColor (Color save) {
        using(StreamWriter writetext = new StreamWriter(Application.streamingAssetsPath+"/PlayerColor.dat")) {
                Debug.Log("SAVED #"+ColorUtility.ToHtmlStringRGB(save));
                writetext.WriteLine("#"+ColorUtility.ToHtmlStringRGB(save));
        }
    }

    public Color LoadColor() {
        Color retCol = new Color(130,130,130);
        if (System.IO.File.Exists(Application.streamingAssetsPath + "/PlayerColor.dat")) {
		    //ColorUtility.TryParseHtmlString(File.ReadAllText(Application.streamingAssetsPath + "/PlayerColor.dat"),out retCol);
            using(StreamReader readtext = new StreamReader(Application.streamingAssetsPath+"/PlayerColor.dat")) {
                string readText = readtext.ReadLine();
                Debug.Log("LOADED" + readText);
                ColorUtility.TryParseHtmlString(readText, out retCol);
            }
        } else {
            SaveColor(retCol);
        }
        return retCol;
    }
}