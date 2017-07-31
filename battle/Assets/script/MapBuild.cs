using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuild : MonoBehaviour
{
    public GameObject Tree;
    public GameObject Wall;
    public GameObject Enemy;
    public float TreePro;
    public float WallPro;
    public float Enemypro;

    public int x;
    public int y;
    public int length;
    public int width;

    Node[,] NodeList;
    Wall[,] WallListi;
    Wall[,] WallListj;
    Tree[,] TreeListi;
    Tree[,] TreeListj;
    Enemy[,] EnemyListi;
    Enemy[,] EnemyListj;
    // Use this for initialization
    void Start()
    {
        SetRoom();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetRoom()
    {
        length = (int)this.transform.position.x;
        width = (int)this.transform.position.z;
        NodeList = new Node[x, y];
        WallListi = new Wall[x, y];
        WallListj = new Wall[y, x];
        TreeListi = new Tree[x, y];
        TreeListj = new Tree[y, x];
        for (int i = length; i < length + x; i++)
            for (int j = width; j < width + y; j++)
            {
				Vector3 position = new Vector3 (i, this.transform.position.y, j);
                Node node = new Node();
                node.WallList = new List<Wall>();
                node.TreeList = new List<Tree>();
                node.position = position;
                NodeList[i - length, j - width] = node;
            }
        for (int i = 0; i < x; i += 10)
            for (int j = 0; j < y; j += 10)
            {

                if (Random.Range(0, 100) < WallPro && NodeList[i, j].CanNot == true)
                {
                    GameObject Walli = Instantiate(Wall) as GameObject;
                    if (Random.Range(0, 10) > 5)
                    {
                        Walli.transform.eulerAngles = new Vector3(0, 90, 0);
                    }
                    Walli.transform.position = NodeList[i, j].position;
                    NodeList[i, j].CanNot = false;
                }
                if (Random.Range(0, 100) < TreePro && NodeList[i, j].CanNot == true)
                {
                    GameObject Treei = Instantiate(Tree) as GameObject;
                    Treei.transform.position = NodeList[i, j].position;
                    NodeList[i, j].CanNot = false;
                }
                if (Random.Range(0, 100) < Enemypro && NodeList[i, j].CanNot == true)
                {
                    GameObject Enemyi = Instantiate(Enemy) as GameObject;
                    Enemyi.transform.position = NodeList[i, j].position;
                    NodeList[i, j].CanNot = false;
                }
            }
    }

}


class Node
{
    public Vector3 position;
    public bool CanNot;
    public List<Wall> WallList;
    public List<Tree> TreeList;
    public Node()
    {
        CanNot = true;
    }
}
class Wall
{
    public GameObject wall;
    public bool CanSetAgain;
    public List<Node> NodeList;
    public Wall()
    {
        CanSetAgain = true;
    }
}
class Tree
{
    public GameObject wall;
    public bool CanSetAgain;
    public List<Node> NodeList;
    public Tree()
    {
        CanSetAgain = true;
    }
}
class Enemy
{
    public GameObject enemy;
    public bool CanSetAgain;
    public List<Node> NodeList;
    public Enemy()
    {
        CanSetAgain = true;
    }
}