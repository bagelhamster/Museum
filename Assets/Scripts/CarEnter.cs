using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnter : MonoBehaviour
{

    public MonoBehaviour CarController;
    public Transform Car;
    public Transform Player;

    [Header("Cameras")]
    public GameObject PlayerCamera;
    public GameObject CarCamera;

    public GameObject DriveUi;

    bool Candrive;

    void Start()
    {
        CarController.enabled = false;
        DriveUi.gameObject.SetActive(false);
        CarCamera.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Candrive)
        {

            CarController.enabled = true;
            DriveUi.gameObject.SetActive(false);
            Player.transform.SetParent(Car);
            Player.gameObject.SetActive(false);
            PlayerCamera.gameObject.SetActive(false);
            CarCamera.gameObject.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.F))

        {

            CarController.enabled = false;
            Player.transform.SetParent(null);
            Player.gameObject.SetActive(true);
            PlayerCamera.gameObject.SetActive(true);
            CarCamera.gameObject.SetActive(false);

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
