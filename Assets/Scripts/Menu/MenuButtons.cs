using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

    public GameObject hudSair;

    public void Play()
    {
        SceneManager.LoadScene("Fase1");
    }

	public void Info()
	{
		SceneManager.LoadScene ("Informacoes");
	}

    public void SairdoJogo()
    {
        hudSair.SetActive(true);
    }

    public void Sim()
    {
        Application.Quit();
    }

    public void Nao()
    {
        hudSair.SetActive(false);
    }

}
