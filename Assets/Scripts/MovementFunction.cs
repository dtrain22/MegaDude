using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFunction : MonoBehaviour
{
    public static void Jump(Rigidbody2D _rigidbody, float jumpPower)
    {
        _rigidbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
    }


    // the following are unused because this file is not tied to any game objects,
    // it just provides helper functions

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
