using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Rigidbody2D characterRigidBody;
    public SpriteRenderer spriteRenderer;

    // Player stats
    public int hp;
    public int stamina;
    public float speed;

    // 8-Way Directional Sprites
    public Sprite bottomSprite;
    public Sprite bottomRightSprite;
    public Sprite bottomLeftSprite;
    public Sprite topSprite;
    public Sprite topRightSprite;
    public Sprite topLeftSprite;
    public Sprite rightSprite;
    public Sprite leftSprite;

    // Direction character is facing
    protected Vector3 lookDirection;

    // Abstract functions
    protected abstract void UpdateImpl ();
    protected abstract void StartImpl();

    // Use this for initialization
    void Start ()
    {
        // Add RigidBody2D
        characterRigidBody = this.gameObject.AddComponent<Rigidbody2D>();
        characterRigidBody.drag = 0.5f;
        characterRigidBody.gravityScale = 0.0f;

        // Add Sprite
        spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();

        // Call into derived class start
        StartImpl();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Call into derived class update
        UpdateImpl();

        // Update sprite rotation to look direction
        RotateSprite(lookDirection);
    }

    // Set the sprite renderer's sprite to the appropriate rotation for the given lookDirection
    //  lookDirection: Direction character is looking
    private void RotateSprite(Vector3 lookDirection)
    {
        // Find rotation value for the given forward lookDirection
        float playerRotationDeg = Mathf.Atan2(lookDirection.x, (lookDirection.y)) * Mathf.Rad2Deg;

        // Set player sprite based on rotation
        if (playerRotationDeg > -22.5 && playerRotationDeg <= 22.5)
        {
            this.spriteRenderer.sprite = topSprite;
        }
        if (playerRotationDeg > 22.5 && playerRotationDeg <= 67.5)
        {
            this.spriteRenderer.sprite = topRightSprite;
        }
        if (playerRotationDeg > 67.5 && playerRotationDeg <= 112.5)
        {
            this.spriteRenderer.sprite = rightSprite;
        }
        if (playerRotationDeg > 112.5 && playerRotationDeg <= 157.5)
        {
            this.spriteRenderer.sprite = bottomRightSprite;
        }
        if ((playerRotationDeg > 157.5 && playerRotationDeg <= 180) || (playerRotationDeg > -180 && playerRotationDeg <= -157.5))
        {
            this.spriteRenderer.sprite = bottomSprite;
        }
        if (playerRotationDeg > -157.5 && playerRotationDeg <= -112.5)
        {
            this.spriteRenderer.sprite = bottomLeftSprite;
        }
        if (playerRotationDeg > -112.5 && playerRotationDeg <= -67.5)
        {
            this.spriteRenderer.sprite = leftSprite;
        }
        if (playerRotationDeg > -67.5 && playerRotationDeg <= -22.5)
        {
            this.spriteRenderer.sprite = topLeftSprite;
        }
    }

}
