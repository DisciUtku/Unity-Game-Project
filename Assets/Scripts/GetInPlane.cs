using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GetInPlane : MonoBehaviour
{
    [Header("Human")]
    [SerializeField] GameObject human = null;
    [SerializeField] bool inPlane = false;
    [SerializeField] float vehicleRange = 5f;



    [Space, Header("Plane")]
    [SerializeField] GameObject plane = null;

    [Header("Camera")]
    [SerializeField] GameObject followCamera = null;

    [Header("Input")]
    [SerializeField] GameObject enterButton = null;
    [SerializeField] GameObject exitButton = null;

    public VehicleUnlock vu;
    public Vector3 height;


    void Start()
    {

        plane.GetComponent<PlaneControls>().controller.enabled = false;
        plane.GetComponent<PlaneControls>().canRotate = false;
        inPlane = !plane.activeSelf;
        enterButton.SetActive(false); exitButton.SetActive(false);
        height = new Vector3(0, 21, 0);
    }


    void Update()
    {
        if (vu.planeUnlocked)
        {
            float distance = Vector3.Distance(plane.transform.position, human.transform.position);
            


            if (distance < vehicleRange)
            {
                if (inPlane)
                {
                    enterButton.SetActive(false);
                    exitButton.SetActive(true);
                }

                else
                {
                    enterButton.SetActive(true);
                }

            }
            else
            {

                enterButton.SetActive(false);

                if (inPlane)
                {
                    exitButton.SetActive(true);
                }
                else if (!inPlane)
                {
                    exitButton.SetActive(false);

                }

            }
        }


    }



    public void ExitPlane()
    {
        inPlane = false;

        human.SetActive(true);

        followCamera.GetComponent<CameraScript>().myPlay = human.transform;

        plane.GetComponent<PlaneControls>().controller.enabled = false;
        plane.GetComponent<PlaneControls>().canRotate = false;
        plane.transform.position -= height;

        human.transform.position = plane.transform.position + 2 * plane.transform.TransformDirection(Vector3.left);

    }

    public void EnterPlane()
    {
        inPlane = true;
        human.SetActive(false);
        followCamera.GetComponent<CameraScript>().myPlay = plane.transform;
        plane.GetComponent<PlaneControls>().controller.enabled = true;
        plane.GetComponent<PlaneControls>().canRotate = true;
        plane.transform.position += height;
        enterButton.SetActive(false);
    }
}
