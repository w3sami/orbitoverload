using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returner : MonoBehaviour {

    public spawnValues values;

	// Use this for initialization
	void OnTriggerEnter(Collider collider)
    {
        var p = collider.transform.position;
        collider.transform.position = new Vector3(values.x, collider.transform.position.y, collider.transform.position.z);
    }
}
