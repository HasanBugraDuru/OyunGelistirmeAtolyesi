using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float Zýpla = 5;
    public float raycastDistance = 1f; // Raycast mesafesi
    public Transform raycastOrigin; // Raycast'in baþlangýç noktasý (karakterin ayaðý)
    public LayerMask groundLayer; // Zemin katmaný
    private bool isGrounded;
    private SpriteRenderer sp;


    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
      float  move = Input.GetAxis("Horizontal");
      rb.velocity = new Vector2(move * speed, rb.velocity.y);
      if(Input.GetKeyDown(KeyCode.Space) && isGrounded) 
       {
            rb.velocity = new Vector2(rb.velocity.x, Zýpla);

        }
        // Ayak ucu Raycast ile zemini kontrol etme
        RaycastHit2D groundHit = Physics2D.Raycast(raycastOrigin.position, Vector2.down, raycastDistance, groundLayer);
        isGrounded = groundHit.collider != null;

       
    }
    void OnDrawGizmos()
    {
        if (raycastOrigin == null) return;

        // Ayak ucu Raycast
        Gizmos.color = Color.green; // Yeþil renk
        Gizmos.DrawLine(raycastOrigin.position, raycastOrigin.position + Vector3.down * raycastDistance);

    }
}
