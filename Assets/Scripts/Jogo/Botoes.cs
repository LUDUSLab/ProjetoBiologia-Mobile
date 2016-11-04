using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Botoes : MonoBehaviour {

    public GameObject balAud, balTato, balVisao, balPaladar, balOlfato, indio, pedrinha, moita, flor, botoes;
    bool audi=false, tato=false, visa=false, pala=false, olfa=false;
    private indiozinho personagem;
    public float forcinhaPraPular;



    void Start () {
        personagem = indio.GetComponent<indiozinho>();
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
                botoes.GetComponent<Animator>().Play("ouvido_Tuto");
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
		if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if(balAud.active == true)
            {
                botoes.GetComponent<Animator>().Play("Anim_Tuto");
                balAud.SetActive(false);
                personagem.goOrStay = true;
                indio.GetComponent<Animator>().SetBool("parar", false);
                indio.GetComponent<Animator>().SetBool("escutar", false);
                GetComponent<Score>().Addscore();
            }
        }
    }

    void stopPedra()
    {
        if (indio.transform.position.x >= 24.8 && indio.transform.position.x <= 24.9)
        {
            if (tato == false)
            {
                botoes.GetComponent<Animator>().Play("mao_Tuto");
                personagem.goOrStay = false;
                tato = true;
                balTato.SetActive(true);
                indio.GetComponent<Animator>().SetBool("parar", true);
            }
        }
    }

    void goTato()
    {
		if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (tato == true)
            {
                botoes.GetComponent<Animator>().Play("Anim_Tuto");
                balTato.SetActive(false);
                personagem.goOrStay = true;
                indio.GetComponent<Animator>().SetBool("parar", false);
                GetComponent<Score>().Addscore();
            }
        }
    }

    void stopBuraco()
    {
        if (indio.transform.position.x >= 46.1 && indio.transform.position.x <= 46.2)
        {
            if (visa == false)
            {
                botoes.GetComponent<Animator>().Play("olhos_Tuto");
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
		if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (balVisao.active == true)
            {
                botoes.GetComponent<Animator>().Play("Anim_Tuto");
                balVisao.SetActive(false);
                Vector2 direcaoPulo = new Vector2(0.8f, 0.9f);
                direcaoPulo.Normalize();
                indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
                Invoke("VoltaraAndar", 0.8f);
                GetComponent<Score>().Addscore();
            }
        }
    }

    void stopUxi()
    {
        if (indio.transform.position.x >= 64.6 && indio.transform.position.x <= 64.7)
        {
            if (pala == false)
            {
                botoes.GetComponent<Animator>().Play("nariz_Tuto");
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
		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (balPaladar.active == true)
            {
                botoes.GetComponent<Animator>().Play("Anim_Tuto");
                balPaladar.SetActive(false);
                personagem.goOrStay = true;
                indio.GetComponent<Animator>().SetBool("parar", false);
                indio.GetComponent<Animator>().SetBool("cheirar", false);
                GetComponent<Score>().Addscore();
            }
        }
    }

    void stopJatoba()
    {
        if (indio.transform.position.x >= 81.6 && indio.transform.position.x <= 81.7)
        {
            if (olfa == false)
            {
                botoes.GetComponent<Animator>().Play("boca_Tutp");
                personagem.goOrStay = false;
                olfa = true;
                balOlfato.SetActive(true);
                indio.GetComponent<Animator>().SetBool("parar", true);
            }
        }
    }

    void goComer()
    {
		if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (balOlfato.active == true)
            {
                botoes.GetComponent<Animator>().Play("Anim_Tuto");
                flor.SetActive(false);
                balOlfato.SetActive(false);
                indio.GetComponent<Animator>().SetBool("comer", true);
                Invoke("VoltaraAndar", 1.5f);
                GetComponent<Score>().Addscore();
            }
        }
    }

    void VoltaraAndar()
    {
        personagem.goOrStay = true;
        indio.GetComponent<Animator>().SetBool("parar", false);
        indio.GetComponent<Animator>().SetBool("comer", false);
    }

    public void ouvir ()
    {
        if (indio.transform.position.x >= 6.9 && indio.transform.position.x <= 7.2)
        {
            botoes.GetComponent<Animator>().Play("Anim_Tuto");
                balAud.SetActive(false);
                personagem.goOrStay = true;
                indio.GetComponent<Animator>().SetBool("parar", false);
                indio.GetComponent<Animator>().SetBool("escutar", false);
                GetComponent<Score>().Addscore();
        }
    }

    public void tocar()
    {
        if (indio.transform.position.x >= 24.8 && indio.transform.position.x <= 24.9)
        {
            botoes.GetComponent<Animator>().Play("Anim_Tuto");
                balTato.SetActive(false);
                personagem.goOrStay = true;
                indio.GetComponent<Animator>().SetBool("parar", false);
                GetComponent<Score>().Addscore();
        }
    }

    public void ver()
    {
        if (indio.transform.position.x >= 46.1 && indio.transform.position.x <= 46.2)
        {
            botoes.GetComponent<Animator>().Play("Anim_Tuto");
                balVisao.SetActive(false);
                Vector2 direcaoPulo = new Vector2(0.8f, 0.9f);
                direcaoPulo.Normalize();
                indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
                Invoke("VoltaraAndar", 0.8f);
                GetComponent<Score>().Addscore();
        }
    }

    public void cheirar()
    {
        if (indio.transform.position.x >= 64.6 && indio.transform.position.x <= 64.7)
        {
            botoes.GetComponent<Animator>().Play("Anim_Tuto");
                balPaladar.SetActive(false);
                personagem.goOrStay = true;
                indio.GetComponent<Animator>().SetBool("parar", false);
                indio.GetComponent<Animator>().SetBool("cheirar", false);
                GetComponent<Score>().Addscore();
        }
    }

    public void comer()
    {
        if (indio.transform.position.x >= 81.6 && indio.transform.position.x <= 81.7)
        {
            botoes.GetComponent<Animator>().Play("Anim_Tuto");
                flor.SetActive(false);
                balOlfato.SetActive(false);
                indio.GetComponent<Animator>().SetBool("comer", true);
                Invoke("VoltaraAndar", 1.5f);
                GetComponent<Score>().Addscore();
        }
    }
}
