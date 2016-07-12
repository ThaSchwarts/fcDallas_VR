using UnityEngine;
using System.Collections;

public class GlassConnection : MonoBehaviour 
{
	public Transform GABV;
	public Vector3 startPos;
	public Rigidbody rb;

	// Use this for initialization
	void Start () 
	{
		rb = this.GetComponent<Rigidbody>();
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit))
		{
			GABV = hit.collider.transform;
		}
		if(GABV != null)
		{
			startPos = GABV.transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GABV != null)
		{
			if(GABV.transform.position != startPos)
			{
				rb.isKinematic = false;
				rb.useGravity = true;
			}
		}


		else
		{
			return;
		}
	}
}
