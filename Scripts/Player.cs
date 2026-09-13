using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Immunity Settings")]
    public bool canKill = false;
    private float killTimer = 0f;
    public float killDuration = 7f;
    public TMP_Text immunityTimerText;
    public Color immunityColor = Color.yellow;
    public AudioClip boosterSound;

    [Header("Movement Settings")]
    public float playerSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private SpriteRenderer spriteRenderer;
    private Color defaultColor;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        if (spriteRenderer != null)
            defaultColor = spriteRenderer.color;

        if (immunityTimerText != null)
            immunityTimerText.text = "";
    }

    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;

        if (canKill)
        {
            killTimer -= Time.deltaTime;

            if (immunityTimerText != null)
            {
                immunityTimerText.text = $"IMMUNITY: {Mathf.CeilToInt(killTimer)}s";
                if (killTimer < 3f)
                    immunityTimerText.color = Color.Lerp(Color.red, Color.yellow, Mathf.PingPong(Time.time * 2f, 1f));
                else
                    immunityTimerText.color = Color.yellow;
            }

            if (spriteRenderer != null)
                spriteRenderer.color = immunityColor;

            if (killTimer <= 0)
                EndImmunity();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, playerDirection.y * playerSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Booster"))
        {
            CollectBooster(other.gameObject);
        }
        else if (other.CompareTag("Obstacle"))
        {
            HandleObstacleCollision(other.gameObject);
        }
    }

    void CollectBooster(GameObject booster)
    {
        Destroy(booster);
        canKill = true;
        killTimer = killDuration;

        if (audioSource != null && boosterSound != null)
            audioSource.PlayOneShot(boosterSound);
    }

    void HandleObstacleCollision(GameObject obstacle)
    {
        if (canKill)
        {
            Destroy(obstacle);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void EndImmunity()
    {
        canKill = false;
        if (immunityTimerText != null)
        {
            immunityTimerText.text = "";
            immunityTimerText.color = Color.yellow;
        }
        if (spriteRenderer != null)
            spriteRenderer.color = defaultColor;
    }
}
