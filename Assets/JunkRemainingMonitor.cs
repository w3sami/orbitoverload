using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Variables;
using RoboRyanTron.Unite2017.Events;
using UnityEngine.UI;

public class JunkRemainingMonitor : MonoBehaviour {

    public spawnValues SatelliteValues;

    public Text text;

    //private int previousCount;
    //private int maxSpawns;

	void Start () {
        //previousCount = maxSpawns = SatelliteValues.maxSpawns;
        //UpdateText();
	}
	
	void Update () {
        
        /*
        if (previousCount != SatelliteValues.spawnables.Length)
        {
            previousCount = SatelliteValues.spawnables.Length;
            UpdateText();
        }*/
    }

    private void UpdateText()
    {
        //int percentage = SatelliteValues.spawnables.Length*100 / maxSpawns;
        //text.text = percentage + "% junk remaining";
    }

    
    // Called from GameEventListener component
    public void OnJunkRemoved()
    {
        int debriscount = GameObject.FindGameObjectsWithTag("Debris").Length;
        text.text = "Debris: " + debriscount;
        
        //text.text = "Debris: " + SatelliteValues.maxSpawns;
    }
}
