﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum players
{
    blue, red, green, yellow
}

public class ship : MonoBehaviour
{
    public players p;
    public float rotateSpeed;
    public float speed;
    public Rigidbody rb;
    public KeyCode actionButton;
    private bool rotateDirection = true;
    public int score;
    public Text scoreText;

    void Start()
    {
        if (p == players.blue)
        {
            actionButton = KeyCode.Q;
        }
        else if (p == players.red)
        {
            actionButton = KeyCode.P;
        }
        else if (p == players.green)
        {
            actionButton = KeyCode.Z;
        }
        else if (p == players.yellow)
        {
            actionButton = KeyCode.M;
        }
    }


    void Update()
    {
        //MOVE
        if (Input.GetKey(actionButton))
        {
            rb.AddForce(transform.forward * -speed);
        }
        //ROTATE
        else
        {
            if (rotateDirection == true)
            {
                gameObject.transform.Rotate(0, rotateSpeed, 0);
            }
            else if (rotateDirection == false)
            {
                gameObject.transform.Rotate(0, -rotateSpeed, 0);
            }
        }
        //REVERSE ROTATION OF SHIP
        if(Input.GetKeyDown(actionButton))
        {
            rotateDirection = !rotateDirection;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collectable")
        {
            score++;
            Destroy(other.gameObject);
            scoreText.text = ""+ score;
        }
    }
}