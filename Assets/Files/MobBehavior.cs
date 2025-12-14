using UnityEngine;
using System;

public class MobBehavior : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 15f;
    
    private Transform player;
    private Rigidbody2D rb;
    
    public event Action OnMobDestroyed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        
        // Force Z à -1
        Vector3 pos = transform.position;
        pos.z = -1f;
        transform.position = pos;
    }

    void FixedUpdate()
    {
        if (player == null) return;
        
        float distance = Vector2.Distance(transform.position, player.position);
        
        if (distance <= detectionRange)
        {
            // Direction vers le joueur
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * moveSpeed;
            
            // Flip le sprite
            if (direction.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);
            else if (direction.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
        
        // Maintien Z à -1
        Vector3 pos = transform.position;
        pos.z = -1f;
        transform.position = pos;
    }
    
    void OnMouseDown()
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        OnMobDestroyed?.Invoke();
    }
}