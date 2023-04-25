using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RockInstruction : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pickUpText;

    // private bool pickUpAllowed;
    // Start is called before the first frame update
    void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(true);
            // pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            // pickUpAllowed = false;
        }
    }
}
