using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Variables; // todo remove namespace

public class camera : MonoBehaviour {

    public FloatVariable shipX;
    public FloatVariable shipY;
    public spawnValues values;
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(shipX.Value, shipY.Value, transform.position.z);
        Camera.main.orthographicSize = 100 + shipY.Value * 200 / values.height;
    }
}
