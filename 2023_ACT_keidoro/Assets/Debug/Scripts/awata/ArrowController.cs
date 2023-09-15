using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowController : MonoBehaviour
{
    const float SPEED = 8.0f;   //矢のスピード

    Renderer renderer;
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    //矢の射出処理
    public void Movement(Vector2 form ,Vector2 to)
    {
        //物理演算コンポーネントを取得
        rigidBody = GetComponent<Rigidbody2D>();

        //射出方向を計算
        Vector2 direction = to - form;

        //射出方向に回転・ベクトルを加える
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        rigidBody.velocity = direction.normalized * SPEED;
    }
}
