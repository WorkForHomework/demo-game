using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFllow : MonoBehaviour {

	public GameObject Target;

	public float speed;

	// Use this for initialization
	void Start () {
		Target = GameObject.Find("man");
		
	}

	// Update is called once per frame
	void Update () {
		keepFllow ();
	}
	public void keepFllow()
	{
		transform.LookAt (Target.transform.position);
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}
}
class Target
{
	public Vector3 position;
	public GameObject target;
}