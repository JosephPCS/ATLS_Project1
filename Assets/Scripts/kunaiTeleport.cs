using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kunaiTeleport : MonoBehaviour
{
    [SerializeField] private GameObject playerOrigin;
    private Vector3 newLoc;

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
        newLoc = new Vector3(gameObject.transform.position[0], gameObject.transform.position[1] + 1f, gameObject.transform.position[2]);
        playerOrigin.transform.position = newLoc;
    }
}