using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charater : MonoBehaviour {

    public float speed = 10;
    public weapon w1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        move();
        if (Input.GetKey(KeyCode.J))
        {
            attack();
        }

    }

    private void move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0,0,-1) * Time.deltaTime * speed,Space.World);
            transform.Rotate(new Vector3(0, -90, 0)-this.transform.eulerAngles);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed,Space.World);
            transform.Rotate(new Vector3(0, 90, 0) - this.transform.eulerAngles);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed, Space.World);
            transform.Rotate(new Vector3(0, 180, 0) - this.transform.eulerAngles);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed,Space.World);
            transform.Rotate(new Vector3(0, 0, 0) - this.transform.eulerAngles);
        }
    }

    void attack()
    {
        if (!w1.anima.IsPlaying("sword"))
        {
            w1.attack();
        }
    }
}
