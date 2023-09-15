using UnityEngine;

public class ACT_RabbitContorller : MonoBehaviour
{
    const int MIN_ROTATION = 0;
    const int MAX_ROTATION = 360;
    const float COOL_TIME = 2.0f;
    const float SPEED = 2.0f;

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
        //PlayerÇ…ïﬂÇ‹ÇÈÇ∆îjâÛ
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
        //ì¶ëñèàóù
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
}
