using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed, verticTramplineJump, horizTramplineJump, damageHJump, damageVJump;
    public float secondInvicible;
    public float miniHorizontalJump, miniVerticalJump;
    private bool invicible = false, freeze = false;
    public Camera cam;
    private Rigidbody2D _rb;
    public bool isChoseTool = false;
    public string toolInArm;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (freeze == false)
            _rb.velocity = transform.TransformDirection(new Vector2(1 * speed * Time.fixedDeltaTime, _rb.velocity.y + 0.0003f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trampoline")
        {
            Debug.Log("Trampoline");
            _rb.AddForce(new Vector2(horizTramplineJump * 1000, verticTramplineJump * 1000) * Time.fixedDeltaTime);
        }

        if (invicible == false)
            if (collision.gameObject.tag == "Spikes" || collision.gameObject.tag == "Lava" || collision.gameObject.tag == "Grabli")
            {
                Debug.Log(collision.gameObject.tag);
                HealthPlayer health = gameObject.GetComponent<HealthPlayer>();
                _rb.AddForce(new Vector2(damageHJump * 1000, damageVJump * 1000) * Time.fixedDeltaTime);
                health.TakeHit();
                StartCoroutine(Invicible(secondInvicible));
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ZoneToJump")
        {
            Debug.Log("TrampolineZone");
            _rb.AddForce(new Vector2(miniHorizontalJump * 1000, miniVerticalJump * 1000) * Time.fixedDeltaTime);
        }

        if (invicible == false)
            if (collision.gameObject.tag == "Grabli" || collision.gameObject.tag == "Capcan")
            {
                Debug.Log(collision.gameObject.tag);
                HealthPlayer health = gameObject.GetComponent<HealthPlayer>();
                health.TakeHit();
                freeze = true;
                _rb.velocity = transform.TransformDirection(new Vector2(0, _rb.velocity.y));
                StartCoroutine(FreezeDamage(collision.gameObject.GetComponent<Freeze>().secondFreeze));
                StartCoroutine(Invicible(secondInvicible));
            }
    }

    private IEnumerator FreezeDamage(float second)
    {
        yield return new WaitForSeconds(second);
        freeze = false;

    }

    private IEnumerator Invicible(float second)
    {
        yield return new WaitForSeconds(second);
        invicible = true;

    }

    // Вход в зону выбора оружия
    private void OnTriggerEnter(Collider contаcted)
    {
        if (contаcted.gameObject.tag == "possibilityZone")
        {
            Debug.Log("Player entered the zone!");
            // Всплывает менюшка - точнее, предметы из меню
            GameObject swordInMenu = GameObject.Find("SwordMenu");
            GameObject sheildInMenu = GameObject.Find("SheildMenu");
            GameObject hammerInMenu = GameObject.Find("HammerMenu");
            GameObject keyInMenu = GameObject.Find("KeyMenu");
            GameObject bridgeInMenu = GameObject.Find("BridgeMenu");
            GameObject tramplineInMenu = GameObject.Find("TramplineMenu");
            GameObject heartInMenu = GameObject.Find("HeartMenu");

            // Чекаем, на что нажали
            if (Input.GetMouseButtonDown(0))
            {
                // Создаем луч, который идет от камеры через позицию клика
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Смотрим, в какой игровой объект попал луч
                // И действуем в зависимости от того, куда кликнули
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("SwordMenu"))
                    {
                        Debug.Log("Player clicked on Sword!");
                        // Статус: вооружен мечом
                    }
                    if (hit.collider.CompareTag("SheildMenu"))
                    {
                        Debug.Log("Player clicked on Sheild!");
                        // Статус: вооружен щитом
                    }
                    if (hit.collider.CompareTag("HammerMenu"))
                    {
                        Debug.Log("Player clicked on Hammer!");
                        // Статус: вооружен кувалдой
                    }
                    if (hit.collider.CompareTag("KeyManu"))
                    {
                        Debug.Log("Player clicked on Key!");
                        // Статус: вооружен ключом
                    }
                    if (hit.collider.CompareTag("BridgeMenu"))
                    {
                        Debug.Log("Player clicked on Bridge!");
                        // События: построится мост
                    }
                    if (hit.collider.CompareTag("TramplineMenu"))
                    {
                        Debug.Log("Player clicked on Trampline!");
                        // События: построится батут
                    }
                    if (hit.collider.CompareTag("HeartMenu"))
                    {
                        Debug.Log("Player clicked on Heart!");
                        // События: отнимется HP и полетит к жабе
                    }
                }
            }
        }
    }

    // Выход из зоны выбора оружия
    private void OnTriggerExit(Collider contаcted)
    {
        if (contаcted.gameObject.tag == "possibilityZone" && !isChoseTool)
        {
            Debug.Log("Player left the zone!");
            // Выбрал орудие или не успел - убираем менюшку
        }
    }
}
