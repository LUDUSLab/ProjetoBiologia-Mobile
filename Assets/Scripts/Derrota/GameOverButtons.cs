using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverButtons : MonoBehaviour {

    private string tryAgain;
    public Text highScoreText;
    public Text scoreText;
    public GameObject fade, fadeIn;

    void Start()
    {
        tryAgain = PlayerPrefs.GetString("faseAtual");
        Score.FinalScore();
        ViewScore();
        Invoke("tirarFade", 2.2f);
    }

    /*void tirarFade ()
    {
        fade.SetActive(false);
    }*/

	public void Menu()
	{
        fadeIn.SetActive(true);
        Invoke("goMenu", 1.5f);
	}

    void goMenu()
    {
        SceneManager.LoadScene("Menu");
    }

	public void jogarNovamente()
	{
        fadeIn.SetActive(true);
        Invoke("deNovo", 1.5f);
    }

    void deNovo()
    {
        SceneManager.LoadScene(tryAgain);
    }

    
    public void ProximaFase()
    {
        fadeIn.SetActive(true);
        Invoke("nexttoPlay", 1.5f);
    }

    void nexttoPlay()
    {
        if (tryAgain == "Fase1")
        {
            SceneManager.LoadScene("CenarioBonito");
        }
        else if (tryAgain == "CenarioBonito")
        {
            SceneManager.LoadScene("Fase3");
        }
        else if (tryAgain == "Fase3")
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void ViewScore()
    {
        highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
        int localScore = (int)Score.score;
        scoreText.text = localScore.ToString();
    }

}
