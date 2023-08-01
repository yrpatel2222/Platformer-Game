using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKillButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Boss;
    public GameObject exitWall;
    public GameObject finish;
    public bool bossDestroyed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Boss.SetActive(false);
            exitWall.SetActive(false);
            finish.SetActive(true);
            Destroy(gameObject);
            bossDestroyed = true;
            (FindObjectOfType<BossPlatform>().mainCamera).SetActive(true);
            (FindObjectOfType<BossPlatform>().bossCamera).SetActive(false);
        }

    }
}
