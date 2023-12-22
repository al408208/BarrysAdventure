using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rigidbody2d;
    Animator animator;

    Vector2 movement;

    void Awake()
    {
        if(GameObject.FindObjectsOfType<PlayerController>().Length>1) Destroy(gameObject);
        //DontDestroyOnLoad(this);
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        ResetPos();
    }

    void Update()
    {
        CharacterMove();
    }

    void FixedUpdate()
    {
        rigidbody2d.MovePosition(rigidbody2d.position + moveSpeed * Time.fixedDeltaTime * movement);
    }

    void CharacterMove()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    public Vector2 GetPosition()
    {
        return rigidbody2d.position;
    }

    public void ResetPos()
    {
        SpownPoint sp = FindObjectOfType<SpownPoint>();
        rigidbody2d.position = sp.GetComponent<Rigidbody2D>().position;
    }
}
