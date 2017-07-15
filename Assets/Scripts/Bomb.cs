﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb: MonoBehaviour {

    private const float GRAVITY = 1.0f;

	public bool IsActive { set; get; }
    public SpriteRenderer sRenderer;

    private float verticalVelocity;
    private float speed;
    private bool isSliced = false;
    private ScoreManager bManager;
    
    public Sprite[] sprites;
    private int spriteIndex;
    private float lastSpriteUpdate;
    private float spriteUpdateDelta = 0.125f;
    private float rotationSpeed;

    public void Start()
    {
        bManager = FindObjectOfType<ScoreManager>();
    }
    
    public void LaunchBomb(float verticalVelocity,float xSpeed,Vector3 pos)
    {
        IsActive = true;
        speed = xSpeed;
        this.verticalVelocity = verticalVelocity;
        transform.position = pos;
        rotationSpeed = Random.Range(30,180);
        isSliced = false;

        spriteIndex = 0;
        sRenderer.sprite = sprites[spriteIndex];

    }

    private void Update()
    {
        if (!IsActive)
            return;

        verticalVelocity -= GRAVITY * Time.deltaTime;
        transform.position += new Vector3(speed, verticalVelocity, 0) * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));

        if (isSliced)
        {
            if((spriteIndex != (sprites.Length -1)) && (Time.time - lastSpriteUpdate > spriteUpdateDelta))
            {
                lastSpriteUpdate = Time.time;
                spriteIndex++;
                sRenderer.sprite = sprites[spriteIndex];
            }
        }

        if (transform.position.y < -1)
            IsActive = false;

    }

    public void Slice()
    {
        if (isSliced)
            return;

        if (verticalVelocity < 0.5f)
            verticalVelocity = 0.5f;

        speed = speed * 0.5f;
        isSliced = true;

        bManager.BombDeduct(5);
        FindObjectOfType<ScoreManager>().LoseLife();
    }
}
