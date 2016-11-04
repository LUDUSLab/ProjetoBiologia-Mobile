using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CoisaCaindo : MonoBehaviour {

	public GameObject objetoCaindo, indio, balaoDuvida, barraTempo, folhas;
	bool audicao = false, parar = false;
	private indiozinho personagem;
	public float forcinhaPraPular;

	void Start () {
		personagem = indio.GetComponent<indiozinho>();
	}


	void Update () {
		stopAudicao();
		goAudicao();
	}

	void goCair()
	{
		objetoCaindo.SetActive(true);
	}

	void stopAudicao()
	{
		if(indio.transform.position.x >= 35 && indio.transform.position.x <= 35.5 && parar == false)
		{
			if(audicao == false)
			{
				folhas.GetComponent<Animator> ().SetBool ("mover", true);
				barraTempo.SetActive (true);
				balaoDuvida.SetActive (true);
				personagem.goOrStay = false;
				indio.GetComponent<Animator>().SetBool("parar", true);
				indio.GetComponent<Animator>().SetBool("escutar", true);
				audicao = true;
				Invoke ("goCair", 1.7f);
			}
		}
	}

	void goAudicao()
	{
		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			if(audicao == true)
			{
				Vector2 direcaoPulo = new Vector2(0.2f, 0.3f);
				direcaoPulo.Normalize();
				indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
				barraTempo.SetActive (false);
				balaoDuvida.SetActive (false);
				audicao = false;
				personagem.goOrStay = true;
				objetoCaindo.SetActive(false);
				indio.GetComponent<Animator>().SetBool("parar", false);
				parar = true;
				indio.GetComponent<Animator>().SetBool("escutar", false);
                GetComponent<Score>().Addscore();
            }
		}
		else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha5))
		{
			if (indio.transform.position.x >= 35 && indio.transform.position.x <= 35.5)
			{
				SceneManager.LoadScene("gameOver");
			}
		}
	}


}
