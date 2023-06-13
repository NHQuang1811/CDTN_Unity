using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAISlime : MonoBehaviour
{
    private Rigidbody2D _rigibody;
    public float circleRadius;
    public GameObject GroundCheck;
    public LayerMask GroundLayer;
    public bool facingRight;
    public bool isGrounded;
    public GameObject WallCheck;
    public bool isWall;
    [SerializeField] public float MovementSpeed;
    // Start is called before the first frame update
    private void Start()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _rigibody.velocity= Vector2.right * MovementSpeed * Time.deltaTime;
        isGrounded = Physics2D.OverlapCircle(GroundCheck.transform.position, circleRadius, GroundLayer);
        isWall = Physics2D.OverlapCircle(WallCheck.transform.position, circleRadius, GroundLayer); 
        if (!isGrounded && facingRight)
        {
            Flip();
        }
        else if(!isGrounded && !facingRight)
        {
            Flip();
        }
        else if (isWall && facingRight)
        {
            Flip();
        }
        else if (isWall && !facingRight)
        {
            Flip();
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));
        MovementSpeed = -MovementSpeed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(GroundCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(WallCheck.transform.position, circleRadius); 
    }
}
