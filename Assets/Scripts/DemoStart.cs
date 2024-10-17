using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DemoStart : MonoBehaviour
{
    // Start is called before the first frame update
    public InputActionReference triggerLeft;
    public InputActionReference triggerRight;


    // Update is called once per frame
    void Update()
    {
        float leftTriggerValue = triggerLeft.action.ReadValue<float>();
        float rightTriggerValue = triggerRight.action.ReadValue<float>();

        if(leftTriggerValue > 0.5f && rightTriggerValue > 0.5f){
            SceneManager.LoadScene("Scenes/Joystick");
        }
    }
}
