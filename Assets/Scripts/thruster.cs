using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class thruster : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;

    public GameObject thrustertemp;
    public float thrustPow = 10.0f;

    public InputActionReference thrust;

    bool isThrust = false;
    void Start()
    {
        if(rb == null){
            rb = GetComponent<Rigidbody>();
        }
        thrust.action.performed += ctx => isThrust = true;
        thrust.action.canceled += ctx => isThrust = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isThrust){
            rb.AddForce(thrustPow*transform.forward, ForceMode.Impulse);
        }
            
    }
}
