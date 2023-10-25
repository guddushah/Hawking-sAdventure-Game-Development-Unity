using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDScript : MonoBehaviour {
    
   
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayAgainBtn() {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void Play()
    {
      //  Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene("stephen");
    }
}
