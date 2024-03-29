using UnityEngine;

public class RabbitController : MonoBehaviour
{
    const int MIN_ROTATION = 0;     //角度の下限
    const int MAX_ROTATION = 360;   //角度の上限
    const float COOL_TIME = 2.0f;   //方向転換の間隔
    const float SPEED = 2.0f;       //移動スピード

    Rigidbody2D rigidBory;
    [SerializeField]private GameObject ItemControllerObject = null;

    float Timer = 0.0f;     //方向転換までのカウント

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
        //ランダム移動処理
        SetMovement();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Playerに捕まると破壊
        if (collision.gameObject.tag == "Player")
        {
            //アイテム生成関数を取得・呼び出し
            ItemControllerObject.GetComponent<ItemController>().DropItem(transform.position);
            Destroy(gameObject);
        }
        //ウサギ同士で衝突したら反発
        if (collision.gameObject.tag == "Target")
        {
            Vector2 direction = rigidBory.velocity;
            rigidBory.velocity = -direction.normalized * SPEED;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //逃走処理
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
