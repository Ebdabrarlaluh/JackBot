﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    public KeyCode visibilityKeyCode = KeyCode.C;
    public SpriteRenderer character;

    public float activationTime = 5.0f;
    private bool isInvisible;
    private Color col;
    void Start()
    {
        isInvisible = false;
        col = character.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(visibilityKeyCode)&& activationTime>0 && !isInvisible)
        {
            GoTransparent();
        }

        if (activationTime < 0)
        {
            GoOpaque();
        }
        else if (isInvisible)
        {
            activationTime -= Time.deltaTime;
        }
    }

    void GoTransparent()
    {
        col.a = 0.5f;
        col.r = 0;
        character.color=col;
        isInvisible = true;
    }

    void GoOpaque()
    {
        col.a = 1f;
        col.r = 255;
        character.color = col;
        isInvisible = false;
        activationTime = 5f;
    }
}
