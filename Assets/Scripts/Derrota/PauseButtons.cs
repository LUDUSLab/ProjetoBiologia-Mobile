using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour {

    public GameObject sairMesmo, sairPause;

	public void Menu()
	{
		SceneManager.LoadScene ("Menu");
	}

	public void Jogar()
	{
        Time.timeScale = 1;
        sairPause.SetActive(false);
	}

	public void SairJogo()
	{
		sairMesmo.SetActive(true);
	}

}
