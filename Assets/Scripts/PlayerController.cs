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
    private Rigidbody2D playerRb;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
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
            SceneManager.LoadScene("level2");
        }
    }

    void FixedUpdate()
    {

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

    }
}
