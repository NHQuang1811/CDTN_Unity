using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class moveLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    public GameObject Player;
    [SerializeField] private float MovementSpeed = -5f;
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            //Player.transform.Translate(MovementSpeed * Time.deltaTime, 0, 0);
            Player.transform.position += new Vector3(MovementSpeed * Time.deltaTime, 0, 0);
            Player.transform.eulerAngles = new Vector3(0, 180, 0);
            print(Player.transform.position);
        }
    }
}
