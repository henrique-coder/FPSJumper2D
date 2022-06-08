using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 originalPos;
    public float vX;
    public float jumpForce;

    public bool isJumping;
    public int jumpNumber;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        vX = 5;
        jumpForce = 10;
        rig = GetComponent<Rigidbody2D>();
        originalPos = gameObject.transform.position;
    }

    void reset()
    {
        Start();
    }

    // Update is called once per frame
    void Update()
    {
        move_x();
        jump();
        resetar();
    }

    public void move_x()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * vX;
    }

    public void jump()
    {
        if (Input.GetButtonDown("Jump") && jumpNumber <= 1)
        {
            rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpNumber += 1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            jumpNumber = 0;
            isJumping = false;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        isJumping = true;
    }
    void resetar()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            transform.position = originalPos;
        }
    }
}