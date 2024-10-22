using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class converyerBelt : MonoBehaviour
{
    public float speed = 0.01f;
    [SerializeField]
    private GameObject playerOrigin;
    Vector3 conveyerRotation;
    Vector3 move;

    //void OnCollisionStay(Collision collision) {
    void OnTriggerStay(Collider collider) {
        if (collider.gameObject.tag != "Player") {
            return;
        }

        //else

        //Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
        //rigidbody.velocity = transform.forward * speed;

        conveyerRotation = gameObject.transform.rotation.eulerAngles;

        //tranform position by a vector in a specific direction
        move = new UnityEngine.Vector3(0, 0, -1 * Mathf.Cos(conveyerRotation[2]));

        playerOrigin.transform.position += move * speed;
    }
}
