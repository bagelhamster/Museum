using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    [SerializeField]
    GameObject dSwitch;
    bool Opened = false;

    void OnTriggerEnter(Collider col)
    {
        if (!Opened && col.gameObject.name == "Player")
        {
            Opened = true;
            door.transform.position += new Vector3(0, 3, 0);
            dSwitch.transform.Rotate(0, 180, 0);
        }
    }




}
