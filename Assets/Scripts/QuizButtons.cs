using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizButtons : MonoBehaviour
{

    public KeyCode _Key;

    private Button _button;

    // Start is called before the first frame update
    void Awake()
    {
        _button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(_Key))
        {
            _button.onClick.Invoke();
        }
    }
}
