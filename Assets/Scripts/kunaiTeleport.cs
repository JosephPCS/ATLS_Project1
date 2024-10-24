using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kunaiTeleport : MonoBehaviour
{
    [SerializeField] private GameObject playerOrigin;
    private Vector3 currLoc;

    private void Update()
    {
        Debug.Log(gameObject.transform.position);

        if (gameObject.transform.position[1] < 0f)
        {
            currLoc = new Vector3(gameObject.transform.position[0], 0.1f, gameObject.transform.position[2]);
            gameObject.transform.position = currLoc;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (globalStuffs.thrown && other.transform.tag != "Player")
        {
            TeleportToKunai();

            globalStuffs.thrown = false;
        }
    }

    void TeleportToKunai()
    {
        //newLoc = new Vector3(gameObject.transform.position[0], gameObject.transform.position[1], gameObject.transform.position[2]);
        playerOrigin.transform.position = gameObject.transform.position;
    }
}