
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiftV2 : MonoBehaviour {

    private bool pressedButton;
    private bool isElevatorUp;

    private GameObject target;
    private GameObject escena;

    private string id1;
    private string pId;

    public void RunElevator(Button btn)
    {
        id1 = "EB1";
        pId = btn.tag;
        target = GameObject.Find("PTK_Elevator");
        escena = GameObject.Find("MainEscena"); 

        if (id1.Equals(pId))
        {
            if (isElevatorUp == false)
            {
                target.GetComponent<Animation>().Play("Close");
                escena.GetComponent<Animation>().Play("SceneUp");
                target.GetComponent<Animation>().Play("Open");
                isElevatorUp = true;
            }
            else
            {
                target.GetComponent<Animation>().Play("Close");
                escena.GetComponent<Animation>().Play("SceneDown");
                target.GetComponent<Animation>().Play("Open");
                isElevatorUp = false;
            }
        }

        
    }   

}
