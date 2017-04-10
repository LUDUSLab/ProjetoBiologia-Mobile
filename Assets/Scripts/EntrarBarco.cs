using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EntrarBarco : MonoBehaviour {

	public GameObject indio, canoa, fadeIn;
	private indiozinho personagem;
	bool barco = false;
	public float forcinhaPraPular;
	public string remar = "event:/Remar"; //import audio asset fmod

	// Use this for initialization
	void Start () {
		personagem = indio.GetComponent<indiozinho>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		stopTato();
	}

	void stopTato()
	{
		if(indio.transform.position.x >=85.1&& indio.transform.position.x <=85.8)
		{
			if(barco == false)
			{
				personagem.goOrStay = false;
				indio.GetComponent<Animator>().SetBool("parar", true);
				barco = true;
				Invoke("pularNoBarco", 2);

			}
		}
	}

	void pularNoBarco (){
		Vector2 direcaoPulo = new Vector2(0.5f, 0.7f);
		direcaoPulo.Normalize();
		indio.GetComponent<Animator>().SetBool("pulando", true);
		indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
		Invoke("ficarNoBarco", 0.6f);
	}

	void ficarNoBarco(){
		indio.transform.SetParent(canoa.transform);
		indio.GetComponent<Animator>().SetBool("pulando", false);
		indio.GetComponent<Animator>().SetBool("parar", true);
		Invoke("Navegar", 2);
	}

	void Navegar(){
		canoa.GetComponent<Animator>().SetBool("navegar", true);
		indio.GetComponent<Animator>().SetBool("remar", true);
		FMODUnity.RuntimeManager.PlayOneShot (remar);
		Invoke ("FadeIn", 3f);
	}

	void FadeIn(){
		fadeIn.SetActive (true);
        Invoke("GameOver", 1.5f);
		Debug.Log ("entrou no fadein");

    }

    void GameOver()
    {
        SceneManager.LoadScene("Vitoria");
    }
}
