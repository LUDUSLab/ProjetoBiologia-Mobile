using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class goMenu : MonoBehaviour {

    public GameObject fade, fade2;

    private void Update()
    {
        Invoke("tirarFade", 1.5f);
    }

    public void voltarMenu()
    {
        fade.SetActive(true);
        Invoke("voltar", 1.5f);
    }

    void tirarFade()
    {
        fade2.SetActive(false);
    }

    void voltar()
    {
        SceneManager.LoadScene("Menu");
    }

}
