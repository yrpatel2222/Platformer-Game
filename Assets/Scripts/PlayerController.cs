using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 7;
    public float jumpForce = 5.0f;
    public bool isOnGround = true;
    public Rigidbody2D playerRb;
    public static int sceneCount = 2;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        // Set the value to return
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(sceneCount);
            sceneCount++;
            FindObjectOfType<LivesUI>().IncreaseLives();
            FindObjectOfType<LevelsUI>().NextLevel();
        }
    }

    void FixedUpdate()
    {

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

    }
}
