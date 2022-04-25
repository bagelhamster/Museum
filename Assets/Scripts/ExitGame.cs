using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }
}
