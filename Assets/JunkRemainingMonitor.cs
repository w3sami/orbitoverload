using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Variables;
using RoboRyanTron.Unite2017.Events;
using UnityEngine.UI;

public class JunkRemainingMonitor : MonoBehaviour {

    public Text text;
    private int debriscount = 0;

    // Called from GameEventListener component
    public void OnSatelliteSpawned()
    {
        debriscount++;
        text.text = "Debris: " + debriscount;
    }

    // Called from GameEventListener component
    public void OnJunkRemoved()
    {
        debriscount--;
        text.text = "Debris: " + debriscount;
    }
}
