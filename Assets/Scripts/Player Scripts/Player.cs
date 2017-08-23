using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    public float speed = 8f;
    public float maxVelocity = 4f;

    private Rigidbody2D myBody;
    private Animator anim;

    private AudioSource audioSource;

    private float lastYPosition;

    [SerializeField]
    private AudioClip stepSound;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        lastYPosition = transform.position.y;
	}
	
	// FixedUpdate is the best option when acting on the physics engine
	void FixedUpdate () {
        PlayerMoveKeyboard();
        PlayerJumping();
	}

    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        if (h>0) //going right
        {
            if (vel < maxVelocity)
                forceX = speed;

            //facing right
            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
            //PlayMovementClip();

        } else if (h<0) //going left
        {
            if (vel < maxVelocity)
                forceX = -speed;

            //facing left
            Vector3 temp = transform.localScale;
            temp.x = -1.3f;
            transform.localScale = temp;
            anim.SetBool("Walk", true);
            //PlayMovementClip();

        } else
        {
            if (Mathf.Abs(myBody.velocity.x) < 3f) //Player stopped
            {
                anim.SetBool("Walk", false);
            }
        }

        myBody.AddForce(new Vector2(forceX, 0));
    }


    void PlayMovementClip ()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = stepSound;
            audioSource.Play();
        }
    }

    void PlayerJumping()
    {
        if (transform.position.y < lastYPosition)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            lastYPosition = transform.position.y;
        }
        
    }



}
