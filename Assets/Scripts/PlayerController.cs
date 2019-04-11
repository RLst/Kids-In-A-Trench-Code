﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_speed = 6.0f;
    //movement speed multiplier
    private float m_speedModifier;
    // movement direction
    private Vector3 m_movement;
    // player rigidbody
    private Rigidbody m_playerRb;
    // private Quaternion m_cameraRotation;

    private GameObject m_crosshair;

    private void Start()
    {
        m_playerRb = GetComponent<Rigidbody>();
        m_crosshair = FindObjectOfType<Crosshair>().gameObject;
        // m_cameraRotation = GetComponentInChildren<Camera>().gameObject.transform.localRotation;
    }

    private void FixedUpdate()
    {
        transform.LookAt(new Vector3(m_crosshair.transform.position.x, transform.position.y, m_crosshair.transform.position.z));
        // gets the horizontal movement value
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        // gets the vertical movement value
        float moveVertical = Input.GetAxisRaw("Vertical");

        // moves, turns and animates the player
        Move(moveHorizontal, moveVertical);

        // GetComponentInChildren<Camera>().gameObject.transform.rotation = m_cameraRotation;
    }

    // moves the player
    private void Move(float h, float v)
    {
        // sets the movement direction to the horizontal and vertical components
        m_movement.Set(h, 0.0f, v);
        // converts the movement vector to real time movement
        m_movement = m_movement.normalized * m_speed * Time.deltaTime;
        // moves the rigidbody to the current position plus the movement
        m_playerRb.MovePosition(transform.position + m_movement);
    }
}