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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_swordActive == true)
        {
            Debug.Log("��� �������");
            if (collision.gameObject.tag == "Door")
            {
                Debug.Log("���� ������������, ����� ������� �����");
                _swordActive = false;
                Player.GetComponent<MovePlayer>().ActiveSword = _swordActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Wizard")
            {
                Debug.Log("��� �� �������� ���� �������� �� �����");
                _swordActive = false;
                Player.GetComponent<MovePlayer>().ActiveSword = _swordActive;
                gameObject.SetActive(false);

            }

            if (collision.gameObject.tag == "Scelet")
            {
                Debug.Log("������ �� ��������� � �����");
                Destroy(collision.gameObject);
                _swordActive = false;
                Player.GetComponent<MovePlayer>().ActiveSword = _swordActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Rat")
            {
                Debug.Log("�� ������� �����");
                Destroy(collision.gameObject);
                _swordActive = false;
                Player.GetComponent<MovePlayer>().ActiveSword = _swordActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Slime")
            {
                Debug.Log("���� ��� ������� � ������");
                _swordActive = false;
                Player.GetComponent<MovePlayer>().ActiveSword = _swordActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Jaba")
            {
                Debug.Log("���� ���������� ������ ����� ����");
                Destroy(collision.gameObject);
                _swordActive = false;
                Player.GetComponent<MovePlayer>().ActiveSword = _swordActive;
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
                Debug.Log("������ �����������");
                _swordActive = false;
                Player.GetComponent<MovePlayer>().ActiveSword = _swordActive;
                gameObject.SetActive(false);
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.tag == "Grabli")
            {
                Debug.Log("�� ����� �� ������ ��������, �� ������� ���");
                _swordActive = false;
                Player.GetComponent<MovePlayer>().ActiveSword = _swordActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Poop")
            {
                Debug.Log("��� � ������ �� �����, ���� �� ��������");
                _swordActive = false;
                Player.GetComponent<MovePlayer>().ActiveSword = _swordActive;
                gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Spikes")
            {
                Debug.Log("������� ���� ���� ����");
                Destroy(collision.transform.parent.gameObject);
                _swordActive = false;
                Player.GetComponent<MovePlayer>().ActiveSword = _swordActive;
                gameObject.SetActive(false);
            }

        }
    }

}
