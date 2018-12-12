using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : NPC
{
    // Use this for initialization
    protected override void StartImpl ()
    {
        base.StartImpl();
        this.faction = Faction.Enemy;
	}

	// Update is called once per frame
    protected override void UpdateImpl()
    {
        base.UpdateImpl();
    }
}

