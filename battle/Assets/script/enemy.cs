using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public GameObject blood;
    public GameObject blood2;
    public float hp = 2;
    private bool invincible = false;
    public float invincibletime = 20;
    private float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (hp == 0) bekilled();
		
	}
    private void FixedUpdate()
    {
        if(invincible)
        {
            timer++;
            if(timer == invincibletime)
            {
                invincible = false;
                timer = 0;
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="weapon"|| other.tag == "cast")
        {
            if (hp > 0 && !invincible)
            {
                hp--;
                GetComponent<AIFllow>().follow_speed -= 30;
                if(hp > 0) GameObject.Instantiate(blood2, this.transform.position, Quaternion.identity);
            }
            invincible = true;
            
        }
    }
    public void bekilled()
    {
        GameObject.Instantiate(blood, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
