using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponchange : MonoBehaviour {

    public charater man;

    public weapon weapon_use;
    public weapon[] weapon_now;

    public string[] weapon_discard;
    public GameObject[] Equip_small;

    public weaponUI UI;

    // Use this for initialization
    void Start () {
        man = GetComponent<charater>();
		
	}
	
	// Update is called once per frame
	void Update () {

        WeaponChange();
		
	}

/*private void DiscardWeapon()
    {
        if (Input.GetKey(KeyCode.G) && weapon_use.UseNow == true)
        {
            for (int i = 0; i < 6; i++)
            {
                if (weapon_now[i].name == weapon_use.name)
                {
                    weapon_now[i].UseNow = false;
                    weapon_now[i] = weapon_all[0];
                    break;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (weapon_discard[i] == weapon_use.name)
                {
                    GameObject equip_weapon = Instantiate(Equip_small[i]) as GameObject;
                    equip_weapon.transform.position = new Vector3(this.transform.position.x, -36, this.transform.position.z + 1);
                    break;
                }
            }
            this.transform.Find(weapon_use.name).gameObject.SetActive(false);
        }
    }
    */
    public void WeaponChange()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (weapon_now[0] != null)
            {
                if(weapon_use!=null) this.transform.Find(weapon_use.name).gameObject.SetActive(false);
                weapon_use = weapon_now[0];
                this.transform.Find(weapon_use.name).gameObject.SetActive(true);
                man.weapon_use = weapon_use;
            }
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            if (weapon_now[1] != null)
            {
                if (weapon_use != null)  this.transform.Find(weapon_use.name).gameObject.SetActive(false);
                weapon_use = weapon_now[1];
                this.transform.Find(weapon_use.name).gameObject.SetActive(true);
                man.weapon_use = weapon_use;
            }
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            if (weapon_now[2] != null)
            {
                if (weapon_use != null)  this.transform.Find(weapon_use.name).gameObject.SetActive(false);
                weapon_use = weapon_now[2];
                this.transform.Find(weapon_use.name).gameObject.SetActive(true);
                man.weapon_use = weapon_use;
            }
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            if (weapon_now[3] != null)
            {
                if (weapon_use != null)  this.transform.Find(weapon_use.name).gameObject.SetActive(false);
                weapon_use = weapon_now[3];
                this.transform.Find(weapon_use.name).gameObject.SetActive(true);
                man.weapon_use = weapon_use;
            }
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            if (weapon_now[4] != null)
            {
                if (weapon_use != null)  this.transform.Find(weapon_use.name).gameObject.SetActive(false);
                weapon_use = weapon_now[4];
                this.transform.Find(weapon_use.name).gameObject.SetActive(true);
                man.weapon_use = weapon_use;
            }
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            if (weapon_now[5] != null)
            {
                if (weapon_use != null)  this.transform.Find(weapon_use.name).gameObject.SetActive(false);
                weapon_use = weapon_now[5];
                this.transform.Find(weapon_use.name).gameObject.SetActive(true);
                man.weapon_use = weapon_use;
            }
        }

    }

    public bool Addweapon(string name)
    {
        int i;
        for (i = 0; i < 6; i++)
        {
            if (weapon_now[i] != null&& weapon_now[i].name == name )
            {
                return false;
            }
        }
        for (i=0;i<6;i++)
        {
            if(weapon_now[i]==null)
            {
                weapon_now[i] = this.transform.Find(name).GetComponent<weapon>();
                UI.weaponimagechange(i, name);
                return true;            
            }
        }
        return false;
    }

}



