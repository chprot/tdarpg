using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    public int hp;
    public int stamina;
    public float speed;
    public Rigidbody2D characterRigidBody;
    public Sprite bottomSprite;
    public Sprite bottomRightSprite;
    public Sprite bottomLeftSprite;
    public Sprite topSprite;
    public Sprite topRightSprite;
    public Sprite topLeftSprite;
    public Sprite rightSprite;
    public Sprite leftSprite;
    public SpriteRenderer spriteRenderer;
    protected Vector3 lookDirection;

    // Use this for initialization
    void Start ()
    {
        //add RigidBody2D
        characterRigidBody = this.gameObject.AddComponent<Rigidbody2D>();
        characterRigidBody.drag = 0.5f;
        characterRigidBody.gravityScale = 0.0f;

        //add Sprite
        spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
       // spriteRenderer.sprite = bottomSprite;

        StartImpl();
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateImpl();
        RotateSprite(lookDirection); //Update sprite rotation to look direction
    }

    protected abstract void UpdateImpl ();
    protected abstract void StartImpl();

    private void RotateSprite(Vector3 lookDirection)
    {
        //sprite rendering
        float playerRotationDeg = Mathf.Atan2(lookDirection.x, (lookDirection.y)) * Mathf.Rad2Deg;
        Debug.Log(playerRotationDeg);
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
