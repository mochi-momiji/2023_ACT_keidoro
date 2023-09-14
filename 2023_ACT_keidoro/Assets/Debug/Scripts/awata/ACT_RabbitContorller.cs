using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACT_RabbitContorller : MonoBehaviour
{
    const int MIN_ROTATION = 0;
    const int MAX_ROTATION = 360;
    const float COOL_TIME = 2.0f;
    const float SPEED = 2.0f;

    public GameObject ItemA;
    public GameObject ItemB;
    public GameObject ItemC;

    Vector2 diff = new Vector2(0.0f, 0.5f);

    Rigidbody2D rigidBory;

    float Timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //ÉâÉìÉ_ÉÄà⁄ìÆèàóù
        SetMovement();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        //ÉEÉTÉMìØémÇ≈è’ìÀÇµÇΩÇÁîΩî≠
        if (collision.gameObject.tag == "Target")
        {
            Vector2 direction = rigidBory.velocity;
            rigidBory.velocity = -direction.normalized * SPEED;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector2 direction = transform.position - collision.transform.position;

            rigidBory.velocity = direction.normalized * SPEED;
        }
    }

    void Init()
    {
        rigidBory = GetComponent<Rigidbody2D>();
    }

    void SetMovement()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            float angle = Random.Range(MIN_ROTATION, MAX_ROTATION);

            float radian = angle * Mathf.Deg2Rad;

            Vector2 direction = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));

            rigidBory.velocity = direction.normalized * SPEED;

            Timer = COOL_TIME;
        }
    }

    void SearchWall()
    {
        Vector2 origin = transform.position;
        origin.y = transform.position.y + diff.y;

        RaycastHit2D hit = Physics2D.CircleCast(origin, 0.5f, transform.up, 1.0f);

        //RaycastHit2D hit2 = Physics2D.CircleCast(transform.position, 1.0f, transform.up);

        //Debug.DrawRay(origin, transform.up, Color.red, 60);

        /*if(hit2.collider != null)
        {
            Debug.Log("CircleHit");

            Vector2 distance = new Vector2(hit2.point.x - transform.position.x, hit2.point.y - transform.position.y);

            if (distance.magnitude < 1.0f)
            {
                Debug.Log(hit2.normal);

                Vector2 inVector = distance;
                Vector2 inNormal = hit2.normal;
                Vector2 rezult=Vector2.Reflect(inVector, inNormal);

                Vector2 direction = new Vector2(rezult.x - transform.position.x, rezult.y - transform.position.y);

                transform.rotation = Quaternion.LookRotation(direction,Vector3.forward);
            }
            
        }*/

        if (hit.collider != null)
        {
            Vector2 distance = new Vector2(hit.point.x - transform.position.x, hit.point.y - transform.position.y);

            if (distance.magnitude < 2.0f)
            {
                Debug.Log(distance.magnitude);

                if (hit.collider.tag == "Wall")
                {
                    Debug.Log(hit.normal);

                    Vector2 inVector = new Vector2(hit.point.x - transform.position.x, hit.point.y - transform.position.y);
                    Vector2 inNormal = hit.normal;
                    Vector2 rezult = Vector2.Reflect(inVector, inNormal);

                    float angle = Mathf.Atan2(rezult.y, rezult.x);

                    Debug.Log(angle);

                    transform.Rotate(Vector3.forward, angle);

                    Timer = COOL_TIME;
                }
            }
        }
    }

    

   

    void EscapeFromPlayer(float distance)
    {
        
    }
}
