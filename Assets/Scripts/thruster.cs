using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class thruster : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Rigidbody rb;
    public float thrustPow = 10.0f;
    public InputActionReference thrust;
    bool isThrust = false;
    private Vector3 noVertical;
    private bool alreadyThrusted = false;
    private float moveDist = .1f;


    void Start()
    {
        thrust.action.performed += ctx => isThrust = true;
        thrust.action.canceled += ctx => isThrust = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(isThrust);

        if (globalStuffs.collidedWithWall) {
            rb.transform.position += globalStuffs.normOfCollision * moveDist * 1;
        }
        else {
            if(isThrust && !alreadyThrusted){
                noVertical = new Vector3(transform.forward[0], 0, transform.forward[2]);
                rb.AddForce(thrustPow * noVertical * -1, ForceMode.Impulse);
                alreadyThrusted = true;
            }
            if(!isThrust){
                alreadyThrusted = false;
            }
        }
    }
}
