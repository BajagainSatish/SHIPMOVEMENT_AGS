using UnityEngine;

public class CameraFollowShip : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping = 0.5f;
    [SerializeField] private ButtonController buttonControllerScript;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        if (!buttonControllerScript.playIsClicked)
        {
            transform.eulerAngles = new Vector3(20,-135,0);
        }
    }
    private void FixedUpdate()
    {
        if (!buttonControllerScript.playIsClicked)
        {
            if (buttonControllerScript.ShipA.gameObject.activeSelf)
            {
                transform.position = new Vector3(28, 25, 36);
            }
            if (buttonControllerScript.ShipB.gameObject.activeSelf)
            {
                transform.position = new Vector3(34, 24, 40);
            }
            if (buttonControllerScript.ShipC.gameObject.activeSelf)
            {
                transform.position = new Vector3(29, 26, 35);
            }
            if (buttonControllerScript.ShipD.gameObject.activeSelf)
            {
                transform.position = new Vector3(19, 14, 22);
            }
            if (buttonControllerScript.ShipE.gameObject.activeSelf)
            {
                transform.position = new Vector3(8, 9, 11);
            }
            if (buttonControllerScript.ShipF.gameObject.activeSelf)
            {
                transform.position = new Vector3(18, 13, 26);
            }
            if (buttonControllerScript.ShipG.gameObject.activeSelf)
            {
                transform.position = new Vector3(8, 7, 11);
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
