using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Variables;

public class compass : MonoBehaviour {

    public Transform target;
    public FloatVariable shipX;
    public FloatVariable shipY;

    // Update is called once per frame
    void Update () {
        transform.up = (target.position - new Vector3(shipX.Value, shipY.Value, 0)).normalized;
	}
}
