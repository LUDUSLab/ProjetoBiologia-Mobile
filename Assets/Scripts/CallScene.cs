using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CallScene : MonoBehaviour {

    public string Menu;
    public string Fase1;
    public GameObject Pause;
    public GameObject Vitoria;
    public string Info;

    public void CallMenu()
    {
        SceneManager.LoadScene ("Menu");
    }

    public void CallFase1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene ("Fase1");
    }

    public void CallPause()
    {
        Time.timeScale = 0;
        Pause.SetActive(true);
    }

    public void ExitButton()
    {
        Time.timeScale = 1;
        Debug.Log("funcionooooou");
        Application.Quit();
    }

    /*    public void CallVitoria ()
        {
            Vitoria.SetActive(true);
        }
        */
     public void CallInfo()
     {
         SceneManager.LoadScene ("Info");
     }  

}
