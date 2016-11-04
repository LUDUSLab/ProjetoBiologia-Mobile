using UnityEngine;
using System.Collections;

public class tirarfade : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(tirar(3f));
	}
	
	// Update is called once per frame
	IEnumerator tirar(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        this.gameObject.SetActive(false);
    }
}
