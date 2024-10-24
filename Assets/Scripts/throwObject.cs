using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class objectThrow : MonoBehaviour
{
    [SerializeField] InputActionReference throwButton;
    private GameObject thing;
    private UnityEngine.Vector3 parentRotation;
    private float throwForce = 0.3f;

    // Update is called once per frame
    void Start()
    {
        throwButton.action.performed += Throw;
    }

    void Throw(InputAction.CallbackContext _)
    {
        //thing = gameObject.GetComponentInChildren<GameObject>();
        thing = gameObject.transform.GetChild(0).GetComponentInChildren<GameObject>();

        //gameObject.transform.DetachChildren();
        gameObject.transform.GetChild(0).transform.DetachChildren();

        //parentRotation = gameObject.transform.parent.forward;
        parentRotation = gameObject.transform.forward;

        thing.GetComponent<Rigidbody>().AddForce(parentRotation * throwForce);

        globalStuffs.thrown = true;
    }
}
