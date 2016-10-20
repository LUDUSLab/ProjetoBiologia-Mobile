using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

    public GameObject Derrota;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("morrediabo"))
        {
            Destroy(gameObject);
            Derrota.SetActive(true);
            Time.timeScale = 0;
        }
    }

        /*void OnBecameInvisible()
        {
            Debug.Log("ta entrando");
            //Destroy(gameObject);
            Derrota.SetActive(true);
            Time.timeScale = 0;
        }*/

    }
