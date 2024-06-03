using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject Player;
    public bool _swordActive = false;

    private void FixedUpdate()
    {
        _swordActive = Player.GetComponent<MovePlayer>().ActiveSword;
        Player.GetComponent<MovePlayer>().ActiveSword = _swordActive;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_swordActive == true)
        {
            Debug.Log("Меч Активен");
            if (collision.gameObject.tag == "Door")
            {
                Debug.Log("Меча недостаточно, чтобы сломать дверь");
                _swordActive = false;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Wizard")
            {
                Debug.Log("Меч не способен тебя защитить от магии");
                _swordActive = false;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Scelet")
            {
                Debug.Log("Скелет не справится с мечом");
                Destroy(collision.gameObject);
                _swordActive = false;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Rat")
            {
                Debug.Log("Ты зарубил крысу");
                Destroy(collision.gameObject);
                _swordActive = false;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Slime")
            {
                Debug.Log("Твой меч застрял в слайме");
                _swordActive = false;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Jaba")
            {
                Debug.Log("Жаба проглотила острый конец меча");
                Destroy(collision.gameObject);
                _swordActive = false;
                gameObject.SetActive(false);
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_swordActive == true)
        {
            if (collision.gameObject.tag == "Capcan")
            {
                Debug.Log("Капкан захлопнулся");
                _swordActive = false;
                gameObject.SetActive(false);
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.tag == "Grabli")
            {
                Debug.Log("От удара по голове граблями, ты теряешь меч");
                _swordActive = false;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Poop")
            {
                Debug.Log("Как с говном не бейся, тебе не победить");
                _swordActive = false;
                gameObject.SetActive(false);
            }

        }
    }

}
