using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour
{
    [SerializeField] private GameObject[] HPObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHitPointUI(int current_hp)
    {
        //全てを非アクティブにする
        for (int i = 0; i < HPObject.Length; i++)
        {
            HPObject[i].SetActive(false);
        }
        for (int i = 0; i < current_hp; i++)
        {
            HPObject[i].SetActive(true);
        }
    }
}
