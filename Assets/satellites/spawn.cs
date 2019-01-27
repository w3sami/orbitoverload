using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using RoboRyanTron.Unite2017.Events;

public class spawn : MonoBehaviour {
    public bool rerun = false;
    public bool destroy = false;
    private int maxSpawns;
    public spawnValues values;
    public GameEvent satelliteSpawned;
    private List<spawnable> spawns = new List<spawnable>();


    void Update()
    {
        if (rerun)
        {
            rerun = false;
            if (destroy)
            {
                var o = GameObject.FindGameObjectsWithTag("Debris");
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
        var prices = new float[4] { Random.Range(0.1f, 50f), Random.Range(0.1f, 50f), Random.Range(0.1f, 50f), Random.Range(0.1f, 50f) };
        for (var l = 0; l < values.spawnables.Length - 1; l++)
        {
            GameObject spawned = values.spawnables[l];
            var size = Vector3.Magnitude(spawned.GetComponent<Renderer>().bounds.size);
            var mCount = Random.Range(1, 5);
            var minerals = new Mineral[mCount];
            for (var i = 0; i < mCount; i++)
            {
                minerals[i] = new Mineral("mineral" + (i + 1), Random.Range(0.1f, 5f) * size / 4, prices[i]);
            }
            spawns.Add(new spawnable(spawned, size, 2000f / size, minerals));
        }

        // not used atm just normalizing the sizes to about same for all
        spawns.Sort((p1, p2) => p1.volume.CompareTo(p2.volume));
        maxSpawns = values.maxSpawns;
        StartCoroutine(waitAndRespawn());
        fill();


    }

    void fill()
    {
        for (var l = 0; l < (int) maxSpawns; l++)
        {
            Spawn(Random.Range(-values.x, values.x), Random.Range(0, values.height));
        }
    }

    private float countVolume(MeshFilter filter)
    {
        Vector3[] vertices = filter.sharedMesh.vertices;
        int[] triangles = filter.sharedMesh.triangles;

        float result = 0f;
        for (int p = 0; p < triangles.Length; p += 3)
        {
            result += (Vector3.Cross(vertices[triangles[p + 1]] - vertices[triangles[p]],
                        vertices[triangles[p + 2]] - vertices[triangles[p]])).magnitude;
        }
        return result *= 0.5f;
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
        satelliteSpawned.Raise();

        var heightMultiplier = y * values.heightEffect;
        var s = spawns[Random.Range(0, spawns.Count)];
        var spawned = Instantiate(s.go);
        spawned.AddComponent<Minerals>();
        spawned.GetComponent<Minerals>().minerals = s.Minerals;
        spawned.tag = "Debris";
        var scale = Random.Range(values.minScale, values.maxScale) * heightMultiplier * s.sizeNormalized ;
        spawned.transform.localScale = Vector3.one * scale;
        spawned.transform.position = new Vector3(x, y, 0);
        var body = spawned.GetComponent<Rigidbody>();
        var renderer = spawned.GetComponent<Renderer>();
        body.AddForce(Vector3.left * Random.Range(values.minForce, values.maxForce) * heightMultiplier);
        body.mass = scale * .01f;

        //Debug.Log(x/10 + " " + Vector3.Distance(Vector3.zero, renderer.bounds.size));

        body.AddTorque(new Vector3(
            Random.Range(values.minForce, values.maxForce) * heightMultiplier,
            Random.Range(values.minForce, values.maxForce) * heightMultiplier,
            Random.Range(values.minForce, values.maxForce) * heightMultiplier
        ) 
       );
    }
}
