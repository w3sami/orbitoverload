using UnityEngine;

public class spaceStation : MonoBehaviour {

    public ship ship;
    public Healthbar[] bars;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag != "Player")
        {
            return;
        }
        ship.reset();
        foreach(Healthbar bar in bars)
        {
            bar.SetHealth(0);
        }
    }
}
