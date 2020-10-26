using UnityEngine;

using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public Sprite northSprite;
    public Sprite eastSprite;
    public Sprite southSprite;
    public Sprite westSprite;

    public Animator animator;

    public float walkSpeed = 4.0f;
    private float regSpeed;
    public string DefaultPos;

    public bool move;

    private Vector2 direction;

    void Start()
    {
        
    }

    void Update()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
            move = true;
            AnimatorMovement("idletoup");
            DefaultPos = "up";
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            move = true;
            AnimatorMovement("idletoleft");
            DefaultPos = "left";
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
            move = true;
            AnimatorMovement("idletodown");
            DefaultPos = "down";
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            move = true;
            AnimatorMovement("idletoright");
            DefaultPos = "right";
        }
        if (move)
        {
            transform.Translate(direction * walkSpeed * Time.deltaTime);
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
            {
                AnimatorMovement("idle");
                move = false;
            }
        }
    }
    void LateUpdate()
    {
        if (move == false)
        {
            this.GetComponentInChildren<Animator>().Rebind();
            DefaultPosition(DefaultPos);
        }
    }
    public void AnimatorMovement(string condition)
    {
        if (condition == "idletoleft")
        { animator.SetBool(condition, true); }
        else if (condition == "idletoright")
        { animator.SetBool(condition, true); }
        else if (condition == "idletoup")
        { animator.SetBool(condition, true); }
        else if (condition == "idletodown")
        { animator.SetBool(condition, true); }
        else if (condition == "idle")
        { animator.SetBool(condition, true); }

    }
    public void DefaultPosition(string pos)
    {
        if (pos == "up")
        { this.GetComponentInChildren<SpriteRenderer>().sprite = northSprite; }
        else if (pos == "down")
        { this.GetComponentInChildren<SpriteRenderer>().sprite = southSprite; }
        else if (pos == "left")
        { this.GetComponentInChildren<SpriteRenderer>().sprite = westSprite; }
        else if (pos == "right")
        { this.GetComponentInChildren<SpriteRenderer>().sprite = eastSprite; }
    }
}

