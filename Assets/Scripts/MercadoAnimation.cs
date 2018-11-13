using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MercadoAnimation : MonoBehaviour, IPointerClickHandler
{

    private Animator animController;
    public bool isUp;

    // Use this for initialization
    void Start () {
        animController = GetComponent<Animator>();
        isUp = animController.GetBool("isUp");
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveButton()
    {
        isUp = animController.GetBool("isUp");
        animController.SetBool("isUp", !isUp);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickEventTriggered();
    }

    /*Click Event*/
    [Serializable]
    public class ClickEvent : UnityEvent { }

    [SerializeField]
    private ClickEvent myOwnEvent = new ClickEvent();
    public ClickEvent onMyOwnEvent { get { return myOwnEvent; } set { myOwnEvent = value; } }

    public void ClickEventTriggered()
    {
        MoveButton();
        int childrens = transform.childCount;
        for(int i = 0; i < childrens; i++)
        {
            Transform go = transform.GetChild(i);
            go.gameObject.SetActive(!isUp);
        }

    }
}
