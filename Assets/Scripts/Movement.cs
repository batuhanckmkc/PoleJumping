using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //ÞÝMDÝ KAPATTIM
    //private Transform cameraVirtual;
    //public Transform cameraAngle_1;
    //public GameObject[] particlesFinish;
    //LineController lineController;
    //public Transform tipOfPole;
    //public GameObject playerPole;
    //public GameObject pole;
    //[SerializeField] GameObject cameraAngle_2;
    //public float horizontal, vertical;
    //public static bool isFinished;
    //Animator anim;
    //Rigidbody rb;

    //MovementPhone movementPhone;
    // Start is called before the first frame update
    void Start()
    {
        //ÞÝMDÝ KAPATTIM
        //movementPhone = GetComponent<MovementPhone>();
        //pole.gameObject.transform.position = tipOfPole.position;
        //lineController = GameObject.Find("ShotPoint").GetComponent<LineController>();
        //anim = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
        //isFinished = false;
        //for (int i = 0; i < particlesFinish.Length; i++)
        //{
        //    particlesFinish[i].SetActive(false);
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //ÞÝMDÝ KAPATTIM
        //if(MovementPhone.isGameStart == true)
        //{
        //    if (lineController.isJumped == true)
        //    {
        //        anim.SetTrigger("JumpAnimation");
        //    }

            //horizontal = Input.GetAxis("Horizontal");
            //vertical = Input.GetAxis("Vertical");

            //ÞÝMDÝ KAPATTIM
            //if (isFinished == false && MovementPhone.isGameStart == true)
            //{
            //    transform.Translate(0, 0, 5f * Time.fixedDeltaTime);
            //    anim.SetBool("RunAnimation", true);
            //}

            ////rb.velocity = new Vector3(0,0, 10);
            //if (vertical >= 0.1f)
            //{
            //    anim.SetBool("RunAnimation", true);
            //}
            //else
            //{
            //    anim.SetBool("RunAnimation", false);
            //    Debug.Log("Idle");
            //}

        //ÞÝMDÝ KAPATTIM
        //}

    }

    // ÞÝMDÝ KAPATTIM
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "SCall")
    //    {
    //        Time.timeScale = 0.5f;
    //    }
    //    if (other.gameObject.tag == "FinishLine")
    //    {
    //        isFinished = true;
    //        anim.SetBool("RunAnimation", false);
    //        GetComponent<MovementPhone>().enabled = false;
    //        GetComponent<Movement>().enabled = false;
    //        for (int i = 0; i < particlesFinish.Length; i++)
    //        {
    //            particlesFinish[i].SetActive(true);
    //        }
    //        //cameraVirtual = GameObject.Find("CameraVirtual").GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = cameraAngle_1;
    //        //cameraVirtual = GameObject.Find("CameraVirtual").GetComponent<Cinemachine.CinemachineVirtualCamera>().LookAt = cameraAngle_2.transform;
    //    }
    //    if (other.gameObject.tag == "Banana")
    //    {
    //        Destroy(other.gameObject);
    //        anim.SetTrigger("SlideAnimation_1");
    //    }
    //}
}
