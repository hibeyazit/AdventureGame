using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    Rigidbody Rb;
    Animator anim;
    float groundCheckDistance;
    [SerializeField]
    LayerMask groundLayer;
    public float moveSpeed, runSpeed, airMoveSpeed;
    public float speedSmoothTime=0.1f;
    float speedSmoothVelocity;
    float currentSpeed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float jumpHeight;
    Transform cameraT;
    public float enemeyDamage;
    bool isGrounded;
    public float GameTime;
    public int coinAmount;
    public int coinTotal;
    public Text coint;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        groundCheckDistance = GetComponent<CapsuleCollider>().bounds.extents.y + 0.3f;
        cameraT = Camera.main.transform;
    }
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 inputDi = new Vector2(x,y).normalized;
   
        Move(inputDi);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Rb.AddForce(Vector3.up*jumpHeight,ForceMode.Impulse);
        }
        Rotate(inputDi);
        GameTime += Time.deltaTime;
       
    }
    void Move(Vector2 inputDi)
    {
        if (IsGrounded())
        {
            bool running = Input.GetKey(KeyCode.LeftShift);
            float targetSpeed = ((running) ? runSpeed : moveSpeed) * inputDi.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
            Rb.velocity = currentSpeed * transform.forward;
            anim.SetBool("speed", true);
        }
        else
        {
            Vector3 forward = transform.forward;
            float targerSpeed = inputDi.magnitude * airMoveSpeed;
            forward *= targerSpeed;
            forward.y = Rb.velocity.y;
            Rb.velocity = forward;
            anim.SetBool("speed", true);

        }
        anim.SetBool("speed",false);

    }
    void Rotate(Vector2 inputDi)
    {
        if (inputDi !=Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDi.x, inputDi.y) * Mathf.Rad2Deg+cameraT.eulerAngles.y;
            transform.eulerAngles = Vector2.up * Mathf.SmoothDampAngle(transform.eulerAngles.y,targetRotation,ref turnSmoothVelocity,turnSmoothTime);
            anim.SetBool("speed", true);
        }
       
    }

    bool IsGrounded()
    {
        //Debug.DrawRay(transform.position, Vector3.down*groundCheckDistance,Color.red);
        isGrounded = Physics.Raycast(transform.position,Vector3.down,groundCheckDistance, groundLayer);
        return isGrounded;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HealthSystem.instance.Damage(enemeyDamage);
            
        }
        if (collision.gameObject.CompareTag("Can"))
        {
            HealthSystem.instance.Health(20);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coinTotal += coinAmount;
            coint.text = "" + coinTotal;
        }
    }
   

}
