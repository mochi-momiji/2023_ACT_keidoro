using JetBrains.Annotations;
using UnityEngine;

public class ACT_TargetController : MonoBehaviour
{
    const int MIN_ROTATION = 0;
    const int MAX_ROTATION = 360;
    const float COOL_TIME = 2.0f;
    const float MOVEMENT_SPEED = 2.0f;
    const float ROTATION_SPEED = 5.0f;

    Rigidbody2D rb;
    Vector3 moveDirection;

    float Timer = 0.0f;

    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetMovement()
    {
        rb.velocity =transform.up * MOVEMENT_SPEED;
    }

    public void SetRotation()
    {
        Timer -= Time.deltaTime;

        if(Timer <= 0)
        {
            float radius = Random.Range(MIN_ROTATION, MAX_ROTATION);

            transform.Rotate(0.0f, 0.0f, radius * Time.deltaTime*2);

            Timer = COOL_TIME;
        }
    }

    void SearchWall()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.1f);

        if (hit)
        {

        }
    }

    void ColitionRotation()
    {

    }
}
