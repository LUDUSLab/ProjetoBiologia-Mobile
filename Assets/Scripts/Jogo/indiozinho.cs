using UnityEngine;
using System.Collections;

public class indiozinho : MonoBehaviour { 

	public float velo;
    public bool goOrStay = true;
	public GameObject indi;

    void Update () {
        Andando();
	}

	void Andando()
	{
        if (goOrStay)
        {
            transform.Translate(Vector2.right * velo * Time.deltaTime);
			indi.GetComponent<Animator>().Play("indioAndando");
            //Debug.Log("andando");
        }
    }
}