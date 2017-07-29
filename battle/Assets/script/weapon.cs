using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    public BoxCollider co;
    public Animation anima;
    private float atime=0;

	// Use this for initialization
	void Start () {
        anima = GetComponent<Animation>();
        co.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (anima.IsPlaying("sword") && co.enabled == false&&atime==0)
        {
            co.enabled = true;
            atime = 1;
        }
        else if (!anima.IsPlaying("sword")&&anima.enabled == true)
        {
            co.enabled = false;
        }

		
	}
    public void attack()
    {
        anima.CrossFade("sword");
        atime = 0;
    }

}
