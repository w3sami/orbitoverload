using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleScript : MonoBehaviour {

	void Start () {
		
	}
	
    void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collider " + collision.collider + " hit");
    }
}
