using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charater : MonoBehaviour {

    public float speed = 10;
    public int hp = 4;
    public int hp_max = 5;
    public GameObject Emark;

    public float[] timer;

    public bool gethurt = false;
    private bool invincible = false;
    public float invincibletime = 50;

    public weapon weapon_use;

    public GameObject hp_up;

    // Use this for initialization
    void Start () {
        Emark = GameObject.Find("pressE");
        Emark.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        move();
        if (weapon_use!=null&&Input.GetKeyDown(KeyCode.J))
        {
            attack();
        }
        if(gethurt&&!invincible)
        {
            hp--;
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

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "prop")
        {
            Emark.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (other.GetComponent<prop>().type == proptype.health)
                {
                    if (hp < hp_max)
                    {

                        hp++;
                        Instantiate(hp_up,this.transform.position, Quaternion.identity);
                        Destroy(other.gameObject);
                        Emark.SetActive(false);
                    }
                }
                if (other.GetComponent<prop>().type == proptype.weapon)
                {
                    if (GetComponent<weaponchange>().Addweapon(other.name))
                    {
                        Destroy(other.gameObject);
                        Emark.SetActive(false);
                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "prop")
        {
            Emark.SetActive(false);
        }
    }
}
