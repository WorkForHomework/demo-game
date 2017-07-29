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
        postu.post = new Vector3(p.x, p.y, p.z + 70f);
        postd.post = new Vector3(p.x, p.y, p.z - 70f);
        postl.post = new Vector3(p.x - 90f, p.y, p.z);
        postr.post = new Vector3(p.x + 90f, p.y, p.z);
        postu_r = new itspost();
        postd_r = new itspost();
        postl_r = new itspost();
        postr_r = new itspost();

        postu_r.post = new Vector3(p.x + 7f, p.y - 30.68f, p.z + 68.7f);
        postd_r.post = new Vector3(p.x + 7f, p.y - 30.68f, p.z - 1.4f);
        postl_r.post = new Vector3(p.x -28f, p.y - 30.68f, p.z + 24.2f);
        postr_r.post = new Vector3(p.x +62f, p.y - 30.68f, p.z + 24.2f);

    }



}

public class roombulid : MonoBehaviour {

    public int room_sum=0;
    public int road_sum = 0;
    public GameObject room;
    public GameObject road;

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
            Debug.Log("nocreate");
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
        Quaternion d = Quaternion.Euler(0, 0, 0);
        Quaternion l = Quaternion.Euler(0, 90, 0);
        Quaternion r = Quaternion.Euler(0, 90, 0);

        switch (direction)
        {
            case 0:
                GameObject.Instantiate(road, r0.postu_r.post,u);
                r0.postu_r.doroomexsit = true;
                break;
            case 1:
                GameObject.Instantiate(road, r0.postd_r.post,d);
                r0.postd_r.doroomexsit = true;
                break;
            case 2:
                GameObject.Instantiate(road, r0.postl_r.post,l);
                r0.postl_r.doroomexsit = true;
                break;
            case 3: GameObject.Instantiate(road, r0.postr_r.post,r);
                r0.postr_r.doroomexsit = true;
                break;
        }
        Debug.Log("road");
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
    /* void randombuildroad(room r0)
    {
        if (roadnum > road_sum) return;
        itspost temp_post = new itspost();
        itspost temp_post2 = new itspost();
        temp_post.doroomexsit = true;
        int randomdirection = 0;
        while (temp_post.doroomexsit||!temp_post2.doroomexsit)
        {
            Debug.Log("random");
            randomdirection = Random.Range(0, 4);
            switch (randomdirection)
            {
                case 0: temp_post = r0.postu_r;temp_post2 = r0.postu; break;
                case 1: temp_post = r0.postd_r;temp_post2 = r0.postd; break;
                case 2: temp_post = r0.postl_r;temp_post2 = r0.postl; break;
                case 3: temp_post = r0.postr_r;temp_post2 = r0.postr; break;
            }
        }
        buildroad(r0, randomdirection);
        for (int i = 0; i < maze_num; i++)
        {
            if (randomdirection == 0 && maze[i].post == r0.postu.post)
            {
                randombuildroad(maze[i]);
                return;
            }
            if (randomdirection == 1 && maze[i].post == r0.postd.post)
            {
                randombuildroad(maze[i]);
                return;
            }
            if (randomdirection == 2 && maze[i].post == r0.postl.post)
            {
                randombuildroad(maze[i]);
                return;
            }
            if (randomdirection == 3 && maze[i].post == r0.postr.post)
            {
                randombuildroad(maze[i]);
                return;
            }
        }
    }
    */
    

}