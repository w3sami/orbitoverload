using UnityEngine;

public class spawnable {

    [SerializeField]
    public float volume = 0f;
    public GameObject go;
    public float sizeNormalized;
    public Mineral[] Minerals;

    public spawnable (GameObject GO, float vol, float sizeN, Mineral[] minerals)
    {
        go = GO;
        volume = vol;
        sizeNormalized = sizeN;
        Minerals = minerals;
    }
}
