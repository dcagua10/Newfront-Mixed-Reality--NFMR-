#pragma strict

private var pressedButton: boolean = false;
private var isElevatorUp: boolean = false;

var target: GameObject;
var tg: GameObject;

function OnMouseOver() {
    pressedButton = true;
}

function OnMouseExit() {
    pressedButton = false;
}

function OnMouseDown() {
    if (isElevatorUp == false) {
        target = GameObject.Find("PTK_Elevator");
        tg = GameObject.Find("MainEscena");
        target.GetComponent.<Animation>().Play("Close");
   
        tg.GetComponent.<Animation>().Play("SceneUp");

        target.GetComponent.<Animation>().Play("Open");
        isElevatorUp = true;
    }
    else {
        target = GameObject.Find("PTK_Elevator");
        tg = GameObject.Find("MainEscena");
        target.GetComponent.<Animation>().Play("Close");

        tg.GetComponent.<Animation>().Play("SceneDown");

        target.GetComponent.<Animation>().Play("Open");
        isElevatorUp = false;
    }
}

function OnGUI() {
    if (pressedButton == true) {
        GUI.Box(new Rect(300, 300, 200, 20), "Press to use Lift");
    }
}