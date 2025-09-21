using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakter h�z�

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Klavye giri�lerini al
        movement.x = Input.GetAxisRaw("Horizontal"); // A ve D tu�lar�
        movement.y = Input.GetAxisRaw("Vertical");   // W ve S tu�lar�
    }

    void FixedUpdate()
    {
        // Karakteri hareket ettir
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
