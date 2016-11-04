using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Jatoba : MonoBehaviour {

	public GameObject jatobazinho, jatobazinhoConcreto, jatobaInvisivel, indio, balaoDuvida, 	barraTempoObject, balaoFome;
    private indiozinho personagem;
    bool paladar = false, nariz = false, parar = false;
	public float tempoBarrinha;
	private float tempoInicial;

    void Start () {
        personagem = indio.GetComponent<indiozinho>();
	}
	
	void Update () {
        jatobaCaindo();
		stopCheirar();
		goCheirar();
        stopJatoba();
        goJatoba();
    }

    void jatobaCaindo()
    {
        if (indio.transform.position.x >= 55.5 && indio.transform.position.x <= 55.9)
        {
            jatobazinho.SetActive(true);
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
                //KD ELE CHEIRANDO
                //Invoke("VoltaraAndar", 4);
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
