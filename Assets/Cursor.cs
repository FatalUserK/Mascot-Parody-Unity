using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{


    Vector3 currentPos;
    Vector3Int currentPosInt;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        currentPos = transform.position;
        currentPosInt = new Vector3Int( (int)Mathf.Round(currentPos.x),
                                        (int)Mathf.Round(currentPos.y),
                                        (int)Mathf.Round(currentPos.z));
    }

    public IEnumerator DragObject(GameObject victim)
    {
        if (victim.tag == "testTileDraggable")
        {

        }
        while (!Input.GetMouseButtonUp(0))
        {
            victim.transform.position = new Vector3(currentPosInt.x, currentPosInt.y, victim.transform.position.z);
            yield return null;
        }
    }


}
