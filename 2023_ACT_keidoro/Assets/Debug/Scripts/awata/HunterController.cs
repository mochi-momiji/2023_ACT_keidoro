using UnityEngine;

public class HunterController : MonoBehaviour
{
    const int MIN_ROTATION = 0;
    const int MAX_ROTATION = 360;
    const float MOVE_INTERVAL = 2.0f;
    const float SNAPE_INTERVAL = 0.5f;
    const float SPEED = 2.0f;

    public GameObject arrowPrefab = null;
    
    Renderer renderer;
    Rigidbody2D rigidBory;

    float SnapeTimer = 0.0f;
    float moveTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        rigidBory = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SnapeTimer -= Time.deltaTime;

        if (renderer.isVisible && SnapeTimer <= 0.0f) 
        {
            CreateArrow();

            SnapeTimer = SNAPE_INTERVAL;
        }
    }

    void FixedUpdate()
    {
        SetMovement();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector2 direction = collision.transform.position - transform.position;

            rigidBory.velocity = direction.normalized * SPEED;
        }
    }

    void SetMovement()
    {
        moveTimer -= Time.deltaTime;

        if (moveTimer <= 0)
        {
            float angle = Random.Range(MIN_ROTATION, MAX_ROTATION);

            float radian = angle * Mathf.Deg2Rad;

            Vector2 direction = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));

            rigidBory.velocity = direction.normalized * SPEED;

            moveTimer = MOVE_INTERVAL;
        }
    }

    void CreateArrow()
    {
        GameObject Arrow = Instantiate(arrowPrefab, transform.position, Quaternion.EulerRotation(rigidBory.velocity));
        Arrow.GetComponent<ArrowController>().Movement(transform.position, (Vector2)rigidBory.velocity);
    }
}
