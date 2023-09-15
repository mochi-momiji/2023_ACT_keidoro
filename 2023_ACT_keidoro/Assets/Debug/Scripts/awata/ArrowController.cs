using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowController : MonoBehaviour
{
    const float SPEED = 8.0f;

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


    public void Movement(Vector2 form ,Vector2 to)
    {
        rigidBody = GetComponent<Rigidbody2D>();

        Vector2 direction = to - form;

        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
            rigidBody.velocity = direction.normalized * SPEED;
    }
}
