using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnchoose : MonoBehaviour {

    public GameObject[] spawn;
    public int max;
    public int min;
    // Use this for initialization
    private void Awake()
    {
        int random = Random.Range(min,max);
        spawn[random].SetActive(true);
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
