using UnityEngine;
using System.Collections;

public class ballTrigger : MonoBehaviour {

    public AudioSource aww;


    // Use this for initialization
    void Start ()
    {
        aww.GetComponent<AudioSource>();

    }


    void OnTriggerEnter()
    {
        //if (gameObject.collider.CompareTag("Ball"))
        {
            aww.Play();
        }
    }
}
