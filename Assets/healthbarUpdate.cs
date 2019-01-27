using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbarUpdate : MonoBehaviour {

    public Healthbar healthbar;

    // Use this for initialization
    public void onUpdate(object[] minerals)
    {
        foreach (Mineral mineral in minerals)
        {
            if (gameObject.name == mineral.name)
            {
                healthbar.GainHealth(mineral.amount);
            }
        }
    }
}
