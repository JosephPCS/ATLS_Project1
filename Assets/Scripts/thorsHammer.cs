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
            if (gameObject.transform.GetChild(0).tag == "Grabbable")
            {
                changingSpeed = Mathf.Sin(rotation[2]);

                playerOrigin.transform.position += speed * gameObject.transform.parent.forward;
            }
        }
    }
}
