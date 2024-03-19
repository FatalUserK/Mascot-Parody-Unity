using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractController : MonoBehaviour
{

    GeneralEventsManager GEM;

    public bool draggable = false;

    public bool hasTileIndicator = false;
    public Sprite tileIndicator = null;

    Vector3 dragOrigin;

    // Start is called before the first frame update
    void Start()
    {
        GEM = GameObject.Find("GEM").GetComponent<GeneralEventsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Interact()
    {
        Vector3 dragOrigin = Input.mousePosition;
        while (Input.GetMouseButton(0))
        {
            if (dragOrigin != Input.mousePosition)
            {
                //Drag();
                break;
            }
        }
    }

    private void OnMouseDrag()
    {
        if (draggable && GEM.selectedObject == gameObject)
        {
            Vector3 newPos = (Camera.main.ScreenToWorldPoint(dragOrigin) - Camera.main.ScreenToWorldPoint(Input.mousePosition)) * -1;
            transform.position += new Vector3(newPos.x, newPos.y, 0);
            dragOrigin = Input.mousePosition;
        }
    }
    private void OnMouseDown()
    {
        dragOrigin = Input.mousePosition;
        Clicked();
    }

    IEnumerator Clicked()
    {
        while (true)
        {
            if (dragOrigin != Input.mousePosition)
            {
                Debug.Log("DRAGGING!!!!!!");
            }


            yield return null;
        }
    }


}
