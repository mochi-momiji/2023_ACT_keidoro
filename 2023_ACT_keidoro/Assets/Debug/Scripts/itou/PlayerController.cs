using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float SPEED = 4.0f;
    private const float BOOSTTIME = 5.0f; 
    private Rigidbody2D rigidBody = null;
    private Vector3 mousePos = Vector3.zero;
    private Vector3 currentPos = Vector3.zero;
    private Vector3 movePos = Vector3.zero;
    private Vector3 verocity = Vector3.zero;
    public bool isBoost = false;
    private float boostTimer = 0.0f;
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
        if(isBoost)
        {
            verocity = movePos * SPEED * 2;
            boostTimer += Time.deltaTime;
            if( boostTimer > BOOSTTIME )
            {
                boostTimer = 0.0f;
                isBoost = false;
            }
        }
        else
        {
            verocity = movePos * SPEED;
        }
    }
}
