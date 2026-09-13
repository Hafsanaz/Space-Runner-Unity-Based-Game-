using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player;
    public float speed = 2f; // Added speed variable

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player not found in the scene.");
        }
    }

    void Update()
    {
        // Move obstacle left
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null && player.canKill)
            {
                Destroy(gameObject); // Obstacle is destroyed if player has immunity
            }
            else
            {
                Destroy(collision.gameObject); // Player is destroyed
            }
        }
    }
}