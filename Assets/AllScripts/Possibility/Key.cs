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
                Debug.Log("���� ��� �� ���� � �������");
                Destroy(collision.gameObject);
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Wizard")
            {
                Debug.Log("���� ��������� ���� �������");
                Destroy(collision.gameObject);
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Scelet")
            {
                Debug.Log("������� �� ����� �� ��� �����");
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Rat")
            {
                Debug.Log("����� �� ����� �����");
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Slime")
            {
                Debug.Log("� ���� �� ����� ������� ������ ������");
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Jaba")
            {
                Debug.Log("���� �� ����� �� ����");
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
                Debug.Log("���� ������� ��������� ��� �������");
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Grabli")
            {
                Debug.Log("��� ������ ��� ������, ��� ������. �� ����� ��� �����");
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Poop")
            {
                Debug.Log("�������������� �� ������, ������� �� ���� � �����");
                keyIsActive = false;
                Player.GetComponent<MovePlayer>().ActiveKey = keyIsActive;
                gameObject.SetActive(false);
            }

        }
    }
}
