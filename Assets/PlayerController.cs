/*********************************************************************************/
/* This version follows https://www.youtube.com/watch?v=-V1O5FGQVY8 
but without implementation of the case when the player is holding the rock. */
/*********************************************************************************/

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;


// public class PlayerController : MonoBehaviour
// {
//     public Transform holdRock;
//     public LayerMask pickUpMask;
//     public Vector3 Direction {get; set;}
//     public KeyCode pickupKey = KeyCode.E;
//     private GameObject itemHolding;

//     void Update()
//     {
//         if (Input.GetKeyDown(pickupKey))
//         {
//             if(itemHolding)
//             {

//             }
//             else
//             {
//                 Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
//                 if (pickUpItem)
//                 {
//                     itemHolding = pickUpItem.gameObject;
//                     itemHolding.transform.position = holdRock.position;
//                     itemHolding.transform.parent = transform;
//                     if (itemHolding.GetComponent<Rigidbody2D>())
//                     {
//                         itemHolding.GetComponent<Rigidbody2D>().simulated = false;
//                     }
//                 }
//             }
//         }
//     }
// }

/*********************************************************************************/
/* This version aims to let the player press E to pick up and hold space to throw. 
The throwing distance depends on the holding time. But it fails to fully work. 
Currently the player can only throw the rock to the postion where the player stands. */
/*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform holdRock;
    public LayerMask pickUpMask;
    public Vector3 Direction {get; set;}
    public KeyCode pickupKey = KeyCode.E;
    public KeyCode throwKey = KeyCode.Space;
    public float throwForce = 10f;
    public float maxThrowDuration = 1f;
    private float throwDuration;
    private GameObject itemHolding;
    private Rigidbody2D itemRigidbody;

    void Update()
    {
        if (Input.GetKeyDown(pickupKey))
        {
            if (itemHolding)
            {
                ThrowItem();
            }
            else
            {
                PickUpItem();
            }
        }

        if (Input.GetKey(throwKey) && itemHolding)
        {
            throwDuration += Time.deltaTime;
            throwDuration = Mathf.Clamp(throwDuration, 0f, maxThrowDuration);
        }

        if (Input.GetKeyUp(throwKey) && itemHolding)
        {
            ThrowItem();
        }
    }

    void PickUpItem()
    {
        Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
        if (pickUpItem)
        {
            itemHolding = pickUpItem.gameObject;
            itemHolding.transform.position = holdRock.position;
            itemHolding.transform.parent = transform;
            itemRigidbody = itemHolding.GetComponent<Rigidbody2D>();
            if (itemRigidbody)
            {
                itemRigidbody.simulated = false;
            }
        }
    }

    void ThrowItem()
    {
        itemHolding.transform.parent = null;
        itemRigidbody.simulated = true;
        itemRigidbody.velocity = Direction * throwForce * (throwDuration / maxThrowDuration);
        itemHolding = null;
        throwDuration = 0f;
    }
}
