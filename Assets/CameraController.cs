using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    bool PlayerIsMovingCamera = false;
    GameObject cursor;

    void Start()
    {
        cursor = GetComponentInChildren<Cursor>().gameObject;
        dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }



    public float dragSpeed = 2;
    private Vector3 dragOrigin;
    Vector3 mousePos;


    // Update is called once per frame
    void Update()
    {




        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);






        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("MOUSE INPUT DETECTED, RUNNING MOUSE-INPUT HANDLER SCRIPT...");
            StartCoroutine(CheckMouseInput(GetUnderCursor()));
        }
    }

    IEnumerator CheckMouseInput(GameObject target = null)
    {
        dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        while (!Input.GetMouseButtonUp(0))
        {
            
            if (dragOrigin != Camera.main.ScreenToWorldPoint(Input.mousePosition))
            {
                if (target != null)
                {
                    StartCoroutine(cursor.GetComponent<Cursor>().DragObject(target));
                    break;
                }
                else
                {
                    Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - dragOrigin;
                    //Debug.Log("difference = " + difference);

                    transform.position = difference * -1 + transform.position;
                    PlayerIsMovingCamera = true;
                }
            }
            dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            //if (Input.GetMouseButtonUp(0))
            //{
            //    if (!PlayerIsMovingCamera) { Debug.Log("MOUSE HAS CLICKED"); }
            //    else
            //    {
            //        Debug.Log("CAMERA HAS BEEN RELEASED");
            //        PlayerIsMovingCamera = false;
            //    }

            //    break;
            //}
            //else if (Input.mousePosition != mousePos)
            //{
            //    PlayerIsMovingCamera = true;
            //    while (PlayerIsMovingCamera)
            //    {
            //        Debug.Log("MOUSE MOVED " + (mousePos - Input.mousePosition) + "!!");
            //    }
            //    break;
            //}
            //mousePos = Input.mousePosition;
            yield return null;
        }

        if (PlayerIsMovingCamera) { Debug.Log("CAMERA HAS BEEN RELEASED"); }
        else { MouseClick(); }
        PlayerIsMovingCamera = false;
    }


    public GameObject GetUnderCursor()
    {
        int layerObject = 8;
        Vector2 ray = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(ray, ray, layerObject);
        if (hit.collider != null)
        {
            Debug.Log("investigating " + hit.collider.gameObject.name);
            return hit.collider.gameObject;
        }
        else return null;
    }





    void MouseClick()
    {
        Debug.Log("INPUT RECEIVED");
    }





}
