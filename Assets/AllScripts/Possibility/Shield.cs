using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject Player;
    public bool _shieldActive = false;

    private void FixedUpdate()
    {
        _shieldActive = Player.GetComponent<MovePlayer>().shieldActive;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_shieldActive == true)
        {
            Debug.Log("Щит Активен");
            if (collision.gameObject.tag == "Door")
            {
                Debug.Log("Щита недостаточно, чтобы сломать дверь");
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Wizard")
            {
                Debug.Log("Щит защитил тебя от мага");
                Destroy(collision.gameObject);
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Scelet")
            {
                Debug.Log("Толкнул скелета мечом, он и развалился");
                Destroy(collision.gameObject);
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Rat")
            {
                Debug.Log("Ты не заметил крысу из за большого щита");
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Slime")
            {
                Debug.Log("Твой щит застрял в слайме");
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Jaba")
            {
                Debug.Log("Твой щит был потерян при схватке с жабой");
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_shieldActive == true)
        {
            if (collision.gameObject.tag == "Capcan")
            {
                Debug.Log("У тебя настолько большой щит, что ты не замечаешь капкан");
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Grabli")
            {
                Debug.Log("Щит смог защитить тебя от Грабель");
                Destroy(collision.gameObject);
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Poop")
            {
                Debug.Log("Щит не дает возможности тебе увидеть какаху на пути");
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);
            }

        }
    }

}

