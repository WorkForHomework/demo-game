using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTEXT1ButtonClick()
    {
        SceneManager.LoadScene("test");
    }

    public void OnTEXT2ButtonClick()
    {
        SceneManager.LoadScene("s");
    }

    public void OnTEXT3ButtonClick()
    {
        SceneManager.LoadScene("test3");
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    public void OnreturnButtonClik()
    {
        SceneManager.LoadScene("test_sum");
    }
}
