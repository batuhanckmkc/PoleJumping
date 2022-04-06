using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public List<GameObject> characters;
    public int characterValue = 0;
    MovementPhone movementPhone;
    // Start is called before the first frame update
    void Start()
    {
        characters[characterValue].SetActive(true);
        movementPhone = GetComponentInChildren<MovementPhone>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CharacterWall")
        {
            Destroy(other.gameObject);
            characters[characterValue].SetActive(false);
            characterValue++;
            characters[characterValue].SetActive(true);
        }
    }
    private void Update()
    {
        transform.Translate(0, 0, 2f * Time.fixedDeltaTime);
    }
}
