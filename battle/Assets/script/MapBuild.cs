using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuild 
    : MonoBehaviour
{
    public GameObject Tree;
    public GameObject Wall;
    int x = 100;
    int y;
    Node[,] NodeList;
    Wall[,] WallListi;
    Wall[,] WallListj;
    Tree[,] TreeListi;
    Tree[,] TreeListj;
    // Use this for initialization
    void Start()
    {
        y = x - 1;
        NodeList = new Node[x, y];
        WallListi = new Wall[x, y];
        WallListj = new Wall[y, x];
        TreeListi = new Tree[x, y];
        TreeListj = new Tree[y, x];
        for (int i = 0; i < x; i+=5)
            for (int j = 0; j < y; j+=5)
            {
                Vector3 position = new Vector3(i, 0, j);
                Node node = new Node();
                node.WallList = new List<Wall>();
                node.TreeList = new List<Tree>();
                node.position = position;
                NodeList[i, j] = node;
            }
        for (int i = 0; i < x; i+=5)
            for (int j = 0; j < y; j+=5)
            {
                int number = Random.Range(0, 10);
                if (number > 8 && NodeList[i, j].CanNot == true)
                {
                    GameObject Walli = Instantiate(Wall) as GameObject;
                    if (Random.Range(0, 10) > 5)
                    {
                        Walli.transform.eulerAngles = new Vector3(0, 90, 0);
                    }
                    Walli.transform.position = new Vector3(i, 0, j);
                    NodeList[i, j].CanNot = false;
                }
                else if (number <4 && NodeList[i, j].CanNot == true)
                {
                    GameObject Treei = Instantiate(Tree) as GameObject;
                    Treei.transform.position = new Vector3(i, 0, j);
                }
            }
    }

    // Update is called once per frame
    void Update()
    {

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
    public int range = 5;
}
class Tree
{
    public GameObject tree;
    public bool CanSetAgain;
    public List<Node> NodeList;
    public int range = 2;
}