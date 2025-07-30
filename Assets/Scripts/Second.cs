using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Required for IPointerClickHandler

public class Card : MonoBehaviour, IPointerClickHandler
{
    public CardScriptableobject card;
    public bool clicked = false;
    public Animator AnimatorControler;

    private void Start()
    {
        AnimatorControler = gameObject.GetComponent<Animator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Card clicked");

        if (!GameManger.instance.Checking)
        {
            if (!clicked)
            {
                GameManger.instance.clickCount++;
                AnimatorControler.SetBool("on", true);

                if (GameManger.instance.clickCount % 2 != 0)
                {
                    clicked = true;
                    GameManger.instance.one = gameObject;
                }
                else
                {
                    clicked = true;
                    GameManger.instance.two = gameObject;
                    GameManger.instance.Checking = true;
                    GameManger.instance.Invoke("CheckCard", 1f);
                    GameManger.instance.turnCounter();
                }
            }
        }
    }
}
