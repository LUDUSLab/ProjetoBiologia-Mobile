using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Tronco : MonoBehaviour {

	public GameObject indio, balaoDuvida, barraTempo;
	bool tato = false;
	private indiozinho personagem;
	public float forcinhaPraPular;
	public GameObject tronco;

	// Use this for initialization
	void Start () {
		personagem = indio.GetComponent<indiozinho>();
		indio.GetComponent<Animator>().SetBool("cheirar", false);
	}
	
	// Update is called once per frame
	void Update () {
		stopTato();
		goEscalada();

	
	}
	void stopTato()
	{
		if(indio.transform.position.x >=113.0 && indio.transform.position.x <=113.4)
		{
			indio.GetComponent<Animator>().SetBool("cheirar", false);
			if(tato == false)
			{
				barraTempo.SetActive(true);
				balaoDuvida.SetActive (true);
				personagem.goOrStay = false;
				indio.GetComponent<Animator>().SetBool("parar", true);
				tato = true;
			}
		}
	}

	void goEscalada()
	{
		if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Q))
		{
			if (indio.transform.position.x >= 113.0 && indio.transform.position.x <= 113.4)
			{
				barraTempo.SetActive(false);
				balaoDuvida.SetActive(false);
				//Vector2 direcaoPulo = new Vector2(0.1f, 0.7f);
				//direcaoPulo.Normalize();
				//indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
				//this.GetComponent<Escalada>().enabled = false;
				indio.GetComponent<Animator>().SetBool("empurrar", true);
				Invoke("mudarOvalor", 2);
				//personagem.goOrStay = true;

				//GetComponent<Score>().Addscore();
			}
		}
		else if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Keypad5))
		{
			if (indio.transform.position.x >= 113.0 && indio.transform.position.x <= 113.4)
			{
				SceneManager.LoadScene("gameOver");
			}
		}

	}

	void mudarOvalor(){
		indio.GetComponent<Animator>().SetBool("empurrar", false);
		tronco.GetComponent<Rigidbody2D>().isKinematic = false;
		Invoke("PularOTronco", 2);
	}

	void PularOTronco(){
		Vector2 direcaoPulo = new Vector2(0.3f, 0.8f);
		direcaoPulo.Normalize();
		indio.GetComponent<Animator>().SetBool("pulando", true);
		indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
		Invoke("VoltaraAndar", 0.6f);
	}

	void VoltaraAndar(){
		indio.GetComponent<Animator>().SetBool("parar", false);
		personagem.goOrStay = true;
	}
}
