using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Canoa : MonoBehaviour {

	public float velo, forcinhaPraPular;
	private indiozinho personagem;
	public bool goOrStay = true;
	public GameObject canoa, indio, balaoDuvida, soulIndio, fadezinho, Controller;
	bool tato = false;
	bool Gatilho = true;
    private bool click = false;
    private string resposta = "tocar", novaresposta;

	void Start(){
		personagem = indio.GetComponent<indiozinho>();
		personagem.goOrStay = false;
	}

	void Update () {
		Andando();
		stopRemo();
		goRemar();
		SairdoBarco();
        botaomobile();
        StartCoroutine(Tirarfade(3f));
    }

    IEnumerator Tirarfade(float tempinho)
    {
        yield return new WaitForSeconds(tempinho);
        fadezinho.SetActive(false);
    }

	void Andando()
	{
		if (goOrStay)
		{
			transform.Translate(Vector2.right * velo * Time.deltaTime);
			indio.GetComponent<Animator> ().SetBool ("parar", true);
			indio.GetComponent<Animator> ().SetBool ("remar", true);
			//Debug.Log("andando");
		}
	}

	void stopRemo(){
		if(indio.transform.position.x >=11.5 && indio.transform.position.x <=11.9 || indio.transform.position.x >=23.5 && indio.transform.position.x <=23.9
			|| indio.transform.position.x >=35.5 && indio.transform.position.x <=35.9)
		{
			if(tato == false)
			{
				balaoDuvida.SetActive (true);
				goOrStay = false;
				indio.GetComponent<Animator>().SetBool("remando", false);
				tato = true;
			}
		}

	}

    void botaomobile()
    {
        if (indio.transform.position.x >= 11.5 && indio.transform.position.x <= 35.9 && click)
        {
            click = false;
            if (resposta != novaresposta)
            {
                Debug.Log("entrou nesse game over aqui de agr");
                SceneManager.LoadScene("GameOver");
            }
            else if (resposta == novaresposta)
            {
                balaoDuvida.SetActive(false);
                goOrStay = true;
                indio.GetComponent<Animator>().SetBool("remando", true);
                Invoke("AtivarTato", 1f);
                Controller.GetComponent<Score>().Addscore();
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

    void goRemar()
	{
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			if (indio.transform.position.x >= 11.5 && indio.transform.position.x <= 11.9 || indio.transform.position.x >=23.5 && indio.transform.position.x <=23.9
				|| indio.transform.position.x >=35.5 && indio.transform.position.x <=35.9)
			{
				balaoDuvida.SetActive(false);
				goOrStay = true;
				indio.GetComponent<Animator>().SetBool("remando", true);
				Invoke("AtivarTato", 3f);
                GetComponent<Score_Fase3>().Addscore();

            }
		}
		else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha4))
		{
			if (indio.transform.position.x >= 11.5 && indio.transform.position.x <= 11.9 || indio.transform.position.x >=23.5 && indio.transform.position.x <=23.9
				|| indio.transform.position.x >=35.5 && indio.transform.position.x <=35.9)
			{
				SceneManager.LoadScene("gameOver");
			}
		}

	}

	void AtivarTato(){
		tato = false;

	}

	void SairdoBarco(){
		
		if(canoa.transform.position.x >=52.2 && canoa.transform.position.x <=52.4)
		{
			if(Gatilho == true){
				goOrStay = false;
				indio.transform.SetParent(soulIndio.transform);
				indio.GetComponent<Animator>().SetBool("parar", false);
				indio.GetComponent<Animator>().SetBool("pulando", true);
				Vector2 direcaoPulo = new Vector2(0.5f, 0.7f);
				direcaoPulo.Normalize();
				indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
				indio.GetComponent<Animator> ().SetBool ("remar", false);
			Invoke("VoltaraAndar", 2);
				Gatilho = false;	
			}
		}


	}

	void VoltaraAndar(){
	
		personagem.goOrStay = true;
	}
}