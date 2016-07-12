using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class RadialSlider: MonoBehaviour
{
    public float time = 0f; //Time used to fill radial image
    public float showtime = 3f; //Time shown by optional text component on GUI
    public float countdowntime = 1.5f; //Adjustable time float, how long the radial fill will last.
    public float fill;

    public bool testRadial = false; //Used to test the radial fill method with the "Space" key
    public bool selected; //The boolean that is flipped to true on a successful radial fill

    public Image radialSlider; //The image component that is manipulated by the countdown
    public ShootBalls shootingPoint;

    void Start()
    {
        radialSlider = GetComponent<Image>(); //Setting the radial slider image component
        
    }

    void Update()
    {
        //Used to test the radial fill without a VR device
        if(testRadial)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                RadialCountdown(); //Running the countdown method
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                ResetRadial(); //Resetting the countdown method
            }
        }
    }

    //The method that controls the radial slider fill
	public void RadialCountdown()
	{
        //if fill amount is less than 1, fill the slider
        if (radialSlider.fillAmount < 1)
        {
            time += Time.deltaTime; //Increase the time value based on delta time
            showtime -= Time.deltaTime; //Decrease the showtime value based on delta time

            if(showtime <= 0)
            {
                selected = true; //set selected to true is showtime value reaches 0
                showtime = countdowntime; //reset the showtime value to initial countdown value
                shootingPoint.isPlaying = true;
            }
        }

        fill = time / countdowntime; //Set a float value to time divded by countdown time, this returns a value between 0 and 1 to work with the fill amount

		radialSlider.fillAmount = fill; //Set the image components fill amount to the fill value

		radialSlider.color = Color.Lerp(Color.red, Color.green, fill); //Use a color lerp gradually change the fill images color during the countdown
   	}

    public void ResetRadial()
    {
        time = 0f; //Reset the time value
        showtime = countdowntime; //reset the showtime value

        fill = time / countdowntime; //reset the fill value

        radialSlider.fillAmount = fill; //reset the image components fill amount

        radialSlider.color = Color.red; //change the fill color back to the original color
    }
}
