using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5); //A Movement Speed of 4 or more, and it gets destroyed off-screen.
    }

    private void FixedUpdate()
    {
        //Make sure the Y velocity is frozen or the gravity scale is 0, otherwise it still falls.
        rb.velocity = new Vector2(-moveSpeed, 0);
    }
}
