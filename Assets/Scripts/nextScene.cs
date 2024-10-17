using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    public int SceneNum;

    void onCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player") {
            SceneManager.LoadScene(SceneNum);
        }
    }
}
