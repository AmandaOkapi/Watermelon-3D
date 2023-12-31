using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float rotationSpd;
    [SerializeField] private float mousePos;

    [SerializeField] private bool isRotating = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)){
            Time.timeScale =1f;


        } 
    }

    void OnMouseDrag(){
        
 
        Time.timeScale =0f;

        //get mouse x
        mousePos= Input.mousePosition.x;
        //get sign
        if (mousePos<=(Screen.width/2)){
            mousePos=1f;
        }
        else{
            mousePos=-1f;
        }
        print("Mouse X:" + mousePos);
        StartCoroutine(Rotate());
        
    }

    private IEnumerator Rotate()
    {
        
        print("Rotate");
        isRotating=true;
        // Rotate the object based on a custom time scale
            
        while (isRotating){    
            transform.Rotate(new Vector3(0,mousePos,0), rotationSpd * CustomTime.deltaTime);


            if (Input.GetMouseButtonUp(0)){
                isRotating=false;
            }
            yield return null;
        }
    }
}

public static class CustomTime
{
    public static float deltaTime => Time.unscaledDeltaTime;
}
