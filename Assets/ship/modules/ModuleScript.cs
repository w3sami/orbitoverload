using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleScript : MonoBehaviour {

    public float durability = 3000;
    private float maxDurability;
    public ParticleSystem destructionExplosion;
    public Transform healthBar;

    void Start () {
        maxDurability = durability;
        healthBar.localScale = new Vector3(0, 1, 1);
    }
	
    void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("magnitude: " + collision.collider.bounds.size.magnitude + " - velocity: " + collision.relativeVelocity);
        //Debug.Log("Impact: " + collision.relativeVelocity*collision.collider.bounds.size.magnitude);

        float impact = (collision.relativeVelocity * collision.collider.bounds.size.magnitude).magnitude;
        Debug.Log("Impact: " + impact);
        durability -= impact;
        if (durability < 0) Explode();
        else
        {
            var s = healthBar.localScale;
            s.x = durability / maxDurability;
            healthBar.localScale = s;
            var p = healthBar.localPosition;
            p.x = (1 - s.x) / -2;
            healthBar.localPosition = p;
            if (s.x > .3f)
            {
                StartCoroutine(hideBar());
            }
        }
        //Debug.Log("Collider " + collision.collider + " hit");
    }

    IEnumerator hideBar()
    {
        yield return new WaitForSeconds(2);
        healthBar.localScale = new Vector3(0, 1, 1);
    }

    private void Explode()
    {
        gameObject.SetActive(false);
        Instantiate(destructionExplosion, transform.position, Quaternion.identity);
    }
}
