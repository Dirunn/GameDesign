using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    public float moveSpeed = 150;
    public float turnSpeed = 5f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var movment = new Vector3(horizontal, 0, vertical);

        animator.SetFloat("Speed", vertical);
        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if(vertical != 0)
        {
            characterController.SimpleMove(transform.forward * moveSpeed * vertical);
        }
    }
}
