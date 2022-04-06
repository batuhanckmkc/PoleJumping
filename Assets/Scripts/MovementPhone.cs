using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class MovementPhone : MonoBehaviour
{
    [SerializeField] GameObject tutorialScreen, swipeUpScreen, gameOverScreen;
    private float _move = 0.3f;
    private float _lastFrameFingerPostionX;
    private float _moveFactorX;
    public static bool isGameStart, grounded, isSlowed;
    [SerializeField] private float boundrey = 0;
    public List<GameObject> characters;
    public int characterValue = 0;


    private int scrollBarIndex = 1;
    public int currentBarValue;
    [SerializeField] HealthBar healthBar;
    [SerializeField] Scrollbar scrollbar;
    private Transform cameraVirtual;
    public Transform cameraAngle_1;
    public GameObject[] particlesFinish;
    public Transform tipOfPole;
    public Transform tipOfPoleG;
    public GameObject playerPole;
    public GameObject pole;
    [SerializeField] GameObject hipsPosition;
    [SerializeField] GameObject cameraAngle_2;
    [SerializeField] GameObject particlePole;
    public float horizontal, vertical;
    public static bool isFinished;
    Animator anim;
    Rigidbody rb;

    [HideInInspector] LineController lineController;
    //MovementPhone movementPhone;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(grounded);
        if (tutorialScreen.activeSelf == false)
        {
            isGameStart = true;
        }
        InputSystem();
        MoverSystem();
    }
    private void FixedUpdate()
    {
        if (isGameStart == true)
        {
            if (lineController.isJumped == true)
            {
                anim.SetTrigger("JumpAnimation");
            }
            if (isFinished == false && isGameStart == true && isSlowed == false)
            {
                transform.Translate(0, 0, 5f * Time.fixedDeltaTime);
                anim.SetBool("RunAnimation", true);
            }
            else if (isSlowed == true)
            {
                transform.Translate(0, 0, 1.5f * Time.fixedDeltaTime);
                anim.SetBool("RunAnimation", true);
            }
        }
    }


    private void InputSystem()
    {
        float minX = -0.5f;
        float maxX = 2.3f;
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPostionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPostionX;
            _lastFrameFingerPostionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            tutorialScreen.SetActive(false);
            swipeUpScreen.SetActive(false);
            _moveFactorX = 0;
        }

        float xBondrey = Mathf.Clamp(value: transform.position.x, minX, maxX);
        transform.position = new Vector3(xBondrey, transform.position.y, transform.position.z);
    }

    private void MoverSystem()
    {
        float swaerSystem = Time.fixedDeltaTime * _move * 0.8f * _moveFactorX;
        transform.Translate(swaerSystem, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sea")
        {
            Debug.Log("Game Over!");
            gameOverScreen.SetActive(true);
        }
        if (other.gameObject.tag == "blueWall")
        {
            Vector3 Pole = new Vector3(playerPole.transform.position.x, playerPole.transform.position.y, playerPole.transform.position.z);
            UpPole();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "redWall")
        {
            DownPole();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Wall")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "SCall")
        {
            isSlowed = true;
            //Time.timeScale = 0.5f;

            swipeUpScreen.SetActive(true);
        }
        if (other.gameObject.tag == "FinishLine")
        {
            isFinished = true;
            anim.SetBool("RunAnimation", false);
            GetComponent<MovementPhone>().enabled = false;
            for (int i = 0; i < particlesFinish.Length; i++)
            {
                particlesFinish[i].SetActive(true);
            }
            //cameraVirtual = GameObject.Find("CameraVirtual").GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = cameraAngle_1;
            //cameraVirtual = GameObject.Find("CameraVirtual").GetComponent<Cinemachine.CinemachineVirtualCamera>().LookAt = cameraAngle_2.transform;
        }
        //if (other.gameObject.tag == "Banana")
        //{
        //    Destroy(other.gameObject);
        //    anim.SetTrigger("SlideAnimation_1");
        //}

        if (other.CompareTag("Collectable"))
        {
            UpPole();
            Destroy(other.gameObject);
        }


        //if (other.gameObject.tag == "CharacterWall")
        //{
        //    characters[characterValue].SetActive(false);
        //    characters[characterValue].GetComponent<MovementPhone>().enabled = false;
        //    Destroy(other.gameObject);

        //    characterValue++;
        //    characters[characterValue].SetActive(true);
        //    cameraVirtual = GameObject.Find("CameraVirtual").GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = characters[characterValue].transform;
        //}

    }
    private void OnTriggerExit(Collider other)
    {
        isSlowed = false;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    private void UpPole()
    {
        playerPole.transform.localScale += new Vector3(10f, 10f, 100f);
        GameObject particle = Instantiate(particlePole, tipOfPoleG.position, Quaternion.identity);
        particle.transform.parent = tipOfPole.transform;
        particle.SetActive(true);
        lineController.blastPower++;
        UpgradeBar(scrollBarIndex);
    }

    private void DownPole()
    {
        playerPole.transform.localScale -= new Vector3(10f, 10f, 100f);
        GameObject particle = Instantiate(particlePole, tipOfPoleG.position, Quaternion.identity);
        particle.transform.parent = tipOfPole.transform;
        particle.SetActive(true);
        lineController.blastPower--;
        LowerBar(scrollBarIndex);
    }

    private void StartGame()
    {
        gameOverScreen.SetActive(false);
        particlePole.SetActive(false);
        tutorialScreen.SetActive(true);
        swipeUpScreen.SetActive(false);
        isGameStart = false;
        isSlowed = false;
        GetComponent<MovementPhone>();
        pole.gameObject.transform.position = tipOfPole.position;
        healthBar = GameObject.Find("Slider").GetComponent<HealthBar>();
        healthBar.SetMaxValue(10);
        lineController = GameObject.Find("ShotPoint").GetComponent<LineController>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isFinished = false;
        for (int i = 0; i < particlesFinish.Length; i++)
        {
            particlesFinish[i].SetActive(false);
        }
    }
    
    private void UpgradeBar(int increasingValue)
    {
        if(healthBar.slider.value < 10)
        {
            currentBarValue += increasingValue;
            healthBar.SetValue(currentBarValue);
        }

    }

    private void LowerBar(int decreasingValue)
    {
        if (healthBar.slider.value > 0)
        {
            currentBarValue -= decreasingValue;
            healthBar.SetValue(currentBarValue);
        }
    }
}


