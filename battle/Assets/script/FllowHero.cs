using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FllowHero : MonoBehaviour
{

    public GameObject Target;

    public float x;
    public float y;
    public float z;

    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Target.transform.position.x + x,y, Target.transform.position.z + z);
    }
}