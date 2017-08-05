using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponUI : MonoBehaviour {

    public Sprite[] weapon;
    public Image[] weapon_image;
    public Sprite nothing;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void weaponimagechange(int i,string name)
    {
        Sprite temp = nothing;
        for(int r = 0;r<weapon.Length;r++)
        {
            if(weapon[r].name==name)
            {
                temp = weapon[r];
                break;
            }
        }
        weapon_image[i].sprite = temp;
    }
}
