using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour {

    public GameObject bullet;
    public float shoottime = 5;
    private float timer = 0 ;
    public bool starttimer = false;
    private GameObject man;
    public weapon firestaff;
	// Use this for initialization
	void Start () {
        man = GameObject.Find("man");

    }
	
	// Update is called once per frame
	void Update () {

        
		
	}
    private void FixedUpdate()
    {
        if (firestaff.anima.IsPlaying(firestaff.attackanima))
        {
            starttimer = true;
        }
        else
        {
            starttimer = false;
            timer = 0;
        }
        if (starttimer)
        {
            timer++;
            if (timer == shoottime)
            {
                shoot();
            }

        }

    }

    public void shoot()
    {
        GameObject.Instantiate(bullet,new Vector3(this.transform.position.x, this.transform.position.y-5, this.transform.position.z), man.transform.rotation);
    }
}
