using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Passaro : MonoBehaviour {

	public GameObject indio, balaodeDuvida, barraTempo, fadeIn;
	bool audicao = false;
	private indiozinho personagem;
	private bool click = false;
	private string resposta = "audicao", novaresposta;

	void Start () {
		personagem = indio.GetComponent<indiozinho>();
	}

	void Update () {
		stopPassaro();
		goPassaro();
		fadezinho();
		botaomobile ();
	}

	public void usarmao()
	{
		if (indio.transform.position.x >= 141.3 && indio.transform.position.x <= 141.5)
		{
			novaresposta = "tocar";
			click = true;
		}
	}

	public void usaraudicao()
	{
		if (indio.transform.position.x >= 141.3 && indio.transform.position.x <= 141.5)
		{
			novaresposta = "audicao";
			click = true;
		}
	}

	public void usarolfato()
	{
		if (indio.transform.position.x >= 141.3 && indio.transform.position.x <= 141.5)
		{
			novaresposta = "olfato";
			click = true;
		}
	}

	public void usarvisao()
	{
		if (indio.transform.position.x >= 141.3 && indio.transform.position.x <= 141.5)
		{
			novaresposta = "visao";
			click = true;
		}
	}

	public void usarpaladar()
	{
		if (indio.transform.position.x >= 141.3 && indio.transform.position.x <= 141.5)
		{
			novaresposta = "paladar";
			click = true;
		}
	}

	void botaomobile()
	{
		if(indio.transform.position.x >= 141.3 && indio.transform.position.x <= 141.5 && click)
		{
			click = false;
			if (resposta != novaresposta) 
			{
				Debug.Log ("entrou nesse game over aqui de agr do pássaro");
				SceneManager.LoadScene ("GameOver");
			} 
			else if (resposta == novaresposta) 
			{
				indio.GetComponent<Animator>().SetBool("escutar", false);
				balaodeDuvida.SetActive(false);
				barraTempo.SetActive(false);
				personagem.goOrStay = true;
				indio.GetComponent<Animator>().SetBool("parar", false);
				GetComponent<Score>().Addscore();
			}
		}
	}

	void stopPassaro()
	{
		if(indio.transform.position.x >= 141.3 && indio.transform.position.x <= 141.5)
		{
			if(audicao == false)
			{
				balaodeDuvida.SetActive(true);
				barraTempo.SetActive(true);
				personagem.goOrStay = false;
				indio.GetComponent<Animator>().SetBool("pulando", false);
				indio.GetComponent<Animator>().SetBool("parar", true);
				indio.GetComponent<Animator>().SetBool("escutar", true);
				audicao = true;
			}
		}
	}

	void goPassaro()
	{
		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			if(indio.transform.position.x >= 141.3 && indio.transform.position.x <= 141.5)
			{
				indio.GetComponent<Animator>().SetBool("escutar", false);
				balaodeDuvida.SetActive(false);
				barraTempo.SetActive(false);
				personagem.goOrStay = true;
				indio.GetComponent<Animator>().SetBool("parar", false);
                GetComponent<Score>().Addscore();

            }
		}
		else if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha5))
			{
				if(indio.transform.position.x >= 141.3 && indio.transform.position.x <= 141.5)
				{
					SceneManager.LoadScene("gameOver");
				}
			}
	}

	void fadezinho()
	{
		if(indio.transform.position.x >= 143 && indio.transform.position.x >= 144)
		{
			Invoke("ChamarFade", 1f);
		}
	}

	void ChamarFade()
	{
		fadeIn.SetActive(true);
		Invoke("Pontinhos", 1.5f);
	}

	void Pontinhos()
	{
		SceneManager.LoadScene("Vitoria");
	}
}
