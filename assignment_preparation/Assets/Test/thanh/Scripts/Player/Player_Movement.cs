using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private Rigidbody2D rb;
    public LayerMask ground;
    public float speed = 5f;
    public float jump = 13f;
    private BoxCollider2D box;
    private AudioManager audio;
    public GameObject bullet;
    public float currentTime = 0f;
    public float resetTime = 0.1f;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        audio = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput*speed,rb.velocity.y);///di chuyen cua nhan vat(xoay dau theo vi tri X)
        if(horizontalInput>= 0.01f)
        {
            transform.localScale = Vector3.one;///xoay ben phai
        }else if (horizontalInput <= -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1) ;//xoay ben trai
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        if(horizontalInput != 0)
        {
            if(currentTime < resetTime)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                GameObject bulletForward = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                Rigidbody2D rb1 = bulletForward.GetComponent<Rigidbody2D>();
                rb1.AddForce(Vector2.left * 10f, ForceMode2D.Impulse);
                GameObject bulletBack = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                Rigidbody2D rb2 = bulletBack.GetComponent<Rigidbody2D>();
                rb2.AddForce(Vector2.right * 10f, ForceMode2D.Impulse);
                currentTime = 0;
            }

        }
        anim.SetBool("run", horizontalInput != 0);///neu horizontal khac 0 thi bat hieu ung di chuyen
        anim.SetBool("isGrounded", IsGrounded());//neu nhan vat cham dat thi tra ve true de bat hieu ung nhay
    }
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, 0.1f, ground);//set va cham voi mat dat
        return hit.collider != null;
    }
    private void Jump()
    {
        if (IsGrounded())
        {
            anim.SetTrigger("jump");
            if (audio)
            {
                audio.Play("jump");
            }
            rb.velocity = new Vector2(rb.velocity.x, jump);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            transform.position = new Vector3(-0.6f - (Camera.main.orthographicSize * Camera.main.aspect * 2f)/2 + 1f, -0.2f + (Camera.main.orthographicSize * 2f) / 2 - 1f, 0 );
        }
    }
}
