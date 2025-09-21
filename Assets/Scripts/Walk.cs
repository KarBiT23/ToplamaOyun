using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakter hýzý

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Klavye giriþlerini al
        movement.x = Input.GetAxisRaw("Horizontal"); // A ve D tuþlarý
        movement.y = Input.GetAxisRaw("Vertical");   // W ve S tuþlarý
    }

    void FixedUpdate()
    {
        // Karakteri hareket ettir
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
