using UnityEngine;
public class KarakterKontrolu : MonoBehaviour
{
    public float speed = 5f; // Karakterin hareket h�z�
    public float jumpForce = 7f; // Z�plama kuvveti
    public float raycastDistance = 1f; // Raycast mesafesi
    public Transform raycastOrigin; // Raycast'in ba�lang�� noktas� (karakterin aya��)
    public LayerMask groundLayer; // Zemin katman�

    private Rigidbody2D rb; // Rigidbody bile�eni
    private bool isGrounded; // Yerde mi kontrol�
    private SpriteRenderer spriteRenderer; // Sprite'� y�nlendirmek i�in
    private Animator animator; // Animator bile�eni

    void Start()
    {
        // Rigidbody, SpriteRenderer ve Animator bile�enlerini al
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        // Raycast origin noktas� belirtilmezse, karakterin transformunu kullan
        if (raycastOrigin == null)
        {
            raycastOrigin = transform;
        }
    }

    void Update()
    {
        // Yatay hareket
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // Sprite Flip (Y�n de�i�tirme)
        if (move > 0) // Sa�a hareket
        {
            spriteRenderer.flipX = false; // Sprite'� sa�a d�n�k yap
        }
        else if (move < 0) // Sola hareket
        {
            spriteRenderer.flipX = true; // Sprite'� sola d�n�k yap
        }

        // Z�plama
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Ayak ucu Raycast ile zemini kontrol etme
        RaycastHit2D groundHit = Physics2D.Raycast(raycastOrigin.position, Vector2.down, raycastDistance, groundLayer);
        isGrounded = groundHit.collider != null;

        // Yatay Raycast ile �n�nde engel kontrol�
        Vector2 raycastDirection = spriteRenderer.flipX ? Vector2.left : Vector2.right; // Sprite y�n�ne g�re Raycast y�n�
        RaycastHit2D frontHit = Physics2D.Raycast(raycastOrigin.position, raycastDirection, raycastDistance, groundLayer);

        if (frontHit.collider != null)
        {
            Debug.Log("�n�nde engel var: " + frontHit.collider.name);
        }

        // Animator'a velocity.x de�erini g�nder
        animator.SetFloat("Speed", Mathf.Abs(move));
    }

    // Raycast'leri g�rselle�tirme
    void OnDrawGizmos()
    {
        if (raycastOrigin == null) return;

        // Ayak ucu Raycast
        Gizmos.color = Color.green; // Ye�il renk
        Gizmos.DrawLine(raycastOrigin.position, raycastOrigin.position + Vector3.down * raycastDistance);

        // Yatay Raycast
        Vector2 raycastDirection = spriteRenderer != null && spriteRenderer.flipX ? Vector2.left : Vector2.right;
        Gizmos.color = Color.blue; // Mavi renk
        Gizmos.DrawLine(raycastOrigin.position, raycastOrigin.position + (Vector3)raycastDirection * raycastDistance);
    }
}
