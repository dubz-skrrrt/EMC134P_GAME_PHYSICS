﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Version 1 of this simple component to draw lines representing force vectors
// Think of them as rocket trails if you like

[DisallowMultipleComponent]
[RequireComponent (typeof(NewtonLaw_movement))]
public class DrawForces : MonoBehaviour {

	public bool showTrails = true;

	private List<Vector3> forceList = new List<Vector3>();
	private LineRenderer lineRenderer;
	private int numberOfForces;
	
	// Use this for initialization
	void Start () {
		forceList = GetComponent<NewtonLaw_movement>().forceList;

		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		lineRenderer.SetColors(Color.yellow, Color.yellow);
		lineRenderer.SetWidth(0.2F, 0.2F);
		lineRenderer.useWorldSpace = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (showTrails) {
			lineRenderer.enabled = true;
			numberOfForces = forceList.Count;
			lineRenderer.SetVertexCount(numberOfForces * 2);
			int i = 0;
			foreach (Vector3 forceVector in forceList) {
				lineRenderer.SetPosition(i, Vector3.zero);
				lineRenderer.SetPosition(i+1, -forceVector);
				i = i + 2;
			}
		} else {
			lineRenderer.enabled = false;
		}
	}
}
 