using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class pickupController : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldObj;
    private Rigidbody heldObjRB;

    [HeaderAttribute("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    //Input detection
    [SerializeField] private InputActionReference trigger;

    //Temp object storage
    private GameObject throwObject;
    private Vector3 rotation;
    [SerializeField] float throwForce = 0.3f;

    private void Update() 
    {
        if (trigger.action.ReadValue<float>() > 0.5f) 
        {
            if (heldObj == null) 
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.forward, out hit, pickupRange)) 
                {
                    //Pickup Object
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                //Drop Object
                //Check if object is throwable
                DropObject();
            }
        }
        if(heldObj != null) 
        {
            //MoveObject
            MoveObject();
        }
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, holdArea.position) > .1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }

    void PickupObject(GameObject pickObj) 
    {
        if(pickObj.gameObject.tag == "Grabbable" || pickObj.gameObject.tag == "Throwable")
        {
            if(pickObj.GetComponent<Rigidbody>())
            {
                heldObjRB = pickObj.GetComponent<Rigidbody>();
                heldObjRB.useGravity = false;
                heldObjRB.drag = 10;
                heldObjRB.constraints = RigidbodyConstraints.FreezeRotation; //will probs remove so it flows better
                //heldObjRB.constraints = RigidbodyConstraints.FreezeRotationX; //Use so it looks good
                //heldObjRB.constraints = RigidbodyConstraints.FreezeRotationY;

                heldObjRB.transform.parent = holdArea;
                heldObj = pickObj;
            }
        }
    }

    void DropObject() 
    {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null;
        heldObj = null;
    }

    void ThrowObject()
    {
        throwObject = heldObjRB.GetComponent<GameObject>();

        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null;
        heldObj = null;

        rotation = gameObject.transform.forward;

        throwObject.GetComponent<Rigidbody>().AddForce(rotation * throwForce);

        globalStuffs.thrown = true;
    }
}
