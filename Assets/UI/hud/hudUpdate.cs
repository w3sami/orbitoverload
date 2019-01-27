using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RoboRyanTron.Unite2017.Variables;

public class hudUpdate : MonoBehaviour {

    public Image bar;
    public FloatVariable value;

    void Update()
    {
        bar.fillAmount = value.Value;
    }
}
