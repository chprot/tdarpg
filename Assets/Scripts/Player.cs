using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character {

    // Use this for initialization
    protected override void StartImpl()
    {
        this.spriteRenderer.sprite = bottomSprite;
    }


    protected override void UpdateImpl()
    {
        HandleInput();
    }

    void HandleInput()
    {
        Vector3 playerMovement = Vector3.zero;
        playerMovement.x = Input.GetAxis("Horizontal");
        playerMovement.y = Input.GetAxis("Vertical");
        characterRigidBody.velocity = playerMovement;

        //Vector3 lookDirection = Vector3.zero;
        lookDirection.x = Input.GetAxis("LookHorizontal");
        lookDirection.y = Input.GetAxis("LookVertical");
        if (lookDirection.magnitude == 0f)
        {
            lookDirection.x = playerMovement.x;
            lookDirection.y = playerMovement.y;
        }
    }
}
