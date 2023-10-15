using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float upSpeed = 20f;

    private bool isRising;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isRising = Input.GetKey(KeyCode.Space); //Input.GetButton/Key is a boolean.
    }

    private void FixedUpdate()
    {
        if (isRising) //You don't move forward, obstacles move back.
        {
            rb.velocity += new Vector2(0, upSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.GameOver();
    }
}
