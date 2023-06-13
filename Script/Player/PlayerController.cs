using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IDataPersistence
{
    private SpriteRenderer sprite;
    private Rigidbody2D _rigibody;
    private Animator anmt;
    private Health heart;
    private bool isMovingLeft;
    private bool isMovingRight;
    private bool JumpInput = false;
    public bool isGrounded;
    public LayerMask GroundLayer;
    public float KBForce;
    public float Radius;

    public bool canMove = true;
    [SerializeField] private Vector2 kbSpeed;

    [SerializeField] private float JumpForce = 15f;
    [SerializeField] private float JumpRelease = 2f;
    [SerializeField] private float MovementSpeed = 5f;

    private enum MovementState { Idle, Running, Jumping, Falling}

    private void Start()
    {
        _rigibody= GetComponent<Rigidbody2D>();
        anmt = GetComponent<Animator>();
        sprite= GetComponent<SpriteRenderer>();
        isMovingLeft = false;
        isMovingRight = false;
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.3f, transform.position.y - 0.75f),
            new Vector2(transform.position.x + 0.3f, transform.position.y - 0.81f), GroundLayer);
        if (canMove && !DialogueManager.GetInstance().dialoguePlaying)
        {
            UpdateAnimationState();
            if (isMovingLeft && isMovingRight == false)
            {
                transform.Translate(MovementSpeed * Time.deltaTime, 0, 0);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (isMovingRight && isMovingLeft == false)
            {
                transform.Translate(MovementSpeed * Time.deltaTime, 0, 0);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.Translate(0 * Time.deltaTime, 0, 0);
            }
            if (isGrounded && JumpInput)
            {
                _rigibody.velocity = new Vector2(_rigibody.velocity.x, JumpForce);
                AudioManager.Instance.PlaySFX("PlayerJump");
            }
            if (JumpInput == false && _rigibody.velocity.y > 0)
            {
                _rigibody.velocity = new Vector2(_rigibody.velocity.x, _rigibody.velocity.y / JumpRelease);
            }
        }
    }

    public void moveLeft()
    {
        isMovingLeft = true;
    }
    public void stopMoveLeft()
    {
        isMovingLeft = false;
    }
    public void moveRight()
    {
        isMovingRight = true;
    }
    public void stopMoveRight()
    {
        isMovingRight = false;
    }
    public void Jump()
    {
        JumpInput = true;
    }
    public void notJump()
    {
        JumpInput = false;
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if(isMovingRight)
        {
            state = MovementState.Running;
        }
        else if(isMovingLeft)
        {
            state = MovementState.Running;
        }
        else
        {
            state = MovementState.Idle;
        }

        if(_rigibody.velocity.y > .1f)
        {
            state = MovementState.Jumping;
        }
        else if(_rigibody.velocity.y < -.1f)
        {
            state = MovementState.Falling;
        }
        anmt.SetInteger("state", (int)state);
    }

    public void KnockBack(Vector2 hitPoint)
    {
        _rigibody.velocity = new Vector2(-kbSpeed.x * hitPoint.x, kbSpeed.y);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.805f),
            new Vector2(0.75f, 0.02f));
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.RespawnPoint;
    }
    public void SaveData(GameData data)
    {
    }
}
