using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroArea : MonoBehavior
{
    public CapsuleCollider2D collider2D;

    void Start()
    {
        collider2D = new CapsuleCollider2D();
        collider2D.offset.y += 1.0f; // slightly offset forward from NPC
        collider2D.isTrigger = true;
        this.gameObject.AddComponent<CapsuleCollider2D>(collider2D);
    }

    void Update()
    {
    }

    // TODO: OnTriggerEnter2D stuff for aggro with enemy faction type
}

public class NPC : Character
{
    public GameObject aggroAreaGameObject;

    // Use this for initialization
    protected override void StartImpl ()
    {
        // Set up aggro area
        Instantiate(aggroAreaGameObject);
        aggroAreaGameObject.AddComponent<AggroArea>();

        // Make aggro area follow player position, initialize rotation
        aggroAreaGameObject.transform.parent = this.gameObject.transform;
        aggroAreaGameObject.transform.RotateAround(this.transform.position, Vector3.up, characterRotationDeg);
	}

	// Update is called once per frame
    protected override void UpdateImpl()
    {
        // Update aggro area to follow NPC rotation
        aggroAreaGameObject.transform.RotateAround(this.transform.position, Vector3.up, characterRotationDeg);
    }
}
