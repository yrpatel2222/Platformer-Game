using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlatform : MonoBehaviour
{
    public GameObject wall;
    public GameObject Boss;
    public GameObject Enemy;
    public GameObject bossCamera;
    public GameObject mainCamera;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wall.SetActive(true);
            Boss.SetActive(true);
            Enemy.SetActive(false);

            // Move the camera to the boss platform
            bossCamera.SetActive(true);
            mainCamera.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wall.SetActive(false);
            Boss.SetActive(false);
            Enemy.SetActive(true);

            // Reset the camera target to the player
            bossCamera.SetActive(false);
            mainCamera.SetActive(true);
        }
    }
}
