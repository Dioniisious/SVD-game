using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject Player;
    public bool keyIsActive = false;

    private void FixedUpdate()
    {
        keyIsActive = Player.GetComponent<MovePlayer>().ActiveKey;
        Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (keyIsActive == true)
        {
            if (collision.gameObject.tag == "Door")
            {
                Debug.Log("Хоть кто то смог её открыть");
                Destroy(collision.gameObject);
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Wizard")
            {
                Debug.Log("Магу интересна твоя находка");
                Destroy(collision.gameObject);
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Scelet")
            {
                Debug.Log("Скелету всё равно на эти ключи");
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Rat")
            {
                Debug.Log("Крысе не нужны ключи");
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Slime")
            {
                Debug.Log("У тебя не вышло открыть сердце слайма");
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Jaba")
            {
                Debug.Log("Жаба всё равно на ключ");
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (keyIsActive == true)
        {
            if (collision.gameObject.tag == "Capcan")
            {
                Debug.Log("Ключ слишком маленький для капкана");
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Grabli")
            {
                Debug.Log("Это похоже бич народа, эти грабли. Не нужны ему ключи");
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Poop")
            {
                Debug.Log("Подскользнулся на дерьме, потерял ты ключ в траве");
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);
            }

        }
    }
}
