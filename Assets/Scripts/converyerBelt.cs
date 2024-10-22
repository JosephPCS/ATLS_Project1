using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class converyerBelt : MonoBehaviour
{
    public float speed = 3.0f;

    void OnCollisionStay(Collision collision) {
        if (collision.gameObject.tag != "Player") {
            return;
        }

        //else

        Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
    }
}
