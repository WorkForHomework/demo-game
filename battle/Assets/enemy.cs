using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public GameObject blood;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="weapon")
        {
            GameObject.Instantiate(blood, this.transform.position, Quaternion.identity);
        }
    }
}
