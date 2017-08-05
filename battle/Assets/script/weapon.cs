using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    public BoxCollider co;
    public Animation anima;

	public bool UseNow;

    private float atime=0;
	public string attackanima;

    public float atk;
    public float repulse;

	// Use this for initialization
	void Start () {
        anima = GetComponent<Animation>();
        co = GetComponent<BoxCollider>();
        co.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (anima.IsPlaying(attackanima) && co.enabled == false&&atime==0)
        {
            co.enabled = true;
            atime = 1;
        }
        else if (!anima.IsPlaying(attackanima) &&anima.enabled == true)
        {
            co.enabled = false;
        }

		
	}
    public void attack()
    {
        anima.CrossFade(attackanima);
        atime = 0;
    }

}
