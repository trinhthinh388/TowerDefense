﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour {


    public static Transform[] points;
	// Use this for initialization
	void Awake () {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
			Debug.Log(i);
			points[i] = transform.GetChild(i);
        }
		
	}
}
