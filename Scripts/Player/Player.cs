using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed;
    public float runspeed;
    public float jumpForce;
    private float moveInput;
    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatisGround;
    public float checkRadius;
    private int extraJumps;
    public int extraJumpsValue;
    private Rigidbody2D rb;
    public Animator animator;

    public int numberOfHearts;
    public int health;
    public int curHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private ScoreManager curScore;

    private void Awake()
    {
        curScore = GameObject.FindObjectOfType<ScoreManager>();
    }

    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        curHealth = health;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);
        moveInput = Input.GetAxis("Horizontal");
        if (moveInput > 0 || moveInput < 0)
        {
            speed = runspeed;
        }
        else
        {
            speed = 0;
        }

        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else
        {
            if (facingRight == true && moveInput < 0)
            {
                Flip();
            }
        }
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(speed));
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
        if (isGrounded == false)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
        if (isGrounded == false)
        {
            extraJumps = 0;
        }
        if (curHealth > numberOfHearts)
        {
            curHealth = numberOfHearts;
        }
        if (health > numberOfHearts)
        {
            health = numberOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void TakeDamage(int dmg)
    {
        gameObject.GetComponent<Animation>().Play("Knockback");
        curHealth = curHealth - dmg;
        health = curHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
    }

    public IEnumerator knockback(float knockdur,float knockbackpwr,Vector3 knockbackdir)
    {
        float timer = 0;
        while(knockdur > timer)
        {
            timer += Time.deltaTime;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector3(knockbackdir.x * 20, knockbackdir.y + knockbackpwr, transform.position.z));
        }
        yield return 0;
    }
}