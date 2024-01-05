using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    // Start is called before the first frame update
    public int myId;
    //private GameObject Obj_fruitManager;

    private FruitManager fruitManager;
    public GameObject myFruit;
    void Start()
    {

        fruitManager= GameObject.Find("FruitManager").GetComponent<FruitManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*
    void onCollisionEnter(Collision collision){
        Debug.Log("Collision");
        //if the tag of collsion is same as the host fruits tag
        if (collision.gameObject.tag== gameObject.tag){
            Debug.Log(gameObject.tag + "collision");

            if (myId+2< fruitManager.fruitArr.Length){
                ContactPoint contact = collision.contacts[0];
                Vector3 pos= contact.point;
                GameObject newFruit=Instantiate(fruitManager.fruitArr[myId+1],pos, gameObject.transform.rotation);

            }            
            //newFruit.myId=myId+1;
            Destroy(collision.gameObject);
            Destroy(gameObject);


        }
    }
*/

void OnCollisionEnter(Collision collision)
{
         Debug.Log("Collision");
        //if the tag of collsion is same as the host fruits tag
        if (collision.gameObject.tag== gameObject.tag){

            Debug.Log(gameObject.tag + "collision");

            if (myId+2< fruitManager.fruitArr.Length){
                fruitManager.backlog+=1;
                
                ContactPoint contact = collision.contacts[0];
                Vector3 pos = contact.point;

                (int,Vector3, Quaternion) propertiesTuple = (myId, pos, transform.rotation);
    print(propertiesTuple);
                fruitManager.backlogList.Add(propertiesTuple);
                fruitManager.makeFruit=true;

                //StartCoroutine(spawnNewFruit(collision));

              /*  
                ContactPoint contact = collision.contacts[0];
                
                fruitManager.pos= contact.point;
                fruitManager.myId =myId;
                fruitManager.makeFruit=true;
                //Instantiate(fruitManager.fruitArr[myId+1],pos, gameObject.transform.rotation);
            */
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }       
           
            //newFruit.myId=myId+1;
           


        }
}
/*
    IEnumerator spawnNewFruit(Collision collision){
        print("enumerator1");

        while (fruitManager.backlog>=2){
                fruitManager.sentCol=collision;
                
                ContactPoint contact = collision.contacts[0];
                fruitManager.pos= contact.point;
                fruitManager.myId =myId;
                fruitManager.r =transform.rotation;


                fruitManager.makeFruit=true;
                print("enumerator2");
            yield return null;
        }
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
*/
}
