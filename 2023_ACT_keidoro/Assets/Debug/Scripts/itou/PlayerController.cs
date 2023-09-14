using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float SPEED = 4.0f;
    private Rigidbody2D rigidBody = null;
    private Vector3 mousePos = Vector3.zero;
    private Vector3 currentPos = Vector3.zero;
    private Vector3 movePos = Vector3.zero;
    private Vector3 verocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void FixedUpdate()
    {
        if (rigidBody == null)
        {
            return;
        }
        rigidBody.velocity = verocity;
    }

    private void move()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPos = transform.position;
        movePos = mousePos - currentPos;
        movePos.Normalize();
        verocity = movePos * SPEED;
    }
}
