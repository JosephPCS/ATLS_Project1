using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class thorsHammer : MonoBehaviour
{
    public float speed = 0.01f;
    [SerializeField]
    private GameObject playerOrigin;
    private UnityEngine.Vector3 rotation;
    private float changingSpeed;
    private UnityEngine.Vector3 parentRotation;
    private UnityEngine.Vector3 noVertical;
    private float moveDist = .1f;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.childCount > 0)
        {
            if (globalStuffs.collidedWithWall) {
                playerOrigin.transform.position += globalStuffs.normOfCollision * moveDist * 1;
            }
            else {
                changingSpeed = Mathf.Sin(rotation[2]);

                parentRotation = gameObject.transform.parent.forward;
                noVertical = new UnityEngine.Vector3(parentRotation[0], 0, parentRotation[2]);

                playerOrigin.transform.position += noVertical * speed;
            }
        }
    }
}
