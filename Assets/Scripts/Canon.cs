using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    // Adjust these values to control the speed and smoothness of turret rotation
    public GameObject player;
    public Transform pivot; // Assign the edge pivot in the Inspector or through script
    public Vector2 pivotOffset;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        Vector3 direction = player.transform.position - (pivot.position + (Vector3)pivotOffset); // Use the pivot position with offset as the reference point
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        pivot.rotation = Quaternion.Euler(0, 0, angle + 135);
    }

}
