using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuild : MonoBehaviour {
	public GameObject Tree;
	public GameObject Wall;
	public GameObject Enemy;
	public float TreePro;
	public float WallPro;
	public float Enemypro;
	public int TreeRange;
	public int WallRange;
	public int EnemyRange;
	public int x;
	public int y;
	Node[,] NodeList;
	Wall[,]WallListi;
	Wall[,]WallListj;
	Tree[,]TreeListi;
	Tree[,]TreeListj;
	Enemy[,]EnemyListi;
	Enemy[,]EnemyListj;
	// Use this for initialization
	void Start () {


		NodeList = new Node[x, y];
		WallListi = new Wall[x, y];
		WallListj = new Wall[y, x];
		TreeListi = new Tree[x, y];
		TreeListj = new Tree[y, x];
		for (int i = 0; i < x; i++)
			for (int j = 0; j < y; j++) {
				Vector3 position = new Vector3(i, 0, j);
				Node node = new Node();
				node.WallList = new List<Wall> ();
				node.TreeList = new List<Tree> ();
				node.position = position;
				NodeList[i, j] = node;
			}
		for (int i = 0; i < x; i+=10)
			for (int j = 0; j < y; j+=10) {
				if (j == 0 || j == y - 1) {
					GameObject Wally = Instantiate (Wall) as GameObject;
					Wally.transform.eulerAngles = new Vector3 (0, 90, 0);
					Wally.transform.position = new Vector3 (i, 0, j);
					NodeList [i, j].CanNot = false;
				} else if (i == 0 || i == x - 1) {
					GameObject Wallx = Instantiate (Wall) as GameObject;
					Wallx.transform.position = new Vector3 (i, 0, j);
					NodeList [i, j].CanNot = false;
				}
			}
		for (int i = 0; i < x; i+=10)
			for (int j = 0; j < y; j+=10) {

				if (Random.Range (0, 100) < WallPro && NodeList [i, j].CanNot == true) {
					GameObject Walli = Instantiate (Wall) as GameObject;
					if (Random.Range (0, 10) > 5) {
						Walli.transform.eulerAngles = new Vector3 (0, 90, 0);
					}
					Walli.transform.position = new Vector3 (i, 0, j);
					for (int x = i - WallRange; x < i + WallRange + 1; x++)
						for (int y = j - WallRange; y < j + WallRange + 1; y++) {
							NodeList [x, y].CanNot = false;
						}
				} 
				if (Random.Range (0, 100) < TreePro && NodeList [i, j].CanNot == true) {
					GameObject Treei = Instantiate (Tree) as GameObject;
					Treei.transform.position = new Vector3 (i, 0, j);
					for (int x = i - TreeRange; x < i + TreeRange + 1; x++)
						for (int y = j - TreeRange; y < j + TreeRange + 1; y++) {
							NodeList [x, y].CanNot = false;
						}
				}
				if (Random.Range (0, 100) < Enemypro && NodeList [i, j].CanNot == true) {
					GameObject Enemyi = Instantiate (Enemy)as GameObject;
					Enemyi.transform.position = new Vector3 (i, 0, j);
					NodeList [i, j].CanNot = false;
				}
			}
	}

	// Update is called once per frame
	void Update () {

	}
}
class Node
{
	public Vector3 position;
	public bool CanNot;
	public List<Wall>WallList;
	public List<Tree>TreeList;
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