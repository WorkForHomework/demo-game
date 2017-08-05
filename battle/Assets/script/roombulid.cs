using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class itspost
{
    public Vector3 post = new Vector3(0,0,0);
    public bool doroomexsit=false;

    public itspost()
    {
        Vector3 post = new Vector3(0, 0, 0);
        doroomexsit = false;
    }
}

class room
{
    public Vector3 post;
    public itspost postu;
    public itspost postd;
    public itspost postl;
    public itspost postr;
    public itspost postu_r;
    public itspost postd_r;
    public itspost postl_r;
    public itspost postr_r;
    // l; x62,y30.68,z24.2
    //r :x-28,y30,68,z24,2
    //u :x7,y,z68.7
    //d.z-1.4
    public room(Vector3 p)
    {
        post = p;
        postu = new itspost();
        postd = new itspost();
        postl = new itspost();
        postr = new itspost();
        postu.post = new Vector3(p.x, p.y, p.z + 69f);
        postd.post = new Vector3(p.x, p.y, p.z - 69f);
        postl.post = new Vector3(p.x - 89f, p.y, p.z);
        postr.post = new Vector3(p.x + 89f, p.y, p.z);
        postu_r = new itspost();
        postd_r = new itspost();
        postl_r = new itspost();
        postr_r = new itspost();

        postu_r.post = new Vector3(p.x + 6.2f, p.y , p.z + 68.7f);
        postd_r.post = new Vector3(p.x + 7.8f, p.y, p.z - 19.8f);
        postl_r.post = new Vector3(p.x -47.2f, p.y, p.z + 23.8f);
        postr_r.post = new Vector3(p.x +61.28f, p.y, p.z + 25.5f);

    }



}

public class roombulid : MonoBehaviour {

    public int room_sum=0;
    public int road_sum = 0;
    public GameObject room;
    public GameObject[] road;

    public float x_Distance;
    public float z_Distance;


    List<room> maze = new List<room>(); 
    public int maze_num=0;

    public int roadnum=0;


	//Use this for initialization
	void Start () {
        buildroom(new Vector3(0, 0, 0));
        while(maze_num < room_sum)
        {
            randombulid();
        }
        buildAllwall();
        

	}
	
	//Update is called once per frame
	void Update () {


		
	}


    void buildroom(Vector3 p)
    {
        room temp = new room(p);

        for (int i = 0; i < maze_num; i++)
        {
            if (maze[i].post == temp.postu.post)
            {
                maze[i].postd.doroomexsit = true;
                temp.postu.doroomexsit = true;
            }
            if (maze[i].post == temp.postd.post)
            {
                maze[i].postu.doroomexsit = true;
                temp.postd.doroomexsit = true;
            }

            if (maze[i].post == temp.postl.post)
            {
                maze[i].postr.doroomexsit = true;
                temp.postl.doroomexsit = true;
            }
            if (maze[i].post == temp.postr.post)
            {
                maze[i].postl.doroomexsit = true;
                temp.postr.doroomexsit = true;
            }
        }


        maze.Add(temp);
        GameObject.Instantiate(room, p, Quaternion.identity);
        maze_num++;
    }

    void randombulid()
    {
        int randomroom = Random.Range(0, maze_num);
        int randomdirection = 0;
        itspost temp_post = new itspost();
        temp_post.doroomexsit = true;
        if (maze[randomroom].postu.doroomexsit && maze[randomroom].postd.doroomexsit && maze[randomroom].postl.doroomexsit && maze[randomroom].postr.doroomexsit)
        {
            return;
        }
        else
        {
            while(temp_post.doroomexsit)
            {
                randomdirection = Random.Range(0, 4);
                switch (randomdirection)
                {
                    case 0: temp_post = maze[randomroom].postu; break;
                    case 1: temp_post = maze[randomroom].postd; break;
                    case 2: temp_post = maze[randomroom].postl; break;
                    case 3: temp_post = maze[randomroom].postr; break;
                }
            }        
            buildroom(temp_post.post);
            buildroad(maze[randomroom],randomdirection);
            return;
            
        }


    }

    void buildroad(room r0,int direction)
    {
        Quaternion u = Quaternion.Euler(0, 0, 0);
        Quaternion d = Quaternion.Euler(0, 180, 0);
        Quaternion l = Quaternion.Euler(0, -90, 0);
        Quaternion r = Quaternion.Euler(0, 90, 0);

        switch (direction)
        {
            case 0:
                GameObject.Instantiate(road[0], r0.postu_r.post,u);
                r0.postu_r.doroomexsit = true;
                break;
            case 1:
                GameObject.Instantiate(road[0], r0.postd_r.post,d);
                r0.postd_r.doroomexsit = true;
                break;
            case 2:
                GameObject.Instantiate(road[1], r0.postl_r.post,l);
                r0.postl_r.doroomexsit = true;
                break;
            case 3: GameObject.Instantiate(road[1], r0.postr_r.post,r);
                r0.postr_r.doroomexsit = true;
                break;
        }
        for (int i = 0; i < maze_num; i++)
        {
            if (direction == 0&&maze[i].post == r0.postu.post)
            {
                maze[i].postd_r.doroomexsit = true;
            }
            if (direction == 1 && maze[i].post == r0.postd.post)
            {
                maze[i].postu_r.doroomexsit = true;
            }
            if (direction == 2 && maze[i].post == r0.postl.post)
            {
                maze[i].postr_r.doroomexsit = true;
            }
            if (direction == 3 && maze[i].post == r0.postr.post)
            {
                maze[i].postl_r.doroomexsit = true;
            }
        }
        roadnum++;

    }

    void buildwall(room r0, int direction)
    {
        Quaternion u = Quaternion.Euler(0, 0, 0);
        Quaternion d = Quaternion.Euler(0, 180, 0);
        Quaternion l = Quaternion.Euler(0, -90, 0);
        Quaternion r = Quaternion.Euler(0, 90, 0);

        switch (direction)
        {
            case 0:
                GameObject.Instantiate(road[2], r0.postu_r.post, u);
                break;
            case 1:
                GameObject.Instantiate(road[2], r0.postd_r.post, d);
                break;
            case 2:
                GameObject.Instantiate(road[3], r0.postl_r.post, l);
                break;
            case 3:
                GameObject.Instantiate(road[3], r0.postr_r.post, r);
                break;
        }
    }

    void buildAllwall()
    {
        for(int i=0;i<maze_num;i++)
        {
            if(maze[i].postu_r.doroomexsit == false)
            {
                buildwall(maze[i], 0);
            }
            if (maze[i].postd_r.doroomexsit == false)
            {
                buildwall(maze[i], 1);
            }
            if (maze[i].postl_r.doroomexsit == false)
            {
                buildwall(maze[i], 2);
            }
            if (maze[i].postr_r.doroomexsit == false)
            {
                buildwall(maze[i], 3);
            }
        }
    }


        }
