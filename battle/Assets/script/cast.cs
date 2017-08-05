using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum casttype
{
    fireball,
    waterball,
}
public class cast : MonoBehaviour {

    public casttype type;

    public GameObject blood;
    public float speed = 20;

    public Animation waterball;

    
	// Use this for initialization
	void Start () {

        if(type == casttype.waterball)
        {
            waterball.CrossFade("waterball");
        }

	}

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update () {
        if(type==casttype.fireball)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(type == casttype.waterball&&!waterball.IsPlaying("waterball"))
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (type == casttype.fireball)
        {
            GameObject.Instantiate(blood, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
