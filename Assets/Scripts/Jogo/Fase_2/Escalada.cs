using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Escalada : MonoBehaviour {

    public GameObject indio, balaoDuvida, barraTempo;
    bool tato = false;
    private indiozinho personagem;
	public float forcinhaPraPular;
	public string pulo = "event:/pulo";
    public string resposta;
    private string novaresposta;
    private bool click = false;

	// Use this for initialization
	void Start () {
        personagem = indio.GetComponent<indiozinho>();
    }
	
	// Update is called once per frame
	void Update () {
        stopTato();
		goEscalada();
        botaomobile();
	}

    void stopTato()
    {
        if(indio.transform.position.x >=4.3 && indio.transform.position.x <=4.7)
        {
            if(tato == false)
            {
				balaoDuvida.SetActive (true);
                barraTempo.SetActive(true);
                personagem.goOrStay = false;
                indio.GetComponent<Animator>().SetBool("parar", true);
                tato = true;
            }
        }
    }



    void botaomobile()
    {
        if(indio.transform.position.x >= 4.3 && indio.transform.position.x <= 4.7 && click)
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
                barraTempo.SetActive(false);
                Vector2 direcaoPulo = new Vector2(0.1f, 0.7f);
                direcaoPulo.Normalize();
                indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
                this.GetComponent<Escalada>().enabled = false;
                indio.GetComponent<Animator>().SetBool("pulando", true);
                Invoke("VoltaraAndar", 0.6f);
                GetComponent<Score>().Addscore();
            }
        }
    }


    public void usarmao()
    {
        novaresposta = "tocar";
        click = true;
    }

    public void usaraudicao()
    {
        novaresposta = "audicao";
        click = true;
    }

    public void usarolfato()
    {
        novaresposta = "olfato";
        click = true;
    }

    public void usarvisao()
    {
        novaresposta = "visao";
        click = true;
    }

    public void usarpaladar()
    {
        novaresposta = "paladar";
        click = true;
    }


	void goEscalada()
	{
		if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (indio.transform.position.x >= 4.3 && indio.transform.position.x <= 4.7)
            {
				FMODUnity.RuntimeManager.PlayOneShot (pulo);
                balaoDuvida.SetActive(false);
                barraTempo.SetActive(false);
                Vector2 direcaoPulo = new Vector2(0.1f, 0.7f);
                direcaoPulo.Normalize();
                indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
                this.GetComponent<Escalada>().enabled = false;
                indio.GetComponent<Animator>().SetBool("pulando", true);
                Invoke("VoltaraAndar", 0.6f);
				GetComponent<Score>().Addscore();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (indio.transform.position.x >= 4.3 && indio.transform.position.x <= 4.7)
            {
                SceneManager.LoadScene("gameOver");
            }
        }

	}

	void VoltaraAndar(){
		personagem.goOrStay = true;
		indio.GetComponent<Animator>().SetBool("parar", false);
		indio.GetComponent<Animator>().SetBool("pulando", false);
	}
}
