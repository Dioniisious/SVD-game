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
                Debug.Log("�� ��������� ���������� ��� �����");
                Destroy(collision.gameObject);
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Wizard")
            {
                Debug.Log("���� �� ��������� ���� �������");
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Scelet")
            {
                Debug.Log("������ ����������� � ����� �� ����� ���������");
                Destroy(collision.gameObject);
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Rat")
            {
                Debug.Log("������� �������� ������� �� �����");
                Destroy(collision.gameObject);
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Slime")
            {
                Debug.Log("������������ � ������");
                Destroy(collision.gameObject);
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Jaba")
            {
                Debug.Log("���� ������ �� �������������");
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
                Debug.Log("������ �����������");
                Destroy(collision.gameObject);
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Grabli")
            {
                Debug.Log("������� � ���� �� ������� � ���� �� �������");
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Poop")
            {
                Debug.Log("�� ������ ����� ����� ����������� � �������");
                Destroy(collision.gameObject);
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "BlockNotSoGood")
            {
                Debug.Log("����� ������� ������");
                Destroy(collision.transform.parent.gameObject);
                hammerIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveHammer = hammerIsActive;
                gameObject.SetActive(false);
            }

        }
    }
}
