using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour
{
    public int curlevel = 0;
    private static gameManager instagram;
	void Start ()
    {
		if(instagram == null)
        {
            DontDestroyOnLoad(gameObject);
            instagram = this;
        }
	}
	
	void Update ()
    {
		
	}

    public static void completelevel1()
    {
        instagram.curlevel++;
        SceneManager.LoadScene(instagram.curlevel);

    }
}
