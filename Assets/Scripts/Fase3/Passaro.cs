using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Passaro : MonoBehaviour {

	public GameObject indio, balaodeDuvida, barraTempo, fadeIn;
	bool audicao = false;
	private indiozinho personagem;

	void Start () {
		personagem = indio.GetComponent<indiozinho>();
	}

	void Update () {
		stopPassaro();
		goPassaro();
		fadezinho();
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
