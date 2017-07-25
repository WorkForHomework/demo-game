using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public GameObject blood;
    public float hp = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (hp == 0) bekilled();
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="weapon")
        {
            if(hp>0) hp--;
            other.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void bekilled()
    {
        GameObject.Instantiate(blood, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
