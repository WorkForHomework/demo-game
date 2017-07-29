using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charater : MonoBehaviour {

    public float speed = 10;
    public static int hp = 4;
    public weapon w1;

    public float[] timer;

    public GameObject[] hpblood;
    public bool gethurt = false;
    private bool invincible = false;
    private float invincibletime = 200;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        move();
        if (Input.GetKeyDown(KeyCode.J))
        {
            attack();
        }
        if(gethurt&&!invincible)
        {
            hp--;
            hpblood[hp].SetActive(false);
            gethurt = false;
            invincible = true;
        }


    }

    private void FixedUpdate()
    {
        if (invincible)
        {
            timer[0]++;
            if (timer[0] == invincibletime)
            {
                invincible = false;
                timer[0] = 0;
            }
        }
    }

    private void move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
            transform.Rotate(new Vector3(0, 0, 0)-this.transform.eulerAngles);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back* Time.deltaTime * speed, Space.World);
            transform.Rotate(new Vector3(0, 180, 0) - this.transform.eulerAngles);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
           transform.Rotate(new Vector3(0, -90, 0) - this.transform.eulerAngles);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
           transform.Rotate(new Vector3(0, 90, 0) - this.transform.eulerAngles);
        }
    }

    void attack()
    {
        if (!w1.anima.IsPlaying(w1.attackanima))
        {
            w1.attack();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "enemy")
        {
            if(!invincible)
            {
                gethurt = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "door")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {

            }
        }
    }
}
