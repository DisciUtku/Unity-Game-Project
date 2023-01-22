using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GetInCar : MonoBehaviour
{
    [Header("Human")]
    [SerializeField] GameObject human = null;
    [SerializeField] bool inCar= false;
    [SerializeField] float vehicleRange = 5f;



    [Space, Header("Car")]
    [SerializeField] GameObject car = null; 

    [Header("Camera")]
    [SerializeField] GameObject followCamera = null;

    [Header ("Input")]
    [SerializeField] GameObject enterButton= null;
    [SerializeField] GameObject exitButton = null;

    public VehicleUnlock vu;
    public Vector3 height;



    void Start()
    {
        
        car.GetComponent<CarMove>().controller.enabled = false;
        car.GetComponent<CarMove>().canRotate=false;
        inCar = !car.activeSelf;
        followCamera.GetComponent<CameraScript>().myPlay = human.transform;
        enterButton.SetActive(false); exitButton.SetActive(false);
        height = new Vector3(0, 2, 0);


    }


    void Update()
    {
        if (vu.carUnlocked)
        {
            float distance = Vector3.Distance(car.transform.position, human.transform.position);


            if (distance < vehicleRange) 
            {
                if (inCar)
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

                if (inCar)
                {
                    exitButton.SetActive(true);
                }
                else if (!inCar)
                {
                    exitButton.SetActive(false);

                }

            }
        }
        

    }



    public void ExitCar()
    {
        inCar = false;
        
        human.SetActive(true);

        followCamera.GetComponent<CameraScript>().myPlay = human.transform;

        car.GetComponent<CarMove>().controller.enabled = false;
        car.GetComponent<CarMove>().canRotate = false;
                car.transform.position -= height;


        human.transform.position = car.transform.position + 4 * car.transform.TransformDirection(Vector3.left);

    }

    public void EnterCar()
    {
        inCar = true;
        human.SetActive(false);
        followCamera.GetComponent<CameraScript>().myPlay = car.transform;
        car.GetComponent<CarMove>().controller.enabled = true;
        car.GetComponent<CarMove>().canRotate = true;
        enterButton.SetActive(false);
    }
}
