using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
        [SerializeField]
        private LayerMask teleportMask;

        [SerializeField]

        private InputActionReference teleportButtonPress;
    // Start is called before the first frame update

    // Update is called once per frame
    void Start(){
        teleportButtonPress.action.performed+= DoRaycast;
    }

    void DoRaycast(InputAction.CallbackContext __) {
        RaycastHit hit;
        bool didHit = Physics.Raycast(
            transform.position,
            transform.forward,
            out hit,
            Mathf.Infinity,
            teleportMask);

        if (didHit) {
            // Debug.Log(hit.collider.gameObject.name);
            SceneManager.LoadScene("Scenes/BossLevel");
        }
    }
    
}
