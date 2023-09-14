using UnityEngine;

public class NPCFactory : MonoBehaviour
{
    public GameObject rabbit1;
    public GameObject rabbit2;
    public GameObject rabbit3;
    public GameObject hunter;

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
        Vector2[] rabbitPositions = new Vector2[100];
        Vector2[] hunterPositions = new Vector2[10];

        for(int index = 0; index < rabbitPositions.Length; index++)
        {
            float positionX = Random.Range(-75, 75);
            float positionY = Random.Range(-30, 30);

            rabbitPositions[index] = new Vector2(positionX, positionY);
            Instantiate(rabbit1, rabbitPositions[index], Quaternion.identity);
        }

        for (int index = 0; index < hunterPositions.Length; index++)
        {
            float positionX = Random.Range(-75, 75);
            float positionY = Random.Range(-30, 30);

            hunterPositions[index] = new Vector2(positionX, positionY);
            Instantiate(hunter, hunterPositions[index], Quaternion.identity);
        }
    }
}
