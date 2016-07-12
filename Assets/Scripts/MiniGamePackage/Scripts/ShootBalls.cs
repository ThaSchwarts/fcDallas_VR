using UnityEngine;
using System.Collections;

public class ShootBalls : MonoBehaviour
{
    public float minForce;
    public float maxForce;
    public float rightAngle;
    public float leftAngle;
    public float timer;
    public float delay;
    protected float force;

    public int ballLimit;
    public int ballsKicked;

    public GameObject soccerBall;
    public SteamVR_TrackedObject trackedObj;
    public GameObject kickPoint;
    public RadialSlider radialSlider;
    public GameObject reticle;
    public GameObject playBut;
    public GameObject countDown;

    public bool isPlaying;
    

    void Awake()
    {
        isPlaying = false;
        ballsKicked = 0;
       
    }

    void Update()
    {
        if (isPlaying)
        {
            reticle.SetActive(false);
            Kick();
            for (int i = 0; i <= 1; i++)
            {
                //playBut.SetActive(false);
                countDown.SetActive(true);
                
            }
        if (ballsKicked <= ballLimit)
            {

            }
        }
    }

    public void Kick()
    {
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            if (ballsKicked < ballLimit)
            {
                kickPoint.transform.rotation = Quaternion.Euler(-15.0f, Random.Range(rightAngle, leftAngle), 0f); //rotate the origin only on the y axis for random left and right movement
                force = Random.Range(minForce, maxForce);
                GameObject SB;
                SB = Instantiate(soccerBall, transform.position, Quaternion.identity) as GameObject;
                SB.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
                timer = 0;
                ballsKicked++;
            }
        }
    }
}
