using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float POS_Z = -10.0f;
    [SerializeField] private GameObject playerObject = null;
    private float posX;
    private float posY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void LateUpdate()
    {
        Vector3 new_pos = transform.position;
        new_pos.x = Mathf.Clamp(new_pos.x, -119, 119);
        new_pos.y = Mathf.Clamp(new_pos.y, -89, 89);
        transform.position = new_pos;
    }

    private void move()
    {
        posX = playerObject.transform.position.x;
        posY = playerObject.transform.position.y;
        transform.position = new Vector3(posX, posY, POS_Z);

    }
}
