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
	
    void Start () {
        
        // TODO: This might be better elsewhere
        scrapStored.SetValue(0);
    }

    void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(other.transform.position, 0.0f, LayerMask.GetMask("Grinders"), QueryTriggerInteraction.Collide);
        if (colliders.Length > 0 && scrapStored.Value < totalStorage.Value)
        {
            GrindJunk(other.gameObject);
        }
    }

    private void GrindJunk(GameObject junk)
    {

        Destroy(junk);

        scrapStored.Value += 7;
        if (scrapStored.Value > totalStorage.Value) scrapStored.Value = totalStorage.Value;

        scrapGrabbed.Raise();

    }

}
