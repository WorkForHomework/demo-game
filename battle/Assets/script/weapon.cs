﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}
    public void attack()
    {
        GetComponent<Animation>().CrossFade("sword");
    }
}
