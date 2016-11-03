using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Botoes : MonoBehaviour {

    public GameObject balAud, balTato, balVisao, balPaladar, balOlfato, indio, pedrinha, moita, flor, fadezinho;
    bool audi=false, tato=false, visa=false, pala=false, olfa=false;
    private indiozinho personagem;
    public float forcinhaPraPular;



    void Start () {
        personagem = indio.GetComponent<indiozinho>();
        StartCoroutine(Tirarfade(3f));
	}
	
	void Update () {
        stopPassaro();
        goAudicao();
        stopPedra();
        goTato();
        stopBuraco();
        goVisao();
        stopUxi();
        goNariz();
        stopJatoba();
        goComer();
	}

    IEnumerator Tirarfade(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        fadezinho.SetActive(false);
    }

    void stopPassaro ()
    {
        if (indio.transform.position.x >= 6.9 && indio.transform.position.x <= 7.2)
        {
            if (audi == false)
            {
                personagem.goOrStay = false;
                audi = true;
                balAud.SetActive(true);
                indio.GetComponent<Animator>().SetBool("parar", true);
                indio.GetComponent<Animator>().SetBool("escutar", true);
            }
        }
    }

    void goAudicao()
    {
		if (Input.GetKeyDown(KeyCode.Keypad4)|| Input.GetKeyDown(KeyCode.R))
        {
            if(balAud.active == true)
            {
                balAud.SetActive(false);
                personagem.goOrStay = true;
                indio.GetComponent<Animator>().SetBool("parar", false);
                indio.GetComponent<Animator>().SetBool("escutar", false);
            }
        }
    }

    void stopPedra()
    {
        if (indio.transform.position.x >= 31.5 && indio.transform.position.x <= 31.7)
        {
            if (tato == false)
            {
                personagem.goOrStay = false;
                tato = true;
                balTato.SetActive(true);
                indio.GetComponent<Animator>().SetBool("parar", true);
            }
        }
    }

    void goTato()
    {
		if (Input.GetKeyDown(KeyCode.Keypad3)|| Input.GetKeyDown(KeyCode.E))
        {
            if (tato == true)
            {
                //pedrinha.SetActive(false);
                balTato.SetActive(false);
                personagem.goOrStay = true;
                indio.GetComponent<Animator>().SetBool("parar", false);
            }
        }
    }

    void stopBuraco()
    {
        if (indio.transform.position.x >= 51.6 && indio.transform.position.x <= 51.9)
        {
            if (visa == false)
            {
                personagem.goOrStay = false;
                visa = true;
                balVisao.SetActive(true);
                indio.GetComponent<Animator>().SetBool("parar", true);
            }
        }
    }

    private void invoke(string v)
    {
        throw new NotImplementedException();
    }

    void goVisao()
    {
		if (Input.GetKeyDown(KeyCode.Keypad5)|| Input.GetKeyDown(KeyCode.T))
        {
            if (balVisao.active == true)
            {
                Debug.Log("teste");
                balVisao.SetActive(false);
                Vector2 direcaoPulo = new Vector2(0.8f, 0.9f);
                direcaoPulo.Normalize();
                indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
                //personagem.goOrStay = true;
                Invoke("VoltaraAndar", 0.8f);
            }
        }
    }

    void stopUxi()
    {
        if (indio.transform.position.x >= 68.8 && indio.transform.position.x <= 69)
        {
            if (pala == false)
            {
                personagem.goOrStay = false;
                pala = true;
                balPaladar.SetActive(true);
                indio.GetComponent<Animator>().SetBool("parar", true);
                indio.GetComponent<Animator>().SetBool("cheirar", true);
            }
        }
    }

    void goNariz()
    {
		if (Input.GetKeyDown(KeyCode.Keypad1)|| Input.GetKeyDown(KeyCode.Q))
        {
            if (balPaladar.active == true)
            {
                balPaladar.SetActive(false);
                personagem.goOrStay = true;
                indio.GetComponent<Animator>().SetBool("parar", false);
                indio.GetComponent<Animator>().SetBool("cheirar", false);
            }
        }
    }

    void stopJatoba()
    {
        if (indio.transform.position.x >= 107.7 && indio.transform.position.x <= 107.9)
        {
            if (olfa == false)
            {
                personagem.goOrStay = false;
                olfa = true;
                balOlfato.SetActive(true);
                indio.GetComponent<Animator>().SetBool("parar", true);
            }
        }
    }

    void goComer()
    {
		if (Input.GetKeyDown(KeyCode.Keypad2)|| Input.GetKeyDown(KeyCode.W))
        {
            if (balOlfato.active == true)
            {
                flor.SetActive(false);
                balOlfato.SetActive(false);
                indio.GetComponent<Animator>().SetBool("comer", true);
                Invoke("VoltaraAndar", 1.5f);
            }
        }
    }

    void VoltaraAndar()
    {
        personagem.goOrStay = true;
        indio.GetComponent<Animator>().SetBool("parar", false);
        indio.GetComponent<Animator>().SetBool("comer", false);
    }

    public void audicao()
    {
        if (indio.transform.position.x >= 6.9 && indio.transform.position.x <= 7.2)
        {
            Debug.Log("entrou audicao");
            balAud.SetActive(false);
            personagem.goOrStay = true;
            indio.GetComponent<Animator>().SetBool("parar", false);
            indio.GetComponent<Animator>().SetBool("escutar", false);
        }
    }

    public void visao()
    {
        if (indio.transform.position.x >= 51.6 && indio.transform.position.x <= 51.9)
        {
            balVisao.SetActive(false);
            Vector2 direcaoPulo = new Vector2(0.8f, 0.9f);
            direcaoPulo.Normalize();
            indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
            Invoke("VoltaraAndar", 0.8f);
        }
    }

    public void tocar()
    {
        if (indio.transform.position.x >= 31.5 && indio.transform.position.x <= 31.7)
        {
            balTato.SetActive(false);
            personagem.goOrStay = true;
            indio.GetComponent<Animator>().SetBool("parar", false);
        }
    }

    public void olfato()
    {
        if (indio.transform.position.x >= 68.8 && indio.transform.position.x <= 69)
        {
            balPaladar.SetActive(false);
            personagem.goOrStay = true;
            indio.GetComponent<Animator>().SetBool("parar", false);
            indio.GetComponent<Animator>().SetBool("cheirar", false);
        }
    }

    public void paladar()
    {
        if (indio.transform.position.x >= 107.7 && indio.transform.position.x <= 107.9)
        {
            flor.SetActive(false);
            balOlfato.SetActive(false);
            indio.GetComponent<Animator>().SetBool("comer", true);
            Invoke("VoltaraAndar", 1.5f);
        }
    }

}
