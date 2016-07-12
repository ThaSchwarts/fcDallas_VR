using UnityEngine;
using System.Collections;

public class scoreUpdateTrigger : MonoBehaviour {

    public gameManager scoreUpdate;

	void Start ()
    {
	
	}
	
	void Update ()
    {
	    
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            scoreUpdate.score += 1;
        }
    }
}
