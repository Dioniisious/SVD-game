using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public GameObject Player;
    public bool hammerIsActive = false;

    private void FixedUpdate()
    {
        hammerIsActive = Player.GetComponent<MovePlayer>().ActiveHammer;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hammerIsActive == true)
        {
            if (collision.gameObject.tag == "Door")
            {
                Debug.Log("Ты буквально разрушаешь эту дверь");
                Destroy(collision.gameObject);
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Wizard")
            {
                Debug.Log("Магу не интересна твоя кувалда");
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Scelet")
            {
                Debug.Log("Скелет рассыпается в щепке от удара куувалдой");
                Destroy(collision.gameObject);
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Rat")
            {
                Debug.Log("Оставил кровавый ошметок от крысы");
                Destroy(collision.gameObject);
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Slime")
            {
                Debug.Log("Превратилась в лужицу");
                Destroy(collision.gameObject);
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Jaba")
            {
                Debug.Log("Жаба ничего не почувствовала");
                Destroy(collision.gameObject);
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hammerIsActive == true)
        {
            if (collision.gameObject.tag == "Capcan")
            {
                Debug.Log("Капкан захлопнулся");
                Destroy(collision.gameObject);
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Grabli")
            {
                Debug.Log("Кувалда в этом не поможет в этом не поможет");
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Poop")
            {
                Debug.Log("От такого удара навоз разелетелся в стороны");
                Destroy(collision.gameObject);
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "BlockNotSoGood")
            {
                Debug.Log("Блоку неочень хорошо");
                Destroy(collision.transform.parent.gameObject);
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);
            }

        }
    }
}
