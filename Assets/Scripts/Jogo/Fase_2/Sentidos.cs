using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Sentidos : MonoBehaviour {
    public string[] sentidos;
    private string RespostaAtual;
    public GameObject indio;
    public indiozinho personagem;

    void Start()
    {
        personagem = indio.GetComponent<indiozinho>();
    }

    public void SetAnswer(string answer)
    {
        if(answer == RespostaAtual)
        {
            personagem.goOrStay = true;
            if(RespostaAtual == "paladar")
            {
                SceneManager.LoadScene("Vitoria");
                Time.timeScale = 0;
            }
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void SetRespostaAtual(string newAnswer)
    {
        this.RespostaAtual = newAnswer;
    }
}
