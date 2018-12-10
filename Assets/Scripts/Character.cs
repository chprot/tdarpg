using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Faction of the characters
public enum Faction { Friendly, Neutral, Enemy }

public abstract class Character : MonoBehaviour
{
    public Rigidbody2D characterRigidBody;
    public SpriteRenderer spriteRenderer;

    // Player stats
    public int hp;
    public int stamina;
    public float speed;
    public Faction faction;

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
    protected float characterRotationDeg;

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
        characterRotationDeg = Mathf.Atan2(lookDirection.x, (lookDirection.y)) * Mathf.Rad2Deg;

        // Set player sprite based on rotation
        if (characterRotationDeg > -22.5 && characterRotationDeg <= 22.5)
        {
            this.spriteRenderer.sprite = topSprite;
        }
        if (characterRotationDeg > 22.5 && characterRotationDeg <= 67.5)
        {
            this.spriteRenderer.sprite = topRightSprite;
        }
        if (characterRotationDeg > 67.5 && characterRotationDeg <= 112.5)
        {
            this.spriteRenderer.sprite = rightSprite;
        }
        if (characterRotationDeg > 112.5 && characterRotationDeg <= 157.5)
        {
            this.spriteRenderer.sprite = bottomRightSprite;
        }
        if ((characterRotationDeg > 157.5 && characterRotationDeg <= 180) || (characterRotationDeg > -180 && characterRotationDeg <= -157.5))
        {
            this.spriteRenderer.sprite = bottomSprite;
        }
        if (characterRotationDeg > -157.5 && characterRotationDeg <= -112.5)
        {
            this.spriteRenderer.sprite = bottomLeftSprite;
        }
        if (characterRotationDeg > -112.5 && characterRotationDeg <= -67.5)
        {
            this.spriteRenderer.sprite = leftSprite;
        }
        if (characterRotationDeg > -67.5 && characterRotationDeg <= -22.5)
        {
            this.spriteRenderer.sprite = topLeftSprite;
        }
    }

}
