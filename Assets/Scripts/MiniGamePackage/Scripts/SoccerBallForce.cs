using UnityEngine;
using System.Collections;

public class SoccerBallForce : MonoBehaviour 
{

    public AudioSource aww;

	void Update()
	{
		Destroy(this.gameObject, 3f);
	}

	// Use this for initialization
	//void OnCollisionEnter (Collision col) 
	//{
	//	ContactPoint contact = col.contacts[0];
	//	Rigidbody colRB = col.gameObject.GetComponent<Rigidbody>();
	//	colRB.isKinematic = false;
	//	colRB.useGravity = true;
	//	colRB.AddForce(contact.normal * -20, ForceMode.Impulse);
	//}

    


}
