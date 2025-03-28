using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject destroyEffect;
    private Vector3 direction;
    // Update is called once per frame
    void FixedUpdate()   
    {
        if (PlayerController.Instance.gameObject.activeSelf)
        {
              if (PlayerController.Instance.transform.position.x > 
             transform.position.x)
            {
            spriteRenderer.flipX = true;
             }  else
             {
            spriteRenderer.flipX = false;
            }
        //di chuyen den vi tri cua player
        direction = (PlayerController.Instance.transform.position -
        transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        } else
        {
            rb.linearVelocity = Vector2.zero;
        }
        //luon theo doi vi tri   cua player
      
        
    }
    void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerController.Instance.TakeDamage(1);
                Destroy(gameObject);
                Instantiate(destroyEffect, transform.position, transform.rotation);
            }
        }
}
