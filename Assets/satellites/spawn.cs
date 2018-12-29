using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class spawn : MonoBehaviour {
    public bool rerun = false;
    public bool destroy = false;
    private int maxSpawns;
    public spawnValues values;


    void Update()
    {
        if (rerun)
        {
            rerun = false;
            if (destroy)
            {
                var o = GameObject.FindGameObjectsWithTag("Cube");
                foreach (var d in o)
                {
                    DestroyImmediate(d, true);
                }
            }
            maxSpawns = values.maxSpawns;
            fill();
        }
    }

    // Use this for initialization
    void Start()
    {
        maxSpawns = values.maxSpawns;
        StartCoroutine(waitAndRespawn());
        fill();
    }

    void fill()
    {
        for (var l = 0; l < (int)maxSpawns / 1; l ++)
        {
            Spawn(Random.Range(-values.x, values.x), Random.Range(0, values.height));
        }
    }

    IEnumerator waitAndRespawn()
    {
        yield return new WaitForSeconds(values.frequency);
        Spawn(values.x, Random.Range(0f, values.height));
        StartCoroutine(waitAndRespawn());
    }

    private void Spawn(float x, float y)
    {
        if (maxSpawns <= 0)
        {
            return;
        }
        maxSpawns--;

        var heightMultiplier = y * values.heightEffect;
        var spawned = Instantiate(values.spawnables[Random.Range(0, values.spawnables.Length)]);
        var scale = Random.Range(values.minScale, values.maxScale) * heightMultiplier;
        spawned.transform.localScale *= scale;
        spawned.transform.position = new Vector3(x, y, 0);
        var body = spawned.GetComponent<Rigidbody>();
        body.AddForce(Vector3.left * Random.Range(values.minForce, values.maxForce) * heightMultiplier);
        body.mass = scale * .01f;
        body.AddTorque(new Vector3(
            Random.Range(values.minForce, values.maxForce) * heightMultiplier,
            Random.Range(values.minForce, values.maxForce) * heightMultiplier,
            Random.Range(values.minForce, values.maxForce) * heightMultiplier
        ) 
       );
    }
}
