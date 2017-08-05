using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum hptype
{
    nohp,
    hp,
}
public class HP : MonoBehaviour {

    public GameObject man;
    public charater man1;
    public Image image;

    public hptype type;
    public int hpnum = 1;
	// Use this for initialization
	void Start () {
        man = GameObject.Find("man");
        man1 = man.GetComponent<charater>();
        image = this.gameObject.GetComponent<Image>();

    }
	
	// Update is called once per frame
	void Update () {
        if(type == hptype.hp)
        {
            if(man1.hp>=hpnum&& image)
            {
                image.enabled = true;
            }
            else if(man1.hp<hpnum && this.gameObject.GetComponent<Image>().enabled)
            {
                image.enabled = false;
            }
        }

        if(type == hptype.nohp)
        {
            if (man1.hp_max >= hpnum&& image)
            {
                image.enabled = true;
            }
            else if (man1.hp_max < hpnum && image.enabled)
            {
                image.enabled = false;
            }
        }
		
	}
}
