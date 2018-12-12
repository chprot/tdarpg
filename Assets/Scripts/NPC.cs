using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroArea : MonoBehaviour
{
    public CapsuleCollider2D aggroCollider2D;
    public List<Character> targetList;

    void Start()
    {
        aggroCollider2D = this.gameObject.AddComponent<CapsuleCollider2D>();
        aggroCollider2D.offset = new Vector2(aggroCollider2D.offset.x, aggroCollider2D.offset.y + 0.2f); // slightly offset forward from NPC
        aggroCollider2D.isTrigger = true;

        targetList = new List<Character>();
    }

    void Update()
    {
        // Update rotation to the Character owner's rotation
        Character owner = this.GetComponentInParent<Character>();
        this.transform.rotation = Quaternion.Euler(0, 0, -owner.characterRotationDeg);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Add any target character to targetList
        Character character = other.gameObject.GetComponent<Character>();
        if (character != null)
            targetList.Add(character);
    }
}

public class NPC : Character
{
    public GameObject aggroAreaGameObject;

    // Use this for initialization
    protected override void StartImpl ()
    {
        // Set up aggro area
        aggroAreaGameObject = new GameObject("AggroArea");
        aggroAreaGameObject.AddComponent<AggroArea>();

        // Make aggro area follow player position and rotation by setting parent transform
        aggroAreaGameObject.transform.position = this.gameObject.transform.position;
        aggroAreaGameObject.transform.parent = this.gameObject.transform;
	}

	// Update is called once per frame
    protected override void UpdateImpl()
    {
        // Attack any enemy targets in in this NPC's aggro area
        AggroArea aggroArea = aggroAreaGameObject.GetComponent<AggroArea>();
        List<Character> targetList = aggroArea.targetList;
        Character enemyTarget = targetList.Find(x => x.faction != this.faction);
        if (enemyTarget != null)
        {
            // TODO: If in range, attack
            // Else, run towards target
            Vector3 npcMovementDir = (enemyTarget.gameObject.transform.position - this.gameObject.transform.position).normalized;
            this.characterRigidBody.velocity = npcMovementDir;
            this.lookDirection = npcMovementDir;
        }
    }
}
