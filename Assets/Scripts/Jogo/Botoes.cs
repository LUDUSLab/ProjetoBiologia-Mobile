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

    IEnumerator Tirarfade(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        fadezinho.SetActive(false);
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
        if (indio.transform.position.x >= 25.5 && indio.transform.position.x <= 28.09)
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
        if (indio.transform.position.x >= 46.8 && indio.transform.position.x <= 46.9)
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
        if (indio.transform.position.x >= 63.9 && indio.transform.position.x <= 64.1)
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
        if (indio.transform.position.x >= 81.0 && indio.transform.position.x <= 81.1)
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

    public void ouvir()
    {
        if (indio.transform.position.x >= 6.9 && indio.transform.position.x <= 7.2)
        {
            balAud.SetActive(false);
            personagem.goOrStay = true;
            indio.GetComponent<Animator>().SetBool("parar", false);
            indio.GetComponent<Animator>().SetBool("escutar", false);
            GetComponent<Score>().Addscore();
        }
    }

    public void tocar()
    {
        if (indio.transform.position.x >= 25.5 && indio.transform.position.x <= 26.09)
        {
            balTato.SetActive(false);
            personagem.goOrStay = true;
            indio.GetComponent<Animator>().SetBool("parar", false);
            GetComponent<Score>().Addscore();
        }
    }

    public void olhar()
    {
        if (indio.transform.position.x >= 46.8 && indio.transform.position.x <= 46.9)
        {
            balVisao.SetActive(false);
            Vector2 direcaoPulo = new Vector2(0.8f, 0.9f);
            direcaoPulo.Normalize();
            indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
            //personagem.goOrStay = true;
            Invoke("VoltaraAndar", 0.8f);
            GetComponent<Score>().Addscore();
        }
    }

    public void cheirar()
    {
        if (indio.transform.position.x >= 63.9 && indio.transform.position.x <= 64.1)
        {
            balPaladar.SetActive(false);
            personagem.goOrStay = true;
            indio.GetComponent<Animator>().SetBool("parar", false);
            indio.GetComponent<Animator>().SetBool("cheirar", false);
            GetComponent<Score>().Addscore();
        }
    }

    public void comer()
    {
        if (indio.transform.position.x >= 81.0 && indio.transform.position.x <= 81.1)
        {
            flor.SetActive(false);
            balOlfato.SetActive(false);
            indio.GetComponent<Animator>().SetBool("comer", true);
            Invoke("VoltaraAndar", 1.5f);
            GetComponent<Score>().Addscore();
        }
    }
}
