﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Damageable
{
    //Control the health bar
    Image[] m_heartImages;

    void Awake()
    {
        m_heartImages = FindObjectOfType<PlayerHealthBar>().GetComponentsInChildren<Image>();
    }

    public void UpdatePlayerHealthBar()
    {
        for (int i = 0; i < m_heartImages.Length; i++)
        {
            if (currentHP > i) {
                m_heartImages[i].color = Color.red;
            }
            else {
                m_heartImages[i].color = Color.black;
            }
        }
    }

    public override void Death()
    {
        //Fall over
        var rb = GetComponent<Rigidbody>();
        var nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        rb.constraints = RigidbodyConstraints.None;
        nav.enabled = false;
    }   
}