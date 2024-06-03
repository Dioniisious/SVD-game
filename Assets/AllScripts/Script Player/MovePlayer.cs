using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public float speed, verticTramplineJump, horizTramplineJump, damageHJump, damageVJump;
    public float secondInvicible;
    public float miniHorizontalJump, miniVerticalJump;
    private bool invicible = false, freeze = false;
    public Camera cam;
    public Transform spawnPosition;
    private Rigidbody2D _rb;
    public bool isChoseTool = false;
    public bool inInteractionArea = false;
    public bool keyQuestResult = false;
    public static bool isLucky = false;
    public string toolInArm;
    public GameObject ZoneObject;
    public GameObject AttackZone;
    public GameObject bridgeReal, tramplineReal;
    public bool ActiveSword = false;
    public bool ActiveHearth = false;
    public bool ActiveHammer = false;
    public bool ActiveKey = false;
    public bool shieldActive = false;
    public float AttackZoneDistanseX;
    public bool ActiveTool = false;
    public float AttackZoneDistanseY;
    public float CountPaper;
    public KeyCode[] validSequenceKeys = new[]
    {
    KeyCode.UpArrow,
    KeyCode.RightArrow,
    KeyCode.DownArrow,
    KeyCode.LeftArrow
    };

    public GameObject[] pictureToTuch;
    public KeyCode[] SequenceKeys;
    public List<KeyCode> SequenceKeysEnter;
    public int count = 0;
    public Transform[] SequenceKeysToCreate;
    public GameObject Canvas;
    public GameObject BackGroundForPush;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        toolInArm = null;
        freeze = false;
        SequenceKeysEnter.Clear();
    }

    private void FixedUpdate()
    {
        AttackZone.transform.position = new Vector3(transform.position.x + AttackZoneDistanseX, transform.position.y + AttackZoneDistanseY, 0);

        if (freeze == false)
            _rb.velocity = transform.TransformDirection(new Vector2(1 * speed * Time.fixedDeltaTime, _rb.velocity.y + 0.0003f));



        if (isChoseTool == true)
        {

            //

            if ((Input.GetKey(SequenceKeys[0])))
            {
                AttackZone.SetActive(false);
                isChoseTool = false;
                StartCoroutine(FreezeFPS(0.3f));
                SequenceKeysEnter.Add(SequenceKeys[0]);
                Debug.Log(SequenceKeys[0]);
                Destroy(GameObject.FindGameObjectWithTag(SequenceKeys[0].ToString()));
            }


            //

            else if ((Input.GetKey(SequenceKeys[1])))
            {
                AttackZone.SetActive(false);
                isChoseTool = false;
                StartCoroutine(FreezeFPS(0.3f));
                SequenceKeysEnter.Add(SequenceKeys[1]);
                Debug.Log(SequenceKeys[1]);
                Destroy(GameObject.FindGameObjectWithTag(SequenceKeys[1].ToString()));


            }


            //

            else if ((Input.GetKey(SequenceKeys[2])))
            {
                AttackZone.SetActive(false);
                isChoseTool = false;
                StartCoroutine(FreezeFPS(0.3f));
                SequenceKeysEnter.Add(SequenceKeys[2]);
                Debug.Log(SequenceKeys[2]);
                Destroy(GameObject.FindGameObjectWithTag(SequenceKeys[2].ToString()));

            }


            if (SequenceKeysEnter.Count > 3)
                SequenceKeysEnter.Clear();

            if (SequenceKeysEnter.Count == 3)
                for (int i = 0; i < SequenceKeysEnter.Count; i++)
                    if (SequenceKeysEnter[i] == SequenceKeys[i])
                    {
                        Debug.Log("Успех!");
                        count = SequenceKeysEnter.Count;
                        BackGroundForPush.SetActive(false);
                        SequenceKeysEnter.Clear();
                    }

            if (count == 3)
            {
                ActiveTool = true;
                isChoseTool = false;
                count = 0;
            }
        }
        if (ActiveTool == true)
        {
            CountPaper = gameObject.GetComponent<Paper>().paperCount;

            if (CountPaper > 0)
            {
                if (Input.GetKey(KeyCode.Alpha1))
                {
                    Debug.Log("Hammer");
                    CountPaper -= 2;

                    ActiveHammer = true;
                    toolInArm = "Hammer";
                    ActiveHammer = true;
                    AttackZone.SetActive(true);
                    isChoseTool = false;
                    toolInArm = null;
                    ActiveTool = false;


                }

                if (Input.GetKey(KeyCode.Alpha2))
                {
                    Debug.Log("Key");
                    toolInArm = "Key";
                    ActiveKey = true;
                    CountPaper -= 1;
                    AttackZone.SetActive(true);
                    toolInArm = null;
                    isChoseTool = false;
                    ActiveTool = false;
                }

                if (Input.GetKey(KeyCode.Alpha3))
                {
                    Debug.Log("Schield");
                    toolInArm = "Shield";
                    shieldActive = true;
                    CountPaper -= 1;
                    if (shieldActive == true)
                        AttackZone.SetActive(true);
                    toolInArm = null;
                    isChoseTool = false;
                    ActiveTool = false;
                }

                if (Input.GetKey(KeyCode.Alpha4))
                {
                    Debug.Log("Sword");
                    toolInArm = "Sword";
                    ActiveSword = true;
                    CountPaper -= 1;
                    if (ActiveSword == true)
                        AttackZone.SetActive(true);
                    toolInArm = null;
                    isChoseTool = false;
                    ActiveTool = false;
                }
                if (Input.GetKey(KeyCode.Alpha5))
                {
                    Debug.Log("Hearth");
                    toolInArm = "Hearth";
                    ActiveHearth = true;
                    CountPaper -= 2;
                    AttackZone.SetActive(true);
                    toolInArm = null;
                    isChoseTool = false;
                    ActiveTool = false;
                }
                if (Input.GetKey(KeyCode.Alpha6))
                {
                    Debug.Log("Bridge");
                    toolInArm = "Bridge";
                    CountPaper -= 2;
                    spawnPosition = ZoneObject.transform.GetChild(1).GetComponent<Transform>();
                    Instantiate(bridgeReal, spawnPosition.position, spawnPosition.rotation);
                    toolInArm = null;
                    isChoseTool = false;
                    ActiveTool = false;
                }
                if (Input.GetKey(KeyCode.Alpha7))
                {
                    Debug.Log("Trampline");
                    toolInArm = "Trampline";
                    CountPaper -= 1;
                    spawnPosition = ZoneObject.transform.GetChild(0).GetComponent<Transform>();
                    Instantiate(tramplineReal, spawnPosition.position, spawnPosition.rotation);
                    toolInArm = null;
                    isChoseTool = false;
                    ActiveTool = false;
                }

                gameObject.GetComponent<Paper>().paperCount = CountPaper;
            }


        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trampoline")
        {
            _rb.AddForce(new Vector2(horizTramplineJump * 1000, verticTramplineJump * 1000) * Time.fixedDeltaTime);
        }

        if (invicible == false)
        {
            if (collision.gameObject.tag == "Spikes" || collision.gameObject.tag == "Lava")
            {
                HealthPlayer health = gameObject.GetComponent<HealthPlayer>();
                _rb.AddForce(new Vector2(damageHJump * 1000, damageVJump * 1000) * Time.fixedDeltaTime);
                health.TakeHit();
                invicible = true;
                StartCoroutine(Invicible(secondInvicible));
            }

            if (collision.gameObject.tag == "Jaba" || collision.gameObject.tag == "Rat" || collision.gameObject.tag == "Wizard" || collision.gameObject.tag == "Scelet" || collision.gameObject.tag == "Slime")
            {
                HealthPlayer health = gameObject.GetComponent<HealthPlayer>();
                _rb.velocity = transform.TransformDirection(new Vector2(0, _rb.velocity.y));
                _rb.AddForce(new Vector2(damageHJump * -100, damageVJump * 300) * Time.fixedDeltaTime);
                health.TakeHit();
                freeze = true;
                invicible = true;
                Physics2D.IgnoreLayerCollision(3, 6, true);
                StartCoroutine(Invicible(secondInvicible));
                StartCoroutine(FreezeDamage(0.6f));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ZoneToJump")
        {
            _rb.AddForce(new Vector2(miniHorizontalJump * 1000, miniVerticalJump * 1000) * Time.fixedDeltaTime);
        }

        if (invicible == false)
        {
            if (collision.gameObject.tag == "Grabli" || collision.gameObject.tag == "Capcan" || collision.gameObject.tag == "Poop")
            {
                HealthPlayer health = gameObject.GetComponent<HealthPlayer>();
                health.TakeHit();
                freeze = true;
                _rb.velocity = transform.TransformDirection(new Vector2(0, _rb.velocity.y));
                Debug.Log("Обожди" + freeze);
                invicible = true;
                StartCoroutine(FreezeDamage(collision.gameObject.GetComponent<Freeze>().secondFreeze));
                StartCoroutine(Invicible(secondInvicible));
            }

        }

        if (collision.gameObject.tag == "PosZone" && toolInArm == null)
        {
            BackGroundForPush.SetActive(true);
            SequenceKeys = GenerateSequence(3);
            isChoseTool = true;
            inInteractionArea = true;
            ZoneObject = collision.gameObject;
            Debug.Log("Player entered the zone!" + isChoseTool);
        }


    }

    private IEnumerator FreezeDamage(float second)
    {
        yield return new WaitForSeconds(second);
        freeze = false;

    }

    private IEnumerator FreezeFPS(float second)
    {
        yield return new WaitForSeconds(second);
        isChoseTool = true;
    }

    private IEnumerator Invicible(float second)
    {
        yield return new WaitForSeconds(second);
        invicible = false;
        Physics2D.IgnoreLayerCollision(3, 6, false);

    }

    private void OnTriggerExit2D(Collider2D contàcted)
    {
        if (contàcted.gameObject.tag == "PosZone")
        {
            DestroyArrowAll();
            isChoseTool = false;
            inInteractionArea = false;
            Debug.Log("Player left the zone!");
        }
    }

    public void CreateObjectWhen(GameObject gameObject, Transform SpawnPoint)
    {
        Instantiate(gameObject, SpawnPoint);
    }

    public KeyCode[] GenerateSequence(int length)
    {
        KeyCode[] sequence = new KeyCode[length];
        GameObject sequenceToTuch;

        if (validSequenceKeys.Length > 0 && pictureToTuch.Length > 0)
            for (int i = 0; i < length; i++)
            {
                int cool = Random.Range(0, validSequenceKeys.Length);
                var key = validSequenceKeys[cool];
                sequence[i] = key;
                //sequenceToTuch = Instantiate(pictureToTuch[cool], SequenceKeysToCreate[i].GetComponent<Transform>().position, Quaternion.identity);
                sequenceToTuch = Instantiate(pictureToTuch[cool], Canvas.transform);
                sequenceToTuch.GetComponent<RectTransform>().position = SequenceKeysToCreate[i].GetComponent<RectTransform>().position;
            }

        return sequence;
    }

    public void DestroyArrowAll()
    {
        GameObject[] DestroyArrow;

        DestroyArrow = GameObject.FindGameObjectsWithTag("UpArrow");
        foreach (GameObject obj in DestroyArrow)
            Destroy(obj);
        DestroyArrow = GameObject.FindGameObjectsWithTag("DownArrow");
        foreach (GameObject obj in DestroyArrow)
            Destroy(obj);
        DestroyArrow = GameObject.FindGameObjectsWithTag("LeftArrow");
        foreach (GameObject obj in DestroyArrow)
            Destroy(obj);
        DestroyArrow = GameObject.FindGameObjectsWithTag("RightArrow");
        foreach (GameObject obj in DestroyArrow)
            Destroy(obj);

    }

}
