using UnityEngine;
using System.Collections;

public class positionUpdate : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = target.position;
    }
}
