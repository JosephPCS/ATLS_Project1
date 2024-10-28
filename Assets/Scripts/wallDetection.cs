using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDetection : MonoBehaviour
{
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Wall") {
            globalStuffs.collidedWithWall = true;
            globalStuffs.normOfCollision = col.GetContact(0).normal;
            Debug.Log("Colliding");
        }
    }

    void OnCollisionExit(Collision col) {
        globalStuffs.collidedWithWall = false;
        Debug.Log("Not Colliding");
    }
}
