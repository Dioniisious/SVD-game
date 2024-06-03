using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject Player;
    public bool heartIsActive = false;

    private void FixedUpdate()
    {
        heartIsActive = Player.GetComponent<MovePlayer>().ActiveHearth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (heartIsActive == true)
        {
            if (collision.gameObject.tag == "Door")
            {
                Debug.Log("Сердца недостаточно, чтобы открыть дверь");
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Wizard")
            {
                Debug.Log("Маг такое сердце как раз таки и искал!");
                Destroy(collision.gameObject);
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Scelet")
            {
                Debug.Log("Ему это больше не нужно");
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Rat")
            {
                Debug.Log("Крыса не голодна");
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Slime")
            {
                Debug.Log("Сердце застряло в слайме");
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Jaba")
            {
                Debug.Log("Жабе понравилось твоё сердце");
                Destroy(collision.gameObject);
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (heartIsActive == true)
        {
            if (collision.gameObject.tag == "Capcan")
            {
                Debug.Log("Капкан захлопнулся");
                Destroy(collision.gameObject);
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Grabli")
            {
                Debug.Log("Сердце в этом не поможет");
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Poop")
            {
                Debug.Log("Потерял сердце в этом навозе");
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Rest")
            {
                Debug.Log("Ты отдохнул и восполнил здоровье");
                Player.GetComponent<HealthPlayer>().SetHealth();
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);
            }

        }
    }
}
