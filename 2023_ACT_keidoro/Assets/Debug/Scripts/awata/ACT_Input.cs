using UnityEngine;

public class ACT_Input : MonoBehaviour
{
    ACT_SceneManager controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ACT_SceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        StartInput();
    }

    void StartInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            controller.StartGame();
        }
    }
}
