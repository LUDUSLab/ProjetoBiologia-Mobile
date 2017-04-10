using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CheirarFlor : MonoBehaviour {

	public GameObject  indio, balaoDuvida, 	barraTempoObject, flores;
	private indiozinho personagem;
	bool nariz = false, parar = false;
	public string cheirar = "event:/Cheirar"; //import audio asset fmod
    private bool click = false;
    private string resposta = "olfato", novaresposta;
	//public float tempoBarrinha;
	//private float tempoInicial;
	// Use this for initialization
	void Start () {
		personagem = indio.GetComponent<indiozinho>();
	}
	
	// Update is called once per frame
	void Update () {
		stopCheirar();
		goCheirar();
        botaomobile();
    }
	void stopCheirar()
	{
		if(indio.transform.position.x >=96.1 && indio.transform.position.x <= 96.4)
		{
			if(nariz == false)
			{
				barraTempoObject.SetActive (true);
				balaoDuvida.SetActive (true);
				personagem.goOrStay = false;
				indio.GetComponent<Animator>().SetBool("parar", true);
				indio.GetComponent<Animator>().SetBool("cheirar", true);
				nariz = true;
			}
		}
	}

    public void usarmao()
    {
        if (indio.transform.position.x >= 96.1 && indio.transform.position.x <= 96.4)
        {
            novaresposta = "tocar";
            click = true;
        }
    }

    public void usaraudicao()
    {
        if (indio.transform.position.x >= 96.1 && indio.transform.position.x <= 96.4)
        {
            novaresposta = "audicao";
            click = true;
        }
    }

    public void usarolfato()
    {
        if (indio.transform.position.x >= 96.1 && indio.transform.position.x <= 96.4)
        {
            novaresposta = "olfato";
            click = true;
        }
    }

    public void usarvisao()
    {
        if (indio.transform.position.x >= 96.1 && indio.transform.position.x <= 96.4)
        {
            novaresposta = "visao";
            click = true;
        }
    }

    public void usarpaladar()
    {
        if (indio.transform.position.x >= 96.1 && indio.transform.position.x <= 96.4)
        {
            novaresposta = "paladar";
            click = true;
        }
    }

    void botaomobile()
    {
        if (indio.transform.position.x >= 96.1 && indio.transform.position.x <= 96.4 && click)
        {
            click = false;
            if (resposta != novaresposta)
            {
                Debug.Log("entrou nesse game over aqui de agr da escalada");
                SceneManager.LoadScene("GameOver");
            }
            else if (resposta == novaresposta)
            {
                balaoDuvida.SetActive(false);
                barraTempoObject.SetActive(false);
                indio.GetComponent<Animator>().SetBool("pegar", true);
                indio.GetComponent<Animator>().SetBool("parar", false);
                GetComponent<Score>().Addscore();
                Invoke("SumirFlor", 2);
            }
        }
    }

    void goCheirar()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			if(indio.transform.position.x >=96.1 && indio.transform.position.x <= 96.4)
			{
				balaoDuvida.SetActive (false);
				barraTempoObject.SetActive(false);
				//personagem.goOrStay = true;
				//indio.GetComponent<Animator>().SetBool("cheirar", false);
				indio.GetComponent<Animator>().SetBool("pegar", true);
				indio.GetComponent<Animator>().SetBool("parar", false);
				FMODUnity.RuntimeManager.PlayOneShot (cheirar);
				GetComponent<Score>().Addscore();
				//KD ELE CHEIRANDO
				Invoke("SumirFlor", 2);
			}
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
		{
			if (indio.transform.position.x >= 94.1 && indio.transform.position.x <= 94.4)
			{
				
				SceneManager.LoadScene("gameOver");
			}
		}
	}

	void SumirFlor(){
		flores.SetActive(false);
		indio.GetComponent<Animator>().SetBool("pegar", false);
		indio.GetComponent<Animator>().SetBool("parar", false);
		personagem.goOrStay = true;
	}
}
