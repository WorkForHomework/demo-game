using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    public GameObject door_co;
    public bool ismanexsit=false;
    public bool isenemyexsit = false;
    private float timer = 0;

	// Use this for initialization
	void Start () {


	}

    // Update is called once per frame
    void Update () {
        timer++;
        if(ismanexsit&&isenemyexsit)
        {
            door_co.SetActive(true);
        }
        else
        {
            door_co.SetActive(false);
        }
        if (timer == 50)
        {
            isenemyexsit = false;
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ismanexsit = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "enemy")
        {
            isenemyexsit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            ismanexsit = false;
    }

}
