using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class shipAnimStats : MonoBehaviour {
    public bool dodgeHidden;
    public bool dodging;
    public bool inv;

    public void startDodge() {
        dodging = true;
    }

    public void stopDodge() {
        dodging = false;
    }

    public void startInv() {
        inv = true;
    }
    public void stopInv() {
        inv = false;
    }

    public void startHide() {
        inv = false;
    }

    public void stopHide() {
        inv = false;
    }

}
