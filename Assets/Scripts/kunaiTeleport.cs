using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kunaiTeleport : MonoBehaviour
{
    [SerializeField]
    private GameObject playerOrigin;

    // Update is called once per frame
    void Update()
    {
        if (globalStuffs.thrown)
        {
            TeleportToKunai();

            globalStuffs.thrown = false;
        }
    }

    void TeleportToKunai()
    {
        playerOrigin.transform.position = gameObject.transform.position;
    }
}