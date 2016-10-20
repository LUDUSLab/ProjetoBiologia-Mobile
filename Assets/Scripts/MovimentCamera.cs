using UnityEngine;
using System.Collections;

public class MovimentCamera : MonoBehaviour {

    public GameObject controlador;
    public GameObject indiozinho;
    public GameObject painel;
    public float velocidade;
    private Rigidbody2D rb;
    public GameObject botao;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Comecar()
    {
        painel.SetActive(false);
        indiozinho.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        controlador.GetComponent<Moviment>().Move(true);
        rb.velocity = Vector2.right * velocidade;
        //transform.Translate(Vector3.right * Time.deltaTime * velocidade);
    }
}
