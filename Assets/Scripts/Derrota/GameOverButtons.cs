using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverButtons : MonoBehaviour {

    private string tryAgain;
    public Text highScoreText;
    public Text scoreText;
    public GameObject hudSair;

    void Start()
    {
        tryAgain = PlayerPrefs.GetString("faseAtual");
        Score.FinalScore();
        ViewScore();
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
        SceneManager.LoadScene("CenarioBonito");
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
