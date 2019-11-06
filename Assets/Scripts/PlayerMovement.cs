using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public bool isOnGround = false;
    public float jumpPower = 7.0f;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private AudioPlayerWrapper _audioPlayer;
    public AudioClip jump;
    private bool m_FacingRight = true;
    private GameObject Ground;

    void Start()
    {
        _transform = GetComponent(typeof(Transform)) as Transform;
        _rigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        _audioPlayer = GetComponent(typeof(AudioPlayerWrapper)) as AudioPlayerWrapper;
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

        if(translate < 0)
        {
            if (m_FacingRight)
            {
                Flip();
            }
            _transform.Translate(Mathf.Abs(translate), 0, 0);
        }
        else if (translate > 0)
        {
            if (!m_FacingRight)
            {
                Flip();
            }
            _transform.Translate(translate, 0, 0);
        }
        else
        {
            transform.Translate(translate, 0, 0);
        }
        
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            _rigidbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            _audioPlayer.PlaySound(jump);
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
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
