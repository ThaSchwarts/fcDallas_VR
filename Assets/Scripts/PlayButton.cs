using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour
{
    public ShootBalls shootingPoint;
    private Animator thisAnimator;
    public Animator engagedAnimation;

	// Use this for initialization
	void Start ()
    {
        thisAnimator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerEnter (Collider other)
    {
        thisAnimator.SetTrigger("selected");
        engagedAnimation.SetTrigger("engaged");
        shootingPoint.isPlaying = true;

    }
}
