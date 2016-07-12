using UnityEngine;
using System.Collections;

public class ImageSequenceSingleTexture : MonoBehaviour
{
    //A texture object that will output the animation  
    public Texture texture;
    //With this Material object, a reference to the game object Material can be stored  
    public Material goMaterial;
    //An integer to advance frames  
    public int frameCounter = 0;

    //A string that holds the name of the folder which contains the image sequence  
    public string folderName;
    //The name of the image sequence  
    public string imageSequenceName;
    //The number of frames the animation has  
    public int numberOfFrames;

    //Boolean to play on awake
    public bool playOnAwake;

    public bool playOnce;

    public bool rewind;

    public bool paused;

    //The delay for frames
    public float delay = .02f;

    //The base name of the files of the sequence  
    private string baseName;

    void Awake()
    {
        //Get a reference to the Material of the game object this script is attached to  
        this.goMaterial = this.GetComponent<Renderer>().material;
        //With the folder name and the sequence name, get the full path of the images (without the numbers)  
        this.baseName = this.folderName + "/" + this.imageSequenceName;
    }

    void Start()
    {
        //set the initial frame as the first texture. Load it from the first image on the folder  
        texture = (Texture)Resources.Load(baseName + "0000", typeof(Texture));
    }

    void Update()
    {
        if(playOnAwake)
        {
           // if(this.transform.localScale.x > 0.1)
          //  {
                if (!paused)
                {
                    StartCoroutine("PlayLoop", delay);
                }

                if (paused)
                {
                    this.texture = (Texture)Resources.Load(baseName + frameCounter.ToString("D4"), typeof(Texture));
                    frameCounter = 0;
                }
           // }
        }

        if(playOnce)
        {
            StartCoroutine("Play", delay);
        }

        if(rewind)
        {
            StartCoroutine("PlayReverse", delay);
        }

        //Set the material's texture to the current value of the frameCounter variable  
        goMaterial.mainTexture = this.texture;
    }

    //The following methods return a IEnumerator so they can be yielded:  
    //A method to play the animation in a loop  
    IEnumerator PlayLoop(float delay)
    {
        //wait for the time defined at the delay parameter  
        yield return new WaitForSeconds(delay);

        //advance one frame  
        frameCounter = (++frameCounter) % numberOfFrames;

        //load the current frame  
        this.texture = (Texture)Resources.Load(baseName + frameCounter.ToString("D4"), typeof(Texture));

        //Stop this coroutine  
        //StopCoroutine("PlayLoop");
    }

    //A method to play the animation just once  
    public IEnumerator Play(float delay)
    {
        //wait for the time defined at the delay parameter  
        yield return new WaitForSeconds(delay);

        //if it isn't the last frame  
        if (frameCounter < numberOfFrames - 1)
        {
            //Advance one frame  
            ++frameCounter;

            //load the current frame  
            this.texture = (Texture)Resources.Load(baseName + frameCounter.ToString("D4"), typeof(Texture));
        }

        //Stop this coroutine  
        //StopCoroutine("Play");
    }

    IEnumerator PlayReverse(float delay)
    {
        //wait for the time defined at the delay parameter  
        yield return new WaitForSeconds(delay);

        //if it isn't the last frame  
        if (frameCounter > 0)
        {
            //Advance one frame  
            frameCounter--;

            //load the current frame  
            this.texture = (Texture)Resources.Load(baseName + frameCounter.ToString("D4"), typeof(Texture));
        }

        //Stop this coroutine  
        //StopCoroutine("PlayReverse");
    }
}