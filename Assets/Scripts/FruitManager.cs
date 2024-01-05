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

    public int backlog = 0;

    public Collision sentCol;

    public Quaternion r;

    //list of tuples
    public List<(int,Vector3, Quaternion)> backlogList  = new List<(int, Vector3, Quaternion)>();

    //maybe i should set up a constantly resetting counter int that will panic if its bigger than 1
                
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(backlogList);
        if(makeFruit){
            StartCoroutine(WaitForFiveSeconds());
makeFruit=false;
    }

    }
        IEnumerator WaitForFiveSeconds()
    {
        // Waits for 5 seconds
        yield return new WaitForSeconds(5f);

        // This code executes after waiting for 5 seconds
        Debug.Log("Waited for 5 seconds!");

                    print("hi");
            //sentCol.gameObject.myId =myId;
            //get pos
            //ContactPoint contact = sentCol.contacts[0];
            //pos =contact.point;
            List<(int,Vector3, Quaternion)> duplicates  = new List<(int, Vector3, Quaternion)>();
            bool isDup=false;
            int cnt=0;
            foreach ((int,Vector3, Quaternion) item in backlogList){
                cnt+=1;
                        print(backlogList +" "+ cnt );

                print(item);
                int a = item.Item1; // Accessing the first item (int)
                Vector3 position = item.Item2; // Accessing the second item (Vector3)
                Quaternion rotation = item.Item3; // Accessing the third item (Quaternion)


                //check for dups

                    foreach ((int,Vector3, Quaternion) dup in duplicates){
                        if ( (a==dup.Item1) && (position==dup.Item2 ) ){
                            print("found");
                            isDup=true;
                            break;
                        }
                    }
                duplicates.Add(item);

                if (isDup==false){
                    print("making" + item + "with" + a + position + rotation);
                    Instantiate(fruitArr[a+1],position, rotation);
                }

                isDup=false;
            }
                //backlog-=2;
            backlogList.Clear();
        }
    
}
