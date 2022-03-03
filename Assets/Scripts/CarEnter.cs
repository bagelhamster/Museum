using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnter : MonoBehaviour
{

    public MonoBehaviour CarController;
    public Transform Car;
    public Transform Player;

    [Header("Cameras")]
    public GameObject PlayerCam;
    public GameObject CarCam;

    public GameObject DriveUi;

    bool Candrive;

    void Start()
    {
        CarController.enabled = false;
        DriveUi.gameObject.SetActive(false);
        CarCam.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Candrive)
        {
            CarController.enabled = true; // After you click f you enter the car
            DriveUi.gameObject.SetActive(false);
            Player.transform.SetParent(Car);
            Player.gameObject.SetActive(false);
            PlayerCam.gameObject.SetActive(false);
            CarCam.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            CarController.enabled = false; // After you press g you exit the car
            Player.transform.SetParent(null);
            Player.gameObject.SetActive(true);
            // Here If Player Is Not Driving So PlayerCamera turn On and Car Camera turn off
            PlayerCam.gameObject.SetActive(true);
            CarCam.gameObject.SetActive(false);
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            DriveUi.gameObject.SetActive(true);
            Candrive = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            DriveUi.gameObject.SetActive(false);
            Candrive = false;
        }
    }
}
