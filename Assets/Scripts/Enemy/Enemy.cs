using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer,head;
    [SerializeField] private Rigidbody2D rb;
    private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private GameObject EnemyDeadEffect;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Player_controller.Instance.gameObject.activeSelf== true){

        if(Player_controller.Instance.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
            head.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
            head.flipX = false;
        }
        
        direction = (Player_controller.Instance.transform.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x*speed, direction.y*speed);
        }else{
            rb.linearVelocity = Vector2.zero;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player_controller.Instance.TakeDamge(1);
            Destroy(gameObject);
            Instantiate(EnemyDeadEffect,transform.position,transform.rotation);
        }
    }

}
