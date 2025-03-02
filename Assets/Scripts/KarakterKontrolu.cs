using UnityEngine;
public class KarakterKontrolu : MonoBehaviour
{
    public float speed = 5f; // Karakterin hareket hýzý
    public float jumpForce = 7f; // Zýplama kuvveti
    public float raycastDistance = 1f; // Raycast mesafesi
    public Transform raycastOrigin; // Raycast'in baþlangýç noktasý (karakterin ayaðý)
    public LayerMask groundLayer; // Zemin katmaný

    private Rigidbody2D rb; // Rigidbody bileþeni
    private bool isGrounded; // Yerde mi kontrolü
    private SpriteRenderer spriteRenderer; // Sprite'ý yönlendirmek için
    private Animator animator; // Animator bileþeni

    void Start()
    {
        // Rigidbody, SpriteRenderer ve Animator bileþenlerini al
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        // Raycast origin noktasý belirtilmezse, karakterin transformunu kullan
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

        // Sprite Flip (Yön deðiþtirme)
        if (move > 0) // Saða hareket
        {
            spriteRenderer.flipX = false; // Sprite'ý saða dönük yap
        }
        else if (move < 0) // Sola hareket
        {
            spriteRenderer.flipX = true; // Sprite'ý sola dönük yap
        }

        // Zýplama
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Ayak ucu Raycast ile zemini kontrol etme
        RaycastHit2D groundHit = Physics2D.Raycast(raycastOrigin.position, Vector2.down, raycastDistance, groundLayer);
        isGrounded = groundHit.collider != null;

        // Yatay Raycast ile önünde engel kontrolü
        Vector2 raycastDirection = spriteRenderer.flipX ? Vector2.left : Vector2.right; // Sprite yönüne göre Raycast yönü
        RaycastHit2D frontHit = Physics2D.Raycast(raycastOrigin.position, raycastDirection, raycastDistance, groundLayer);

        if (frontHit.collider != null)
        {
            Debug.Log("Önünde engel var: " + frontHit.collider.name);
        }

        // Animator'a velocity.x deðerini gönder
        animator.SetFloat("Speed", Mathf.Abs(move));
    }

    // Raycast'leri görselleþtirme
    void OnDrawGizmos()
    {
        if (raycastOrigin == null) return;

        // Ayak ucu Raycast
        Gizmos.color = Color.green; // Yeþil renk
        Gizmos.DrawLine(raycastOrigin.position, raycastOrigin.position + Vector3.down * raycastDistance);

        // Yatay Raycast
        Vector2 raycastDirection = spriteRenderer != null && spriteRenderer.flipX ? Vector2.left : Vector2.right;
        Gizmos.color = Color.blue; // Mavi renk
        Gizmos.DrawLine(raycastOrigin.position, raycastOrigin.position + (Vector3)raycastDirection * raycastDistance);
    }
}
