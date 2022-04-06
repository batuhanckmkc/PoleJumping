using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleScript : MonoBehaviour
{
    MovementPhone movementPhone;
    LineController lineController;

    private void Start()
    {
        //movementPhone = movementPhone.characters[movementPhone.characterValue].GetComponent<MovementPhone>();
        movementPhone = GameObject.Find("Player").GetComponent<MovementPhone>();
        lineController = GameObject.Find("ShotPoint").GetComponent<LineController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            lineController.blastPower++;
            movementPhone.playerPole.transform.localScale += new Vector3(10f, 10f, 100f);
            movementPhone.pole.gameObject.transform.position = movementPhone.tipOfPole.position;
            Destroy(other.gameObject);
        }
    }
}
