using UnityEngine;


public class spawnable {

    [SerializeField]
    public float volume = 0f;
    public GameObject go;
    public float sizeNormalized;

    public spawnable (GameObject GO, float vol, float sizeN)
    {
        go = GO;
        volume = vol;
        sizeNormalized = sizeN;
    }
}
