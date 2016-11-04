﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

    public GameObject hudSair, fadeIn;

    public void Play()
    {
        fadeIn.SetActive(true);
        Invoke("Jogar", 1.5f);
    }

    void Jogar()
    {
        SceneManager.LoadScene("Fase1");
    }

	public void Info()
	{
        fadeIn.SetActive(true);
        Invoke("cenaCreditos", 1.5f);
    }

    public void cenaCreditos()
    {
        SceneManager.LoadScene("Informacoes");
    }

    public void SairdoJogo()
    {
        hudSair.SetActive(true);
    }

    public void Sim()
    {
        fadeIn.SetActive(true);
        Invoke("goodbye", 1.5f);
    }

    void goodbye()
    {
        Application.Quit();
    }

    public void Nao()
    {
        hudSair.SetActive(false);
    }

}
