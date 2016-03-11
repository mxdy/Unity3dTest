using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DragWindow : MonoBehaviour {

    public Image touchTitle;

    public GameObject eventSystemObj;
    public Canvas canvas;

    //EventSystem es;
    GraphicRaycaster gr;

	// Use this for initialization
	void Start () {
        //es = eventSystemObj.GetComponent<EventSystem>();
        gr = canvas.GetComponent<GraphicRaycaster>();
    }
	
	// Update is called once per frame
	void Update () {
        //if (CheckGuiRaycastObjects()) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject);
        }
	}

    bool CheckGuiRaycastObjects()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.pressPosition = Input.mousePosition;
        eventData.position = Input.mousePosition;
        List<RaycastResult> list = new List<RaycastResult>();
        gr.Raycast(eventData, list);
        //Debug.Log(list.Count);
        return list.Count > 0;
    }
}
