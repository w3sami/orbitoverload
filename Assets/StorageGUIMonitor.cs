using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;
using RoboRyanTron.Unite2017.Variables;
using UnityEngine.UI;

public class StorageGUIMonitor : MonoBehaviour {


    public Text text;
    public FloatVariable scrapStored;
    public FloatVariable totalStorage;

    void Start () {
        UpdateText();
	}

    public void UpdateText()
    {
        text.text = "Scrap: " + scrapStored.Value.ToString() + "/" + totalStorage.Value.ToString();

    }



}
