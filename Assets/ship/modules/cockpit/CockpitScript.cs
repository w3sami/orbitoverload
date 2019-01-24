using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

public class CockpitScript : MonoBehaviour {

    public GameEvent cockpitDestroyed;

    void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnDisable()
    {
        cockpitDestroyed.Raise();
    }

    private void OnDestroy()
    {
        cockpitDestroyed.Raise();
    }
}
