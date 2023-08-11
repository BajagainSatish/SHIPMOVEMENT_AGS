using UnityEngine;
using System.Collections.Generic;
public class CameraFollowShip : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping = 0.5f;
    [SerializeField] private ButtonController buttonControllerScript;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Dictionary<int, int> dictionaryCameraX = new Dictionary<int, int> {
        {0,25 },
        {1,30 },
        {2,27 },
        {3,18 },
        {4,8 },
        {5,21 },
        {6,10 }
    };
    [SerializeField] private Dictionary<int, int> dictionaryCameraY = new Dictionary<int, int> {
        {0,15 },
        {1,15 },
        {2,18 },
        {3,10 },
        {4,4 },
        {5,12 },
        {6,5 }
    };
    [SerializeField] private Dictionary<int, int> dictionaryCameraZ = new Dictionary<int, int> {
        {0,40 },
        {1,40 },
        {2,38 },
        {3,27 },
        {4,13 },
        {5,36 },
        {6,14 }
    };

    private void Start()
    {
        if (!buttonControllerScript.playIsClicked)
        {
            transform.eulerAngles = new Vector3(0,-135,0);
        }
    }
    private void FixedUpdate()
    {
        if (!buttonControllerScript.playIsClicked)
        {
            for (int i = 0; i < ButtonController.totalBoatCount; i++)
            {
                if (buttonControllerScript.Ships[i].gameObject.activeSelf)
                {
                transform.position = new Vector3(dictionaryCameraX[i], dictionaryCameraY[i], dictionaryCameraZ[i]);
                }
            }
        }
        if (buttonControllerScript.playIsClicked)
        {
        target = buttonControllerScript.selectedShipToPlay;
        transform.eulerAngles = new Vector3(30,30,0);
        Vector3 movePosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position,movePosition,ref velocity, damping);
        
            //values are experimental and can be re-adjusted
            if (target.name == "ShipA" || target.name == "ShipB" || target.name == "ShipC")
            {
                offset = new Vector3(-43f, 90f, -106f);
            }
            else if (target.name == "ShipD" || target.name == "ShipF")
            {
                offset = new Vector3(-43f, 71f, -76f);
            }
            else if (target.name == "ShipE")
            {
                offset = new Vector3(-18f, 40f, -56f);
            }
            else if (target.name == "ShipG")
            {
                offset = new Vector3(-22f, 43f, -44f);
            }
        }
    }
}
