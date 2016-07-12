using UnityEngine;
using System.Collections;

public class customRayCast : MonoBehaviour
{

    [SerializeField]
    private Transform m_Camera;
    [SerializeField]
    public RadialSlider radialSlider;
    



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EyeRaycast();
        
    }

    private void EyeRaycast()
    {

        // Create a ray that points forwards from the camera.
        Ray ray = new Ray(m_Camera.position, m_Camera.forward);
        RaycastHit hit;

        // Do the raycast forweards to see if we hit an interactive item
        if (Physics.Raycast(ray, out hit))
        {
           if (hit.collider.CompareTag("Play"))
            {
                radialSlider.RadialCountdown();
            }


        }
        else
        {
            radialSlider.ResetRadial();
        }
    }
}