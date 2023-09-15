using UnityEngine;

public class NPCFactory : MonoBehaviour
{
    public GameObject rabbit1;
    public GameObject rabbit2;
    public GameObject rabbit3;
    public GameObject hunter;

    const int RABBIT_VALUE = 100;
    const int HUNTER_VALUE = 10;
    const float HORIZONTAL_LIMIT = 75.0f;
    const float VERTICAL_LIMIT = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        CreateNPCs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateNPCs()
    {
        Vector2[] rabbitPositions = new Vector2[RABBIT_VALUE];
        Vector2[] hunterPositions = new Vector2[HUNTER_VALUE];

        for(int index = 0; index < rabbitPositions.Length; index++)
        {
            float positionX = Random.Range(-HORIZONTAL_LIMIT, HORIZONTAL_LIMIT);
            float positionY = Random.Range(-VERTICAL_LIMIT, VERTICAL_LIMIT);

            rabbitPositions[index] = new Vector2(positionX, positionY);
            Instantiate(rabbit1, rabbitPositions[index], Quaternion.identity);
        }

        for (int index = 0; index < hunterPositions.Length; index++)
        {
            float positionX = Random.Range(-HORIZONTAL_LIMIT, HORIZONTAL_LIMIT);
            float positionY = Random.Range(-VERTICAL_LIMIT, VERTICAL_LIMIT);

            hunterPositions[index] = new Vector2(positionX, positionY);
            Instantiate(hunter, hunterPositions[index], Quaternion.identity);
        }
    }
}
