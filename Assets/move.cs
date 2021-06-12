using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D rb2d;

    private CharacterController controller;
    private Vector2 playerVelocity;
    private float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (move != Vector2.zero)
        {
            gameObject.transform.forward = move;
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


    }
}
