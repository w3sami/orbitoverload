using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinderScript : MonoBehaviour {

    // ADDED FROM PROTOTYPE
    //public ShipController shipScript;
    
	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(other.transform.position, 0.0f, LayerMask.GetMask("Grinders"), QueryTriggerInteraction.Collide);
        if (colliders.Length > 0)
        {
            GrabJunk(other.gameObject);
        }
    }

    private void GrabJunk(GameObject junk)
    {
        // ADDED FROM PROTOTYPE
        //shipScript.AddScrap(10);

        Destroy(junk);
    }

}
