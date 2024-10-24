using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class thorsHammer : MonoBehaviour
{
    private Transform child;
    private UnityEngine.Vector3 childRotation;
    public float speed = 0.01f;
    [SerializeField]
    private GameObject playerOrigin;
    UnityEngine.Vector3 move;
    private UnityEngine.Vector3 rotation;
    private float changingSpeed;
    [SerializeField] private InputActionReference hand;
    private Transform handParent;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.childCount > 0)
        {
            child = gameObject.transform.GetChild(0);
            //childRotation = child.rotation.eulerAngles;

            rotation = gameObject.transform.rotation.eulerAngles;

            handParent = gameObject.transform.parent;

            rotation = handParent.rotation.eulerAngles;

            //move = new UnityEngine.Vector3(0, 0, -1 * Mathf.Cos(childRotation[2]));
            move = new UnityEngine.Vector3(0, 0, -1 * Mathf.Cos(rotation[1])); //rotates on the y not z

            changingSpeed = Mathf.Sin(rotation[2]);

            playerOrigin.transform.position += move * speed;
        }
    }
}
