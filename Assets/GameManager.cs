using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnStartGame(string scene_name)
    {
        Debug.Log("jump to play scene");
        SceneManager.LoadScene(scene_name);
    }
}
