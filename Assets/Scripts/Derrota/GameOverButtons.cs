using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverButtons : MonoBehaviour {

    private string tryAgain;
    public Text highScoreText;
    public Text scoreText;
    public GameObject hudSair, fade;

    void Start()
    {
        tryAgain = PlayerPrefs.GetString("faseAtual");
        Score.FinalScore();
        ViewScore();
        Invoke("tirarFade", 1.5f);
    }

    void tirarFade ()
    {
        fade.SetActive(false);
    }

	public void Menu()
	{
		SceneManager.LoadScene ("Menu");
	}

	public void jogarNovamente()
	{
		SceneManager.LoadScene (tryAgain);
	}

    
    public void ProximaFase()
    {
        if( tryAgain == "Fase1")
        {
            SceneManager.LoadScene("CenarioBonito");
        }
        else if( tryAgain == "CenarioBonito")
        {
            SceneManager.LoadScene("Fase3");
        }
        else if( tryAgain == "Fase3")
        {
            SceneManager.LoadScene("Manu");
        }
    }
  

    public void Sair()
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

    void ViewScore()
    {
        highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
        int localScore = (int)Score.score;
        scoreText.text = localScore.ToString();
    }

}
