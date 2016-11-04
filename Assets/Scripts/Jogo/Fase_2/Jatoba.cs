using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Jatoba : MonoBehaviour {

	public GameObject jatobazinho, jatobazinhoConcreto, jatobaInvisivel, indio, balaoDuvida, 	barraTempoObject, balaoFome;
    private indiozinho personagem;
    bool paladar = false, nariz = false, parar = false;
	public float tempoBarrinha;
	private float tempoInicial;
    private string resposta = "olfato";
    private string novaresposta;
    private bool click = false;

    void Start () {
        personagem = indio.GetComponent<indiozinho>();
	}
	
	void Update () {
        jatobaCaindo();
		stopCheirar();
		goCheirar();
        stopJatoba();
        goJatoba();
        botaomobile();
    }

    void jatobaCaindo()
    {
        if (indio.transform.position.x >= 55.5 && indio.transform.position.x <= 55.9)
        {
            jatobazinho.SetActive(true);
        }
    }

    void botaomobile()
    {
        if (indio.transform.position.x >= 63 && indio.transform.position.x <= 63.9 && click)
        {
            Debug.Log("entrou no botaozinho de vdd");
            click = false;
            if (resposta != novaresposta)
            {
                Debug.Log("entrou nesse game over aqui de agr do cipo");
                SceneManager.LoadScene("GameOver");
            }
            else if (resposta == novaresposta)
            {
                jatobaInvisivel.SetActive(false);
                jatobazinhoConcreto.SetActive(true);
                balaoDuvida.SetActive(false);
                nariz = false;
                barraTempoObject.SetActive(false);
                personagem.goOrStay = true;
                indio.GetComponent<Animator>().SetBool("cheirar", false);
                indio.GetComponent<Animator>().SetBool("parar", false);
                parar = true;
                GetComponent<Score>().Addscore();
            }
        }
        else if (indio.transform.position.x >= 65 && indio.transform.position.x <= 65.9 && click)
        {
            click = false;
            if (resposta != novaresposta)
            {
                Debug.Log("entrou nesse outro game over aqui de agr do cipo");
                SceneManager.LoadScene("GameOver");
            }
            else if (resposta == novaresposta)
            {
                jatobazinho.SetActive(false);
                barraTempoObject.SetActive(false);
                balaoFome.SetActive(false);
                paladar = false;
                this.GetComponent<Jatoba>().enabled = false;
                indio.GetComponent<Animator>().SetBool("comer", true);
                Invoke("VoltaraAndar", 4);
                parar = false;
                GetComponent<Score>().Addscore();
            }
        }
    }

    public void usarmao()
    {
        if (indio.transform.position.x >= 65 && indio.transform.position.x <= 65.9 || indio.transform.position.x >= 63 && indio.transform.position.x <= 63.9)
        {
            novaresposta = "tocar";
            click = true;
        }
    }

    public void usaraudicao()
    {
        if (indio.transform.position.x >= 65 && indio.transform.position.x <= 65.9 || indio.transform.position.x >= 63 && indio.transform.position.x <= 63.9)
        {
            novaresposta = "audicao";
            click = true;
        }
    }

    public void usarolfato()
    {
        if (indio.transform.position.x >= 65 && indio.transform.position.x <= 65.9 || indio.transform.position.x >= 63 && indio.transform.position.x <= 63.9)
        {
            novaresposta = "olfato";
            click = true;
        }
    }

    public void usarvisao()
    {
        if (indio.transform.position.x >= 65 && indio.transform.position.x <= 65.9 || indio.transform.position.x >= 63 && indio.transform.position.x <= 63.9)
        {
            novaresposta = "visao";
            click = true;
        }
    }

    public void usarpaladar()
    {
        if (indio.transform.position.x >= 65 && indio.transform.position.x <= 65.9 || indio.transform.position.x >= 63 && indio.transform.position.x <= 63.9)
        {
            novaresposta = "paladar";
            click = true;
        }
    }

    void stopCheirar()
	{
		if(indio.transform.position.x >=63 && indio.transform.position.x <= 63.9 && parar == false)
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

	void goCheirar()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			if(nariz == true)
			{
				jatobaInvisivel.SetActive(false);
				jatobazinhoConcreto.SetActive (true);
				balaoDuvida.SetActive (false);
				nariz = false;
				barraTempoObject.SetActive(false);
				personagem.goOrStay = true;
				indio.GetComponent<Animator>().SetBool("cheirar", false);
				indio.GetComponent<Animator>().SetBool("parar", false);
				parar = true;
                GetComponent<Score>().Addscore();
            }
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha5))
		{
			if (indio.transform.position.x >= 63 && indio.transform.position.x <= 63.9)
			{
				Debug.Log("Batata Doce");
				SceneManager.LoadScene("gameOver");
			}
		}
	}

    void stopJatoba()
    {
		if(indio.transform.position.x >= 65 && indio.transform.position.x <= 65.9 && parar == true)
        {
            if(paladar == false)
            {
                resposta = "paladar";
                barraTempoObject.SetActive (true);
				balaoFome.SetActive (true);
                personagem.goOrStay = false;
				indio.GetComponent<Animator>().SetBool("parar", true);
                paladar = true;
            }
        }

    }
    
    void goJatoba()
    {
		if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(paladar == true)
            {
				jatobazinho.SetActive (false);
				barraTempoObject.SetActive (false);
				balaoFome.SetActive (false);
                paladar = false;
                this.GetComponent<Jatoba>().enabled = false;
				indio.GetComponent<Animator>().SetBool("comer", true);
				Invoke("VoltaraAndar", 4);
				parar = false;
                GetComponent<Score>().Addscore();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (indio.transform.position.x >= 65 && indio.transform.position.x <= 65.1)
            {
                SceneManager.LoadScene("gameOver");
            }
        }
    }

	void VoltaraAndar(){
		personagem.goOrStay = true;
		indio.GetComponent<Animator>().SetBool("parar", false);
		indio.GetComponent<Animator>().SetBool("comer", false);
	}
}
