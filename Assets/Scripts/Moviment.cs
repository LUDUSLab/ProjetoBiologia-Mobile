using UnityEngine;
using System.Collections;

public class Moviment : MonoBehaviour {

    public GameObject indiozinho;
    public GameObject painel;
    //public Component Camera;

	void Start () {
        Move(false);
    }


    public void Move(bool canMove)
    {
        //UnityEngine.Camera Componet.GetComponent<UnityEngine.Camera>().velocity = new Vector2(1, 0);
        if (canMove)
        {
            Debug.Log("entrou");
            indiozinho.GetComponent<Rigidbody2D>().velocity = new Vector2(1.8f, 0);
            indiozinho.GetComponent<Animator>().Play("indioandando");
        }
        else
        {
            Debug.Log(indiozinho.GetComponent<Rigidbody2D>().velocity);
            indiozinho.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            indiozinho.GetComponent<Animator>().Play("indioparado");
        }
    }


}
