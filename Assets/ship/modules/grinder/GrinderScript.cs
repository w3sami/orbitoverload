using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RoboRyanTron.Unite2017.Events;
using RoboRyanTron.Unite2017.Variables;

public class GrinderScript : MonoBehaviour {
    

    public FloatVariable scrapStored;
    public FloatVariable totalStorage;

    public GameEvent scrapGrabbed;
    
    private int maxdebris = 2000;
	
    private void OnTriggerStay(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(other.transform.position, 0.0f, LayerMask.GetMask("Grinders"), QueryTriggerInteraction.Collide);
        if (colliders.Length > 0)// && scrapStored.Value < totalStorage.Value)
        {
            GrindJunk(other.gameObject, other.GetComponent<Minerals>().minerals);
        }
    }

    private void GrindJunk(GameObject junk, Mineral[] minerals)
    {
        Destroy(junk);
        scrapGrabbed.Raise(minerals);
    }

}
