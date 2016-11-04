using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pedrinha : MonoBehaviour {

	public GameObject indio, balaoDuvida, feedBackVisao, PedraConcreta, barraTempo;
	bool tato = false;
	bool visao = false;
	private indiozinho personagem;
	public float forcinhaPraPular;
    private bool click = false;
    private string resposta = "visao", novaresposta;

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
        botaomobile();
    }

    void botaomobile()
    {
        if (indio.transform.position.x >= 73.7 && indio.transform.position.x <= 73.9 && click)
        {
            click = false;
            if (resposta != novaresposta)
            {
                Debug.Log("entrou nesse game over aqui de agr do cipo");
                SceneManager.LoadScene("GameOver");
            }
            else if (resposta == novaresposta)
            {
                barraTempo.SetActive(false);
                indio.GetComponent<Animator>().SetBool("parar", false);
                balaoDuvida.SetActive(false);
                feedBackVisao.SetActive(false);
                PedraConcreta.SetActive(true);
                personagem.goOrStay = true;
                GetComponent<Score>().Addscore();
            }
        }
        else if (indio.transform.position.x >= 77.6 && indio.transform.position.x <= 77.8 && click)
        {
            click = false;
            if (resposta != novaresposta)
            {
                Debug.Log("entrou nesse game over aqui de agr do cipo");
                SceneManager.LoadScene("GameOver");
            }
            else if (resposta == novaresposta)
            {
                barraTempo.SetActive(false);
                balaoDuvida.SetActive(false);
                Vector2 direcaoPulo = new Vector2(0.2f, 0.8f);
                direcaoPulo.Normalize();
                indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
                indio.GetComponent<Animator>().SetBool("pulando", true);
                Invoke("VoltaraAndar", 0.6f);
                GetComponent<Score>().Addscore();
            }
        }
    }

    public void usarmao()
    {
        if (indio.transform.position.x >= 73.7 && indio.transform.position.x <= 73.9 || indio.transform.position.x >= 77.6 && indio.transform.position.x <= 77.8)
        {
            novaresposta = "tocar";
            click = true;
        }
    }

    public void usaraudicao()
    {
        if (indio.transform.position.x >= 73.7 && indio.transform.position.x <= 73.9 || indio.transform.position.x >= 77.6 && indio.transform.position.x <= 77.8)
        {
            novaresposta = "audicao";
            click = true;
        }
    }

    public void usarolfato()
    {
        if (indio.transform.position.x >= 73.7 && indio.transform.position.x <= 73.9 || indio.transform.position.x >= 77.6 && indio.transform.position.x <= 77.8)
        {
            novaresposta = "olfato";
            click = true;
        }
    }

    public void usarvisao()
    {
        if (indio.transform.position.x >= 73.7 && indio.transform.position.x <= 73.9 || indio.transform.position.x >= 77.6 && indio.transform.position.x <= 77.8)
        {
            novaresposta = "visao";
            click = true;
        }
    }

    public void usarpaladar()
    {
        if (indio.transform.position.x >= 73.7 && indio.transform.position.x <= 73.9 || indio.transform.position.x >= 77.6 && indio.transform.position.x <= 77.8)
        {
            novaresposta = "paladar";
            click = true;
        }
    }

    void stopOlhar()
	{
		if(indio.transform.position.x >=73.7 && indio.transform.position.x <=73.9)
		{
			if(visao == false)
			{
				barraTempo.SetActive(true);
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
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			if (indio.transform.position.x >= 73.7 && indio.transform.position.x <= 73.9)
			{
				barraTempo.SetActive(false);
				indio.GetComponent<Animator>().SetBool("parar", false);
				balaoDuvida.SetActive(false);
				feedBackVisao.SetActive (false);
				PedraConcreta.SetActive(true);
				personagem.goOrStay = true;
				GetComponent<Score>().Addscore();
			}
		}
		else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
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
                resposta = "tocar";
				barraTempo.SetActive(true);				
				balaoDuvida.SetActive (true);
				personagem.goOrStay = false;
				indio.GetComponent<Animator>().SetBool("parar", true);
				tato = true;
			}
		}
	}

	void GoTato(){

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			if (indio.transform.position.x >= 77.6 && indio.transform.position.x <= 77.8)
			{
				barraTempo.SetActive(false);
				balaoDuvida.SetActive(false);
				Vector2 direcaoPulo = new Vector2(0.2f, 0.8f);
				direcaoPulo.Normalize();
				indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
				indio.GetComponent<Animator>().SetBool("pulando", true);
				Invoke("VoltaraAndar", 0.6f);
				GetComponent<Score>().Addscore();
			}
		}
		else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha4))
		{
			if (indio.transform.position.x >= 77.6 && indio.transform.position.x <= 77.8)
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

