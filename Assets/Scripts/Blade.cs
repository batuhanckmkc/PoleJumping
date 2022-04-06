using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float rotateValue;
    private GameObject pole;
    // Start is called before the first frame update
    void Start()
    {
        pole = GameObject.FindGameObjectWithTag("Pole");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * rotateValue * Time.fixedDeltaTime);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Pole")
    //    {
    //        Debug.Log("Pole bulunudu!");
    //        pole.transform.localScale -= new Vector3(5f, 5f, 50f);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pole")
        {
            Debug.Log("Pole bulunudu!");
            pole.transform.localScale -= new Vector3(5f, 5f, 50f);
        }
    }
}
