using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrinderScript : MonoBehaviour {

    // ADDED FROM PROTOTYPE
    //public ShipController shipScript;
    public Text JunkRemainsText;

    private int maxdebris = 2000;
	
    void Start () {
        //var o = GameObject.FindGameObjectsWithTag("Debris");
        //maxdebris = o.Length;
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
        var o = GameObject.FindGameObjectsWithTag("Debris");
        float left = o.Length;
        JunkRemainsText.text = (left*100 / maxdebris).ToString() + "% junk remaining";
    }

}
