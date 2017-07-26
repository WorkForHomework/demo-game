using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum animaType
{
    y,
    x,
    z,
}
public class anima : MonoBehaviour {

    public AnimationCurve curve;
    public animaType type;
    public float randommark;
    public float range = 5;
    public Vector3 post;
    public GameObject animark;

    // Use this for initialization
    void Start () {
        randommark = Random.Range(0, 1f);
        post = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(type==animaType.z)
        {
            this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y, randommark+ animark.transform.position.z+ curve.Evaluate(Time.time)*range);
        }
        if (type == animaType.y)
        {
            this.transform.position = new Vector3(this.transform.position.x, post.y + curve.Evaluate(Time.time) * range, this.transform.position.z);
        }
        if(type==animaType.x)
        {
            this.transform.position = new Vector3(animark.transform.position.x+curve.Evaluate(Time.time) * range, transform.position.y, this.transform.position.z);
        }
    }
}
