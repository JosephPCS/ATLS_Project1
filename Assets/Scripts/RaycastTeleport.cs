using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class RaycastTeleport : MonoBehaviour
{
    [SerializeField]
    private GameObject playerOrigin;
    [SerializeField]
    private LayerMask teleportMask;

    [SerializeField]
    private InputActionReference teleportButtonPress;

     [SerializeField]
     public GameObject nextLevel;


    void Start(){
        teleportButtonPress.action.performed += DoRaycast;
        nextLevel = GameObject.FindGameObjectWithTag("Next");
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
            if(hit.collider.gameObject.tag == "Next"){
                 SceneManager.LoadScene("Scenes/BossLevel");

            }else{
                playerOrigin.transform.position = hit.collider.gameObject.transform.position;
            }
            
            
        }
    }

    
}
