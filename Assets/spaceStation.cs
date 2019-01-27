using UnityEngine;

public class spaceStation : MonoBehaviour {

    public ship ship;
    public Healthbar[] bars;

    public void OnTriggerEnter()
    {
        ship.reset();
        foreach(Healthbar bar in bars)
        {
            bar.SetHealth(0);
        }
    }
}
