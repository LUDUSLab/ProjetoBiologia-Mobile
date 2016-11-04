using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [HideInInspector]
    public static float score, cont, addzinho = 2000;
    public Text scoreText;
    [HideInInspector]
    public static int highScore_fase1; // para mostrar o high score é só pegar essa variável


    void Start()
    {
        score = 0;
        cont = 0;
    }

    void Update()
    {
		cont += Time.deltaTime; // conta a pontuação de acordo com o tempo decorrido

        if (scoreText) // Atualiza somente se encontrar um componente de texto
            scoreText.text = "Pontuação: " + (int)score;
    }

	public void Addscore()
	{
		score += addzinho;
	}

    public static void FinalScore()
    {
        score = score / cont;
        highScore_fase1 = PlayerPrefs.GetInt("highScore", 0); // recupera o high score que é armazenado localmente
        if (score > highScore_fase1) // salva o high score, caso este seja alcançado
        {
            highScore_fase1 = (int)score;
            PlayerPrefs.SetInt("highScore", highScore_fase1);
        }

    }

}
