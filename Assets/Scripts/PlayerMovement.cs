﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float speed = 5.0f;
    public bool isOnGround = false;
    public float jumpPower = 7.0f;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private AudioSource _audioWrapper;

    public AudioClip jump;
    private bool m_FacingRight = true;
    private GameObject Ground;

    void Start()
    {
        _transform = GetComponent(typeof(Transform)) as Transform;
        _rigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        _audioWrapper = gameObject.AddComponent<AudioSource>();
        Ground = GameObject.FindGameObjectWithTag("Ground");
    }

    void Update()
    {
        MovePlayer();
        Jump();
    }

    void MovePlayer()
    {
        float translate = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(translate));

        if(translate < 0)
        {
            if (m_FacingRight)
            {
                Flip();
            }
            //animator.SetFloat("Speed", Mathf.Abs(translate));
            _transform.Translate(Mathf.Abs(translate), 0, 0);
        }
        else if (translate > 0)
        {
            if (!m_FacingRight)
            {
                Flip();
            }
            //animator.SetFloat("Speed", Mathf.Abs(translate));
            _transform.Translate(translate, 0, 0);
        }
        else
        {
          //  transform.Translate(translate, 0, 0);
        }
        
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            _rigidbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            _audioWrapper.PlayOneShot(jump);
            animator.SetBool("IsJumping", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Ground") 
        {
            isOnGround = true;
        }
    }

    void OnCollisionExit2D()
    {
        isOnGround = false;
        animator.SetBool("IsJumping", false);

    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

  

}
