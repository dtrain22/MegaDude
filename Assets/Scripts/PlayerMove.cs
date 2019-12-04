using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller2D))]
public class PlayerMove : MonoBehaviour
{
    public float jumpHeight = 4;
    public float timeToJumpApex = 0.4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 5;


    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    //from player movement
    public AudioClip jump;
    private AudioSource _audioWrapper;
    public Animator animator;
    private bool m_FacingRight = true;

    Controller2D controller;

    void Start()
    {
        //from player movement
        _audioWrapper = gameObject.AddComponent<AudioSource>();


        controller = GetComponent<Controller2D>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity: " + gravity + " Jump Velocity: " + jumpVelocity);
    }

    void Update()
    {
        if(controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
            animator.SetBool("IsJumping", false);
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
        {
            velocity.y = jumpVelocity;
            animator.SetBool("IsJumping", true);
        }

        float targetVelocityX = input.x * moveSpeed;
        targetVelocityX = Flip(targetVelocityX);

        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //public IEnumerator Knockback(float KnockbackDur, float KnockbackPwr, Vector3 KnockbackDir)
    //{
    //    float timer = 0;
    //    while (KnockbackDur > timer)
    //    {
    //        timer += Time.deltaTime;
    //        _rigidbody.AddForce(new Vector2(KnockbackDir.x * -100, KnockbackDir.y * KnockbackPwr));
    //    }
    //    yield return 0;
    //}

    float Flip(float velocityX)
    {
        animator.SetFloat("Speed", Mathf.Abs(velocityX));

        if (velocityX < 0)
        {
            if (m_FacingRight)
            {
                // Switch the way the player is labelled as facing.
                m_FacingRight = !m_FacingRight;

                transform.Rotate(0f, 180f, 0f);
            }
        }
        else if (velocityX > 0)
        {
            if (!m_FacingRight)
            {
                // Switch the way the player is labelled as facing.
                m_FacingRight = !m_FacingRight;

                transform.Rotate(0f, 180f, 0f);
            }
        }
        else
        {
            //  transform.Translate(translate, 0, 0);
        }

        if (m_FacingRight == false)
        {
            velocityX = velocityX * -1;
        }

        return velocityX;
    }

}