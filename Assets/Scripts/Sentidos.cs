using UnityEngine;
using System.Collections;

public class Sentidos : MonoBehaviour {
    public string[] sentidos;
    private string RespostaAtual;
    public GameObject Vitoria;

    public void SetAnswer(string answer)
    {
        if(answer == RespostaAtual)
        {
            GetComponent<Moviment>().Move(true);
            if(RespostaAtual == "paladar")
            {
                Vitoria.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else
        {
            GetComponent<Moviment>().Move(false);
        }
    }
    public void SetRespostaAtual(string newAnswer)
    {
        this.RespostaAtual = newAnswer;
    }
}
