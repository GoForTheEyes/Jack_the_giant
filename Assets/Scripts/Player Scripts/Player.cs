using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 8f;
    public float maxVelocity = 4f;

    private Rigidbody2D myBody;
    private Animator anim;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// FixedUpdate is the best option when acting on the physics engine
	void FixedUpdate () {
        PlayerMoveKeyboard();
	}

    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");
        if (h>0) //going right
        {
            if (vel < maxVelocity)
                forceX = speed;

            //facing right
            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        } else if (h<0) //going left
        {
            if (vel < maxVelocity)
                forceX = -speed;

            //facing left
            Vector3 temp = transform.localScale;
            temp.x = -1.3f;
            transform.localScale = temp;
            anim.SetBool("Walk", true);

        } else
        {
            if (Mathf.Abs(myBody.velocity.x) < 3f) //Player stopped
            {
                anim.SetBool("Walk", false);
            }
        }

        myBody.AddForce(new Vector2(forceX, 0));
    }

}
