using UnityEngine;
using System.Collections;

public class Ballon : MonoBehaviour {

    public GameObject Bflor;
    public GameObject Bpassaro;
    public GameObject Bfolha;
    public GameObject Bpedra;
    public GameObject Bbanana;
    public GameObject Controller;
    public GameObject Vitoria;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Flores"))
        {
            Bflor.SetActive(true);
            Controller.GetComponent<Moviment>().Move(false);
            Controller.GetComponent<Sentidos>().SetRespostaAtual("olfato");
        }
        if (other.gameObject.tag.Equals("Pedra"))
        {
            Bpedra.SetActive(true);
            Controller.GetComponent<Moviment>().Move(false);
            Controller.GetComponent<Sentidos>().SetRespostaAtual("tato");

        }
        if (other.gameObject.tag.Equals("Folhas"))
        {
            Bfolha.SetActive(true);
            Controller.GetComponent<Moviment>().Move(false);
            Controller.GetComponent<Sentidos>().SetRespostaAtual("visao");

        }
        if (other.gameObject.tag.Equals("Passaro"))
        {
            Bpassaro.SetActive(true);
            Controller.GetComponent<Moviment>().Move(false);
            Controller.GetComponent<Sentidos>().SetRespostaAtual("audicao");

        }
        if (other.gameObject.tag.Equals("Bananas"))
        {
            Bbanana.SetActive(true);
            Controller.GetComponent<Moviment>().Move(false);
            Controller.GetComponent<Sentidos>().SetRespostaAtual("paladar");
            Debug.Log("ta vindo pra ca");
            //Vitoria.SetActive(true);
            //Time.timeScale = 0;
        }
    }
}

