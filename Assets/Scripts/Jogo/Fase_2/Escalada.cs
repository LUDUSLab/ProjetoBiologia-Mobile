using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Escalada : MonoBehaviour {

    public GameObject indio, balaoDuvida, barraTempo;
    bool tato = false;
    private indiozinho personagem;
	public float forcinhaPraPular;

	// Use this for initialization
	void Start () {
        personagem = indio.GetComponent<indiozinho>();
    }
	
	// Update is called once per frame
	void Update () {
        stopTato();
		goEscalada();
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

	void goEscalada()
	{
		if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (indio.transform.position.x >= 4.3 && indio.transform.position.x <= 4.7)
            {
                balaoDuvida.SetActive(false);
                barraTempo.SetActive(false);
                Vector2 direcaoPulo = new Vector2(0.1f, 0.7f);
                direcaoPulo.Normalize();
                indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
                this.GetComponent<Escalada>().enabled = false;
                indio.GetComponent<Animator>().SetBool("pulando", true);
                //personagem.goOrStay = true;
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
