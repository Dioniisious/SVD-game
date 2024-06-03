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
                Debug.Log("������ ������������, ����� ������� �����");
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Wizard")
            {
                Debug.Log("��� ����� ������ ��� ��� ���� � �����!");
                Destroy(collision.gameObject);
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Scelet")
            {
                Debug.Log("��� ��� ������ �� �����");
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Rat")
            {
                Debug.Log("����� �� �������");
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Slime")
            {
                Debug.Log("������ �������� � ������");
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Jaba")
            {
                Debug.Log("���� ����������� ��� ������");
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
                Debug.Log("������ �����������");
                Destroy(collision.gameObject);
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Grabli")
            {
                Debug.Log("������ � ���� �� �������");
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Poop")
            {
                Debug.Log("������� ������ � ���� ������");
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Rest")
            {
                Debug.Log("�� �������� � ��������� ��������");
                Player.GetComponent<HealthPlayer>().SetHealth();
                heartIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHearth = heartIsActive;
                gameObject.SetActive(false);
            }

        }
    }
}
