﻿using UnityEngine;

public class PlayerInput : MonoBehaviour {

	[HideInInspector] public Vector2 axis;
	[HideInInspector] public bool shoot;	
	[HideInInspector] public bool dash;

	[SerializeField] bool invertHorizontal = false;
	[SerializeField] bool invertVertical = false;
	[SerializeField] bool raw = false;
	[SerializeField] KeyCode shootButton = KeyCode.Mouse0;
	[SerializeField] KeyCode dashButton = KeyCode.Mouse1;


	void Update ()
    {
        SetAxes();
        SetShoot();
        SetDash();
    }

    private void SetDash()
    {
        if (Input.GetKeyDown(dashButton))
        {
            dash = true;
        }
        else
        {
            dash = false;
        }
    }

    private void SetShoot()
    {
        if (Input.GetKeyDown(shootButton))
        {
            shoot = true;
        }
        else
        {
            shoot = false;
        }
    }

    private void SetAxes()
    {
        if (raw)
        {
            axis.x = invertHorizontal ? -Input.GetAxisRaw("Horizontal") : Input.GetAxisRaw("Horizontal");
            axis.x = invertHorizontal ? -Input.GetAxisRaw("Vertical") : Input.GetAxisRaw("Vertical");
        }
        else
        {
            axis.x = invertHorizontal ? -Input.GetAxis("Horizontal") : Input.GetAxis("Horizontal");
            axis.x = invertHorizontal ? -Input.GetAxis("Vertical") : Input.GetAxis("Vertical");
        }
    }
}
