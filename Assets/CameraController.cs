using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    bool PlayerIsMovingCamera = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckMouseInput();
        }
    }

    void CheckMouseInput()
    {
        Vector3 mousePos = Input.mousePosition;
        while (true)
        {
            
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("MOUSE HAS CLICKED");
                break;
            }
            else if (Input.mousePosition != mousePos)
            {
                Debug.Log("MOUSE MOVED!!");
                break;
            }
        }
    }

}
