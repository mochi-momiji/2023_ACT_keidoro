using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private GameObject[] Item = null;
    private int randomNum;
    private int randomItem;
    public void DropItem(Vector3 pos)
    {
        randomNum = Random.Range(1, 101);
        if(randomNum <=20)
        {
            randomItem = Random.Range(0, Item.Length);
            Instantiate(Item[randomItem],pos,Quaternion.identity);
        }
    }
}
