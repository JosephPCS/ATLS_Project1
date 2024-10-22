using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class thorsHammer : MonoBehaviour
{
    private Transform child;
    private UnityEngine.Vector3 childRotation;
    public float speed = 0.01f;
    [SerializeField]
    private GameObject playerOrigin;
    UnityEngine.Vector3 move;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.childCount > 0)
        {
            child = gameObject.transform.GetChild(0);
            childRotation = child.rotation.eulerAngles;

            move = new UnityEngine.Vector3(0, 0, -1 * Mathf.Cos(childRotation[2]));

            playerOrigin.transform.position += move * speed;
        }
    }
}
