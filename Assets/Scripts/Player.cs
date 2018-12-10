using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    // Use this for initialization
    protected override void StartImpl()
    {
        this.spriteRenderer.sprite = bottomSprite;
        this.faction = Faction.Friendly;
    }

	// Update is called once per frame
    protected override void UpdateImpl()
    {
        // Handle any user input
        HandleInput();
    }

    // Handle user input and update player state accordingly
    void HandleInput()
    {
        // Update character's velocity based on input
        Vector3 playerMovement = Vector3.zero;
        playerMovement.x = Input.GetAxis("Horizontal");
        playerMovement.y = Input.GetAxis("Vertical");
        characterRigidBody.velocity = playerMovement;

        // Set the character's look direction based on input
        lookDirection.x = Input.GetAxis("LookHorizontal");
        lookDirection.y = Input.GetAxis("LookVertical");
        lookDirection.y = 0.0f;

        // Set look direction to player movement forward vector, if no other look input set
        if (lookDirection.magnitude == 0.0f)
        {
            lookDirection.x = playerMovement.x;
            lookDirection.y = playerMovement.y;
        }
    }
}
