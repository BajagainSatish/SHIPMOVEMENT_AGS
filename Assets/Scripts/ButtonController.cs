using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Transform ShipA;
    public Transform ShipB;
    public Transform ShipC;
    public Transform ShipD;
    public Transform ShipE;
    public Transform ShipF;
    public Transform ShipG;
    public Transform selectedShipToPlay;

    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;
    [SerializeField] private GameObject playButton;

    public bool playIsClicked;

    private void Start()
    {
        playIsClicked = false;
        ShipA.gameObject.SetActive(true);
        ShipB.gameObject.SetActive(false);
        ShipC.gameObject.SetActive(false);
        ShipD.gameObject.SetActive(false);
        ShipE.gameObject.SetActive(false);
        ShipF.gameObject.SetActive(false);
        ShipG.gameObject.SetActive(false);
    }
    public void OnClickLeft()
    {
        if (ShipB.gameObject.activeSelf == true)
        {
            ShipB.gameObject.SetActive(false);
            ShipA.gameObject.SetActive(true);
        }
        else if (ShipC.gameObject.activeSelf == true)
        {
            ShipC.gameObject.SetActive(false);
            ShipB.gameObject.SetActive(true);
        }
        else if (ShipD.gameObject.activeSelf == true)
        {
            ShipD.gameObject.SetActive(false);
            ShipC.gameObject.SetActive(true);
        }
        else if (ShipE.gameObject.activeSelf == true)
        {
            ShipE.gameObject.SetActive(false);
            ShipD.gameObject.SetActive(true);
        }
        else if (ShipF.gameObject.activeSelf == true)
        {
            ShipF.gameObject.SetActive(false);
            ShipE.gameObject.SetActive(true);
        }
        else if (ShipG.gameObject.activeSelf == true)
        {
            ShipG.gameObject.SetActive(false);
            ShipF.gameObject.SetActive(true);
        }
    }
    public void OnClickRight()
    {
        if (ShipA.gameObject.activeSelf == true)
        {
            ShipA.gameObject.SetActive(false);
            ShipB.gameObject.SetActive(true);
        }
        else if (ShipB.gameObject.activeSelf == true)
        {
            ShipB.gameObject.SetActive(false);
            ShipC.gameObject.SetActive(true);
        }
        else if (ShipC.gameObject.activeSelf == true)
        {
            ShipC.gameObject.SetActive(false);
            ShipD.gameObject.SetActive(true);
        }
        else if (ShipD.gameObject.activeSelf == true)
        {
            ShipD.gameObject.SetActive(false);
            ShipE.gameObject.SetActive(true);
        }
        else if (ShipE.gameObject.activeSelf == true)
        {
            ShipE.gameObject.SetActive(false);
            ShipF.gameObject.SetActive(true);
        }
        else if (ShipF.gameObject.activeSelf == true)
        {
            ShipF.gameObject.SetActive(false);
            ShipG.gameObject.SetActive(true);
        }
    }

    public void OnClickPlay()
    {
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        playButton.SetActive(false);
        selectedShipToPlay = ActiveShip();
        playIsClicked = true;
    }

    private Transform ActiveShip()
    {
        //Return the one ship that is currently active
        if (ShipA.gameObject.activeSelf)
        {
            return ShipA;
        }
        else if (ShipB.gameObject.activeSelf)
        {
            return ShipB;
        }
        else if (ShipC.gameObject.activeSelf)
        {
            return ShipC;
        }
        else if (ShipD.gameObject.activeSelf)
        {
            return ShipD;
        }
        else if (ShipE.gameObject.activeSelf)
        {
            return ShipE;
        }
        else if (ShipF.gameObject.activeSelf)
        {
            return ShipF;
        }
        else if (ShipG.gameObject.activeSelf)
        {
            return ShipG;
        }
        else
        {
            return null;
        }
    }
}
