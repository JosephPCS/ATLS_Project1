using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    public int SceneNum;

    void OnTriggerEnter(Collider other) {
        Debug.Log("Teleporting");

        if(other.gameObject.tag == "Player") {
            SceneManager.LoadScene(SceneNum);
        }
        
        //SceneManager.LoadScene(SceneNum);
    }

    /*
    void onCollisionEnter(Collision other) {
        Debug.Log("Collision");
    }
    */
}
