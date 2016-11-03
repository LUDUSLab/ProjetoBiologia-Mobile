using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public GameObject telaPause;


	void Start () {
	
	}
	

	void Update () {
        pausar();
	}

    void pausar()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            telaPause.SetActive(true);
        }
    }
}
