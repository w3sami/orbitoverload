using UnityEngine;

[CreateAssetMenu]
public class spawnValues : ScriptableObject {

    [SerializeField]
    public float height = 1000f;
    public float x = 1000;
    public float frequency = .5f;
    public float minScale = .5f;
    public float maxScale = 2f;
    public float minForce = .5f;
    public float maxForce = 2f;
    public float heightEffect = .01f;
    public GameObject[] spawnables;
    public bool rerun = false;
    public bool destroy = false;
    public int maxSpawns = 10000;
}
