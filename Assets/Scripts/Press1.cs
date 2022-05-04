using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Press1 : MonoBehaviour
{

    private Button fButton;
    private Button sButton;
    private Button tButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        using (var e = new NavigationSubmitEvent() { target = fButton })
            fButton.SendEvent(e);
    }
}
