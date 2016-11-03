using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pedrinha : MonoBehaviour {

	public GameObject indio, balaoDuvida, feedBackVisao, PedraConcreta;
	bool tato = false;
	bool visao = false;
	private indiozinho personagem;
	public float forcinhaPraPular;

	// Use this for initialization
	void Start () {
		personagem = indio.GetComponent<indiozinho>();
	}

	// Update is called once per frame
	void Update () {
		stopOlhar();
		goOlhar();
		stopTato();
		GoTato();
	}

	void stopOlhar()
	{
		if(indio.transform.position.x >=73.7 && indio.transform.position.x <=73.9)
		{
			if(visao == false)
			{
				balaoDuvida.SetActive (true);
				feedBackVisao.SetActive (true);
				personagem.goOrStay = false;
				indio.GetComponent<Animator>().SetBool("pulando", false);
				indio.GetComponent<Animator>().SetBool("parar", true);
				visao = true;
			}
		}
	}

	void goOlhar()
	{
		if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Q))
		{
			if (indio.transform.position.x >= 73.7 && indio.transform.position.x <= 73.9)
			{
				indio.GetComponent<Animator>().SetBool("parar", false);
				balaoDuvida.SetActive(false);
				feedBackVisao.SetActive (false);
				PedraConcreta.SetActive(true);
				personagem.goOrStay = true;
				//GetComponent<Score>().Addscore();
			}
		}
		else if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Keypad5))
		{
			if (indio.transform.position.x >= 73.7 && indio.transform.position.x <= 73.9)
			{
				SceneManager.LoadScene("gameOver");
			}
		}

	}
	void stopTato()
	{
		if(indio.transform.position.x >=77.6 && indio.transform.position.x <=77.8)
		{
			if(tato == false)
			{
				balaoDuvida.SetActive (true);
				personagem.goOrStay = false;
				indio.GetComponent<Animator>().SetBool("parar", true);
				tato = true;
			}
		}
	}

	void GoTato(){

		if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.W))
		{
			if (indio.transform.position.x >= 77.6 && indio.transform.position.x <= 77.8)
			{
				balaoDuvida.SetActive(false);
				Vector2 direcaoPulo = new Vector2(0.2f, 0.8f);
				direcaoPulo.Normalize();
				indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
				//this.GetComponent<Escalada>().enabled = false;
				indio.GetComponent<Animator>().SetBool("pulando", true);
				//personagem.goOrStay = true;
				Invoke("VoltaraAndar", 0.6f);
				//GetComponent<Score>().Addscore();
			}
		}
	}

	void VoltaraAndar(){
		personagem.goOrStay = true;
		indio.GetComponent<Animator>().SetBool("parar", false);
		indio.GetComponent<Animator>().SetBool("pulando", false);
	}
}

