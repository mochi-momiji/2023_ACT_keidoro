using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowController : MonoBehaviour
{
    const float SPEED = 8.0f;   //��̃X�s�[�h

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

    //��̎ˏo����
    public void Movement(Vector2 form ,Vector2 to)
    {
        //�������Z�R���|�[�l���g���擾
        rigidBody = GetComponent<Rigidbody2D>();

        //�ˏo�������v�Z
        Vector2 direction = to - form;

        //�ˏo�����ɉ�]�E�x�N�g����������
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        rigidBody.velocity = direction.normalized * SPEED;
    }
}
