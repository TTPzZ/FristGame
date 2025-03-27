using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public static Player_controller Instance;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    public Vector3 playerDirection;


    void Awake()
        {
            if(Instance != null && Instance != this){
                Destroy(this);
            }else{
                Instance = this;
            }
        }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector3(inputX, inputY).normalized ;

        anim.SetFloat("moveX", inputX);
        anim.SetFloat("moveY", inputY);

        if(playerDirection == Vector3.zero)
        {
            anim.SetBool("moving", false);
        }
        else
        {
            anim.SetBool("moving", true);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity= new Vector2(playerDirection.x * speed, playerDirection.y * speed);
    }
}
