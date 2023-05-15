using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject RegularPlatform;
    [SerializeField] GameObject BreakingPlatform;
    [SerializeField] GameObject DisapperingPlatform;
    [SerializeField] GameObject PowerupPlatform;
    private float speed = 5.0f;
    private float forwardInput;
    public bool jump;
    public bool POWERUP;
    Rigidbody2D rb;
    public bool isGrounded;
    [SerializeField] private float jumpPower = 15.0f;
    public LayerMask layerMask;
    [SerializeField] ParticleSystem groundParticle;
    private bool playerOnDisappearingPlatform = false;

    // sound
    public AudioClip jumpSound;
    public AudioClip landSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Horizontal");
        speed = 10.0f;
        rb.velocity = new Vector2(forwardInput * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        
    }

    private void FixedUpdate()
    {
        isGrounded = groundCheck();
        if (jump && isGrounded && rb.velocity.y == 0f && !POWERUP)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
            player.transform.parent = null;
        }
        else if (jump && isGrounded && rb.velocity.y == 0f && POWERUP)
        {
            rb.AddForce(Vector3.up * jumpPower * 2, ForceMode2D.Impulse);
            jump = false;
            player.transform.parent = null;
            POWERUP = false;
        }
        else
        {
            jump = false;
        }

        // sests the bounds
        if (transform.position.x < -10)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 10)
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }
        Vector3 bottomScreen = new Vector3(0.5f, -16.0f, Camera.main.nearClipPlane);
        Vector3 bottomWorld = Camera.main.ViewportToWorldPoint(bottomScreen);
        float bottomDistance = Mathf.Tan(Camera.main.fieldOfView * Mathf.Deg2Rad / 2.0f) * Mathf.Abs(Camera.main.transform.position.z - bottomWorld.z);

        if (transform.position.y < (bottomWorld.y - bottomDistance))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Collison for jumping
        if (collision.collider.tag == "Regular Platform")
        {
            player.transform.parent = collision.gameObject.transform;
            groundParticle.Play();
            playerAudio.PlayOneShot(landSound, 1.0f);
            POWERUP = false;
        }
        // Destroy a breaking platform
        else if (collision.collider.tag == "Breaking Platform")
        {
            Destroy(collision.gameObject);
            POWERUP = false;
        }
        else if(collision.collider.tag == "powerup")
        {
            Debug.Log("POWRUP");
            player.transform.parent = collision.gameObject.transform;
            groundParticle.Play();
            playerAudio.PlayOneShot(landSound, 1.0f);
            POWERUP = true;
        }
    }
    IEnumerator DisappearAfterDelay(GameObject platform, float delay)
    {
        yield return new WaitForSeconds(delay);
        player.transform.parent = null;
        Destroy(platform);
       
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //platform dessapper after jumping off
        if(collision.collider.tag == "Disappering Platform")
        {
            if (playerOnDisappearingPlatform == true)
            {
                StartCoroutine(DisappearAfterDelay(collision.gameObject, 0.5f));
                playerOnDisappearingPlatform = false;
            }
        }
         if (collision.collider.tag == "Regular Platform")
        {
            player.transform.parent = null;
        }
        if( collision.collider.tag == "powerup")
        {
            player.transform.parent = null;
            /*if (jump && isGrounded && rb.velocity.y == 0f && POWERUP)
            {
                rb.AddForce(Vector3.up * jumpPower * 2, ForceMode2D.Impulse);
                jump = false;
                player.transform.parent = null;
                POWERUP = false;
            }*/
        }

    }

    private bool groundCheck()
    {
        // GroundCheck for jump on platform
        var groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, layerMask);
        //Debug.DrawRay(transform.position, Vector2.down, Color.cyan);
        //Debug.Log(groundCheck.collider);
        return groundCheck.collider != null;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Disappering Platform" && rb.velocity.y == 0f)
        {
            player.transform.parent = collision.gameObject.transform;
            groundParticle.Play();
            playerOnDisappearingPlatform = true;
            playerAudio.PlayOneShot(landSound, 1.0f);
            POWERUP = false;
        }
    }
}