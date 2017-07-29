using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFllow : MonoBehaviour
{

    public GameObject Target;
    public float follow_speed;
    public float distance;

    public Vector3 position_0;
    public Vector3 position_1;
    public Vector3 position_2;
    public int times = 0;

    public int move_x;
    public int move_y;
    public int move_z;
    public float free_speed;

    // Use this for initialization
    void Start()
    {
        position_0 = this.transform.position;
        position_1 = position_0;
        move_x = (int)position_1.x;
        move_y = (int)position_1.y;
        move_z = (int)position_1.z;
        Target = GameObject.Find("man");
    }

    // Update is called once per frame
    void Update()
    {
        FreeMove(FindOrNot(), CatchOrNot());
        FollowHero(FindOrNot());
    }

    public Vector3 GetHero()
    {
        return Target.transform.position;
    }

    public float Distance()
    {
        float a;
        float b;
        a = (GetHero().x - this.transform.position.x) * (GetHero().x - this.transform.position.x);
        b = (GetHero().z - this.transform.position.z) * (GetHero().z - this.transform.position.z);
        return (a + b);
    }

    public bool FindOrNot()
    {
        if (Distance() < distance * distance)
            return true;
        else
            return false;
    }

    public bool Catch()
    {
        if ((int)position_0.x + 1 == (int)position_1.x && (int)position_0.z + 1 == (int)position_1.z)
            return true;
        else if ((int)position_0.x - 1 == (int)position_1.x && (int)position_0.z + 1 == (int)position_1.z)
            return true;
        else if ((int)position_0.x - 1 == (int)position_1.x && (int)position_0.z - 1 == (int)position_1.z)
            return true;
        else if ((int)position_0.x + 1 == (int)position_1.x && (int)position_0.z - 1 == (int)position_1.z)
            return true;
        else if ((int)position_0.x == (int)position_1.x && (int)position_0.z + 1 == (int)position_1.z)
            return true;
        else if ((int)position_0.x == (int)position_1.x && (int)position_0.z - 1 == (int)position_1.z)
            return true;
        else if ((int)position_0.x == (int)position_1.x && (int)position_0.z == (int)position_1.z)
            return true;
        else if ((int)position_0.x + 1 == (int)position_1.x && (int)position_0.z == (int)position_1.z)
            return true;
        else if ((int)position_0.x - 1 == (int)position_1.x && (int)position_0.z == (int)position_1.z)
            return true;
        else
            return false;
    }

    public bool StopOrNot()
    {
        if ((int)position_0.x + 1 == (int)position_2.x && (int)position_0.z + 1 == (int)position_2.z)
            return true;
        else if ((int)position_0.x - 1 == (int)position_2.x && (int)position_0.z + 1 == (int)position_2.z)
            return true;
        else if ((int)position_0.x - 1 == (int)position_2.x && (int)position_0.z - 1 == (int)position_2.z)
            return true;
        else if ((int)position_0.x + 1 == (int)position_2.x && (int)position_0.z - 1 == (int)position_2.z)
            return true;
        else if ((int)position_0.x == (int)position_2.x && (int)position_0.z + 1 == (int)position_2.z)
            return true;
        else if ((int)position_0.x == (int)position_2.x && (int)position_0.z - 1 == (int)position_2.z)
            return true;
        else if ((int)position_0.x == (int)position_2.x && (int)position_0.z == (int)position_2.z)
            return true;
        else if ((int)position_0.x + 1 == (int)position_2.x && (int)position_0.z == (int)position_2.z)
            return true;
        else if ((int)position_0.x - 1 == (int)position_2.x && (int)position_0.z == (int)position_2.z)
            return true;
        else
            return false;
    }

    public bool CatchOrNot()
    {
        position_0 = this.transform.position;
        if (Catch())
            return true;
        else
            return false;
    }

    public void FreeMove(bool FindOrNot, bool CatchOrNot)
    {
        if (times >= 5 || (FindOrNot == false && CatchOrNot == true))
        {
            if (times >= 5)
            {
                times = 0;
            }
            int number = Random.Range(1, 100);
            if (number < 100)
            {
                move_x += Random.Range(-1, 2) * (Random.Range(10, 20));
                move_z += Random.Range(-1, 2) * (Random.Range(10, 20));
                position_1 = new Vector3(move_x, move_y, move_z);
            }
        }
        else if (FindOrNot == false && CatchOrNot == false)
        {
            position_2 = this.transform.position;
            if (StopOrNot())
            {
                times++;
            }
            this.transform.LookAt(position_1);
            transform.Translate(Vector3.forward * Time.deltaTime * follow_speed);
        }
    }

    public void FollowHero(bool FindOrNot)
    {
        if (FindOrNot == true)
        {
            transform.LookAt(Target.transform.position);
            transform.Translate(Vector3.forward * follow_speed * Time.deltaTime);
        }
    }

}