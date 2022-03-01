using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private LayerMask jumpableGround;

    private SpriteRenderer _spriteRenderer;
    private Animator _anim;
    private BoxCollider2D _boxCollider2D;

    private float _dirX;
    private static readonly int State = Animator.StringToHash("state");

    [SerializeField]
    private AudioSource jumpSoundEffect;

    private enum MovementState
    {
        Idle,
        Run,
        Jump,
        Fall
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(_dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            jumpSoundEffect.Play();
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (_dirX > 0f)
        {
            state = MovementState.Run;
            _spriteRenderer.flipX = false;
        }
        else if (_dirX < 0f)
        {
            state = MovementState.Run;
            _spriteRenderer.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.Jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.Fall;
        }

        _anim.SetInteger(State, (int) state);
    }

    private bool IsGrounded()
    {
        var bounds = _boxCollider2D.bounds;
        return Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}