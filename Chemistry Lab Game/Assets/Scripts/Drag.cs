using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour

{
    //Private public değiş
    private bool isDrag = false;
    private GameObject dragObj;
    private Vector3 dragPos;
    


    void Start()
    {
        
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                RaycastHit2D ray_cast_hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);

                if(ray_cast_hit.collider != null && ray_cast_hit.collider.tag == "DragObject")
                {
                    isDrag = true;
                    dragObj = ray_cast_hit.collider.gameObject;
                    dragPos = dragObj.transform.position;
                }
            }

            if(touch.phase == TouchPhase.Moved)
            {
                if (isDrag)
                {
                    dragPos = Camera.main.ScreenToWorldPoint(touch.position);
                    dragPos.z = (float)-0.1; 
                }

            }
            if(touch.phase == TouchPhase.Ended)
            {
                isDrag = false;
                
            }
        }

        if (isDrag)
        {
            dragObj.transform.position = dragPos;
        }
        
    }
}
