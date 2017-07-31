using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charater : MonoBehaviour {

	public float speed_inclined = 15;
	public float speed_straight;
	public float speed_1;
	public float speed_2;
	public int Timer;
    public static int hp = 4;

	public static int weapon_sum = 4;
	public static int canuse_sum = 4;
	public weapon weapon_use;
	public weapon[] weapon_now;
	public weapon []weapon_all;


    public float[] timer;

	public GameObject[] hpblood;
    public bool gethurt = false;
    private bool invincible = false;
    private float invincibletime = 200;

    // Use this for initialization
    void Start () {
		speed_straight = (float)(1.414 * speed_inclined);
		Timer = 100;
		speed_1 = speed_inclined;
		speed_2 = speed_straight;
		weapon_use = weapon_now[0];
		this.transform.Find (weapon_use.name).gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
        move();
		move_quick ();
		WeaponChange ();
        if (Input.GetKeyDown(KeyCode.J))
        {
            attack();
        }
		DiscardWeapon ();
        /*if(gethurt&&!invincible)
        {
            hp--;
            hpblood[hp].SetActive(false);
            gethurt = false;
            invincible = true;
        }*/

    }

	public void WeaponChange()
	{
		if (Input.GetKey (KeyCode.Alpha1)) {
			if (weapon_now [0] != null && weapon_now[0].UseNow==true) {
				weapon_use = weapon_now [0];
				foreach (Transform ss in this.transform) {
					ss.gameObject.SetActive (false);
				}	
				this.transform.Find (weapon_use.name).gameObject.SetActive (true);
			}
		} else if (Input.GetKey (KeyCode.Alpha2)) {
			if (weapon_now [1] != null && weapon_now[1].UseNow==true) {
				weapon_use = weapon_now [1];
				foreach (Transform ss in this.transform) {
					ss.gameObject.SetActive (false);
				}
				this.transform.Find (weapon_use.name).gameObject.SetActive (true);
			}
		} else if (Input.GetKey (KeyCode.Alpha3)) {
			if (weapon_now [2] != null && weapon_now[2].UseNow==true) {
				weapon_use = weapon_now [2];
				foreach (Transform ss in this.transform) {
					ss.gameObject.SetActive (false);
				}
				this.transform.Find (weapon_use.name).gameObject.SetActive (true);
			}
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

	private void move_quick()
	{
		if (Input.GetKey (KeyCode.Z) && Timer == 100) {
			speed_inclined *= 2;
			speed_straight *= 2;
		} 
		if (Timer < 0) {
			speed_inclined = speed_1;
			speed_straight = speed_2;
		}
		if (speed_inclined == 30) {
			Timer -= 5;
		}
		else if(Timer<100)
			Timer++;
	}

    private void move()
    {
		if (Input.GetKey(KeyCode.UpArrow)&&Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector3.forward * Time.deltaTime * speed_inclined, Space.World);
			transform.Translate(Vector3.left * Time.deltaTime * speed_inclined, Space.World);
			transform.Rotate(new Vector3(0, -45, 0)-this.transform.eulerAngles);
		}
		else if (Input.GetKey(KeyCode.DownArrow)&&Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector3.back * Time.deltaTime * speed_inclined, Space.World);
			transform.Translate(Vector3.left * Time.deltaTime * speed_inclined, Space.World);
			transform.Rotate(new Vector3(0, -135, 0)-this.transform.eulerAngles);
		}
		else if (Input.GetKey(KeyCode.UpArrow)&&Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector3.forward * Time.deltaTime * speed_inclined, Space.World);
			transform.Translate(Vector3.right * Time.deltaTime * speed_inclined, Space.World);
			transform.Rotate(new Vector3(0, 45, 0)-this.transform.eulerAngles);
		}
		else if (Input.GetKey(KeyCode.DownArrow)&&Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector3.back * Time.deltaTime * speed_inclined, Space.World);
			transform.Translate(Vector3.right * Time.deltaTime * speed_inclined, Space.World);
			transform.Rotate(new Vector3(0, 135, 0)-this.transform.eulerAngles);
		}
		else if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector3.forward * Time.deltaTime * speed_straight, Space.World);
			transform.Rotate(new Vector3(0, 0, 0)-this.transform.eulerAngles);
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate (Vector3.back * Time.deltaTime * speed_straight, Space.World);
			transform.Rotate(new Vector3(0, 180, 0) - this.transform.eulerAngles);
		}

		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector3.left * Time.deltaTime * speed_straight, Space.World);
			transform.Rotate(new Vector3(0, -90, 0) - this.transform.eulerAngles);
		}

		else if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector3.right * Time.deltaTime * speed_straight, Space.World);
			transform.Rotate(new Vector3(0, 90, 0) - this.transform.eulerAngles);
		}
    }

	private void DiscardWeapon()
	{
		if (Input.GetKey (KeyCode.G)) {
			for (int i=0; i < 3; i++) {
				if (weapon_now [i].name == weapon_use.name) {
					weapon_now [i].UseNow = false;
					break;
				}
			}
			this.transform.Find (weapon_use.name).gameObject.SetActive (false);
		}
	}

    void attack()
    {
		if (!weapon_use.anima.IsPlaying(weapon_use.attackanima))
        {
			weapon_use.attack();
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
		int i;
		int j;
		int temp_1;
		int temp_2;
		if (other.tag == "door") {
			if (Input.GetKeyDown (KeyCode.E)) {

			}
		}
		if (other.tag == "GameController") {
			for (i = 0; i < weapon_sum; i++) {
				if (weapon_all [i].name == other.GetComponent<prop> ().Name) {
					for (j = 0; j < 3; j++) {
						if (weapon_now [j] == null || weapon_now [j].UseNow == false) {
							temp_1 = i;
							temp_2 = j;
							weapon_now [j] = weapon_all [i];
							weapon_now [j].UseNow = true;
							Destroy (other.gameObject);
							break;
						} 
					}
				}
			}
		}
	}
}