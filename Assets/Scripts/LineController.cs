using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LineController : MonoBehaviour
{
    public GameObject player;
    public float horizontal, vertical;
    public GameObject ShotPoint;
    public float blastPower = 5f;
    public float rotationDistance;
    public float rotationSpeed = 1;
    private Vector3 mousePressDownPos;
    public bool isJumped, isFinished;
    //DrawProjection drawProjection;
    //Movement movement;
    [SerializeField] Rigidbody movementRb;
    MovementPhone movementPhone;

    //public GameObject Cannonball;
    //public Transform ShotPoint;
    // Start is called before the first frame update

    private void Start()
    {
        movementPhone = GetComponent<MovementPhone>();
        isJumped = false;
        isFinished = false;
        GetComponent<LineRenderer>().enabled = false;
        //ShotPoint.SetActive(false);
        //movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }
    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(gameObject.transform.eulerAngles.x);
        rotationDistance = transform.eulerAngles.x; 
        rotationDistance = Mathf.Clamp(rotationDistance, 292, 337);
        transform.rotation = Quaternion.Euler(rotationDistance, 0, 0);
        if (MovementPhone.isGameStart == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePressDownPos = Input.mousePosition;

                //SADECE FÝNÝSH LÝNE'DE ZIPLAYIP KAPANMASINI ÝSTÝYORSAN BU IF'Ý AÇ!!!
                //if (Movement.isFinished == true)
                //{
                if (MovementPhone.grounded == true && MovementPhone.isSlowed == true)
                {
                    GetComponent<LineRenderer>().enabled = true;
                    //isFinished = true;
                }
                

                //}
            }
            if (Input.GetMouseButton(0))
            {
                Vector3 forceInit = mousePressDownPos - Input.mousePosition;
                if (mousePressDownPos.y > Input.mousePosition.y)
                {
                    transform.Rotate(-50 * Time.fixedDeltaTime, 0, 0);
                }
                else
                {
                    transform.Rotate(50 * Time.fixedDeltaTime, 0, 0);
                }
            }
            //if (isFinished == true)
            //{
                if (MovementPhone.grounded == true && MovementPhone.isSlowed == true)
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                        MovementPhone.isSlowed = false;
                        player.GetComponent<Rigidbody>().velocity = ShotPoint.transform.forward * blastPower;
                        MovementPhone.isFinished = false;
                        isFinished = false;
                        GetComponent<LineRenderer>().enabled = false;
                    }
                }
            //}
        }
            //TOUCH KODU TELEFON ÝÇÝN ÇALIÞAN LÝNERENDERER HAREKET KODU
            //if(Input.touchCount > 0)
            //{
            //    Touch finger = Input.GetTouch(0);

            //        if(finger.phase == TouchPhase.Moved && finger.deltaPosition.x > 5f)
            //        {
            //            //transform.position += Vector3.right * 15 * Time.deltaTime;
            //            transform.Rotate(1, 0, 0);
            //        }

            //        if (finger.phase == TouchPhase.Moved && finger.deltaPosition.x < -5f)
            //        {
            //            //transform.position += Vector3.left * 15 * Time.deltaTime;
            //            transform.Rotate(-1, 0, 0);
            //        }

            //}

            //MOUSE KODU TELEFON ÝÇÝN ÇALIÞAN LÝNERENDERER HAREKET KODU
            //if (Input.GetMouseButton(0))
            //{
            //    Debug.Log(Input.mousePosition.y);
            //    if (Input.mousePosition.y - Screen.height / 2 > 5f)
            //    {
            //        transform.Rotate(1, 0, 0);
            //    }
            //    if (Input.mousePosition.y - Screen.height / 2 < -5f)
            //    {
            //        transform.Rotate(-1, 0, 0);
            //    }
            //}


            //if (Input.GetMouseButtonUp(0))
            //{
            //    player.GetComponent<Rigidbody>().velocity = ShotPoint.transform.forward * blastPower;
            //}

       
 

        //LÝNERENDERER PC KEYBOARD HAREKET KODU
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.Rotate(5, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.Rotate(-5, 0, 0);
        //}


        //Debug.Log(gameObject.transform.rotation.x);
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //player.GetComponent<Rigidbody>().AddForce(0, ShotPoint.position.y * blastPower * 1000 * Time.fixedDeltaTime, ShotPoint.position.z * blastPower * 1000 * Time.fixedDeltaTime);
            //player.GetComponent<Rigidbody>().velocity = ShotPoint.transform.forward * blastPower;
            //Vector3 vec = new Vector3(ShotPoint.transform.position.x, ShotPoint.transform.position.y, ShotPoint.transform.position.z);
            player.GetComponent<Rigidbody>().velocity = ShotPoint.transform.forward * blastPower;
            MovementPhone.isFinished = false;
            //player.GetComponent<Rigidbody>().velocity = new Vector3(0, player.GetComponent<Rigidbody>().velocity.y, 20);
            Debug.Log(player.GetComponent<Rigidbody>().velocity);

        }


    }
}
