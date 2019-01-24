using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleScript : MonoBehaviour {

    public float durability = 3000;
    public ParticleSystem destructionExplosion;

    void Start () {
		
	}
	
    void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("magnitude: " + collision.collider.bounds.size.magnitude + " - velocity: " + collision.relativeVelocity);
        //Debug.Log("Impact: " + collision.relativeVelocity*collision.collider.bounds.size.magnitude);

        float impact = (collision.relativeVelocity * collision.collider.bounds.size.magnitude).magnitude;
        Debug.Log("Impact: " + impact);

        if (impact > durability) Explode();

        //Debug.Log("Collider " + collision.collider + " hit");
    }

    private void Explode()
    {
        this.gameObject.SetActive(false);
        Instantiate(destructionExplosion, transform.position, Quaternion.identity);
    }
}
