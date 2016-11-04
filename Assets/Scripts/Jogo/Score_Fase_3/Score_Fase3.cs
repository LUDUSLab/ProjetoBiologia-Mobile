using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score_Fase3 : MonoBehaviour {

    [HideInInspector]
    public static float score, cont, addzinho = 2000;
    public Text scoreText;
    [HideInInspector]
    public static int highScore_fase3; // para mostrar o high score é só pegar essa variável


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
        score += addzinho * 44;
    }

    public static void FinalScore()
    {
        score = score / cont;
        highScore_fase3 = PlayerPrefs.GetInt("highScore", 0); // recupera o high score que é armazenado localmente
        if (score > highScore_fase3) // salva o high score, caso este seja alcançado
        {
            highScore_fase3 = (int)score;
            PlayerPrefs.SetInt("highScore", highScore_fase3);
        }

    }
}
