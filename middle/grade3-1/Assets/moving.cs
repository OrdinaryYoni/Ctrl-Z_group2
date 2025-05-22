using UnityEngine;

public class moving : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    public Sprite yoni_front;
    public Sprite yoni_back;
    public Sprite yoni_left;
    public Sprite yoni_right;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        // 스프라이트 변경
        if (moveInput.y > 0)
            spriteRenderer.sprite = yoni_back;
        else if (moveInput.y < 0)
            spriteRenderer.sprite = yoni_front;
        else if (moveInput.x < 0)
            spriteRenderer.sprite = yoni_left;
        else if (moveInput.x > 0)
            spriteRenderer.sprite = yoni_right;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
