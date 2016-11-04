using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class goMenu : MonoBehaviour {

    public GameObject fade;
    
    public void voltarMenu()
    {
        fade.SetActive(true);
        Invoke("voltar", 1.5f);
    }

    void voltar()
    {
        SceneManager.LoadScene("Menu");
    }

}
