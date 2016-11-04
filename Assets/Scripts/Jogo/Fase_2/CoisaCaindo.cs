using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CoisaCaindo : MonoBehaviour {

	public GameObject objetoCaindo, indio, balaoDuvida, barraTempo, folhas;
	bool audicao = false, parar = false;
	private indiozinho personagem;
	public float forcinhaPraPular;
    public string resposta;
    private string novaresposta;
    private bool click = false;

    void Start () {
		personagem = indio.GetComponent<indiozinho>();
	}


	void Update () {
		stopAudicao();
		goAudicao();
        botaomobile();
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

    void botaomobile()
    {
        if (indio.transform.position.x >= 35 && indio.transform.position.x <= 35.5 && click)
        {
            click = false;
            if (resposta != novaresposta)
            {
                Debug.Log("entrou nesse game over aqui de agr da escalada");
                SceneManager.LoadScene("GameOver");
            }
            else if (resposta == novaresposta)
            {
                Vector2 direcaoPulo = new Vector2(0.2f, 0.3f);
                direcaoPulo.Normalize();
                indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
                barraTempo.SetActive(false);
                balaoDuvida.SetActive(false);
                audicao = false;
                personagem.goOrStay = true;
                objetoCaindo.SetActive(false);
                indio.GetComponent<Animator>().SetBool("parar", false);
                parar = true;
                indio.GetComponent<Animator>().SetBool("escutar", false);
                GetComponent<Score>().Addscore();
            }
        }
    }

    public void usarmao()
    {
        if (indio.transform.position.x >= 35 && indio.transform.position.x <= 35.5)
        {
            novaresposta = "tocar";
            click = true;
        }
    }

    public void usaraudicao()
    {
        if (indio.transform.position.x >= 35 && indio.transform.position.x <= 35.5)
        {
            novaresposta = "audicao";
            click = true;
        }
    }

    public void usarolfato()
    {
        if (indio.transform.position.x >= 35 && indio.transform.position.x <= 35.5)
        {
            novaresposta = "olfato";
            click = true;
        }
    }

    public void usarvisao()
    {
        if (indio.transform.position.x >= 35 && indio.transform.position.x <= 35.5)
        {
            novaresposta = "visao";
            click = true;
        }
    }

    public void usarpaladar()
    {
        if (indio.transform.position.x >= 35 && indio.transform.position.x <= 35.5)
        {
            novaresposta = "paladar";
            click = true;
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
