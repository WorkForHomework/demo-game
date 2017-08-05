using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstercreate : MonoBehaviour {

    public GameObject monster;
    public float rate = 5f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("createEnemy", 1, rate);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void createEnemy()
    {
        GameObject.Instantiate(monster, this.transform.position, Quaternion.identity);
    }

}
