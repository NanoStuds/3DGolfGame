﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    private Plane plane;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Rigidbody rb;
    public Text shotsText;
    private int shots;

    void UpdateShotsCount()
    {
        shotsText.text = shots.ToString();
    }

	// Use this for initialization
	void Start () {
        plane = new Plane(Vector3.up, Vector3.zero);
        rb = GetComponent<Rigidbody>();
        shots = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance;
        if (Input.GetMouseButtonDown(0))
        {
            if (plane.Raycast(ray, out distance))
            {
                startPoint = ray.GetPoint(distance);
                //Debug.Log(ray.GetPoint(distance));
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (plane.Raycast(ray, out distance))
            {
                endPoint = ray.GetPoint(distance);
                rb.AddForce(-1 * (endPoint - startPoint), ForceMode.Impulse);
                shots++;
                UpdateShotsCount();
            }

        }
        
	}
}
