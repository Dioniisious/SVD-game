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
            Debug.Log("��� �������");
            if (collision.gameObject.tag == "Door")
            {
                Debug.Log("���� ������������, ����� ������� �����");
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Wizard")
            {
                Debug.Log("��� ������� ���� �� ����");
                Destroy(collision.gameObject);
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Scelet")
            {
                Debug.Log("������� ������� �����, �� � ����������");
                Destroy(collision.gameObject);
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Rat")
            {
                Debug.Log("�� �� ������� ����� �� �� �������� ����");
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Slime")
            {
                Debug.Log("���� ��� ������� � ������");
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Jaba")
            {
                Debug.Log("���� ��� ��� ������� ��� ������� � �����");
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
                Debug.Log("� ���� ��������� ������� ���, ��� �� �� ��������� ������");
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Grabli")
            {
                Debug.Log("��� ���� �������� ���� �� �������");
                Destroy(collision.gameObject);
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Poop")
            {
                Debug.Log("��� �� ���� ����������� ���� ������� ������ �� ����");
                _shieldActive = false;
                Player.GetComponent<MovePlayer>().shieldActive = _shieldActive;
                gameObject.SetActive(false);
            }

        }
    }

}

