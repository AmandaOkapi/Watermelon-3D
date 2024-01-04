using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool makeFruit = false;
    public GameObject[] fruitArr;


    public Vector3 pos;
    public int myId;
                
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(makeFruit){
            Instantiate(fruitArr[myId+1],pos, gameObject.transform.rotation);
            makeFruit=false;
        }
    }
}
