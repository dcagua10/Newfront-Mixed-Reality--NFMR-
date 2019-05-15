using UnityEngine;
using System;
using UnityEngine.UI;

public class Elevator : MonoBehaviour
{

    private GameObject elevator;
    private GameObject player;

    private string btnUp;
    private string btnDown;
    private string pTag;
    private int pisoActual = 0;

    private string open ="Open";
    private string close ="Close";

    private float alturaDesp = 1.9f;

    private float alturaEscenaP1 = 2.64f;
    private float alturaEscenaP2 = -1.39f;
    private float alturaEscenaP3 = -5.34f;

    private GameObject escena;



    public Action OnButtonUp;
    public Action OnButtonDown;

    public class State
    {
        public int piso;
        public Vector3 pos;
        public bool available;
    }

    State state;


    public void Start()
    {
        OnButtonUp += ButtonUp;
        OnButtonDown += ButtonDown;

        escena = GameObject.Find("MainEscena");

        state = new State();
        state.piso = 1;
        state.pos = new Vector3(0.0f,alturaEscenaP1,0.0f);
        state.available = true;

        pisoActual = state.piso;
    }

    public void ButtonUp()
    {
        Debug.Log("presionado");
        
        switch(state.piso)
        {
            case 1:
                state.piso = 2;
                state.pos = new Vector3(0, alturaEscenaP2, 0);
                break;
            case 2:
                state.piso = 3;
                state.pos = new Vector3(0, alturaEscenaP3, 0);
                break;
            case 3:
                state.piso = 3;
                state.pos = new Vector3(0, alturaEscenaP3, 0);
                break;
        }
    }

    public void ButtonDown()
    {
        switch (state.piso)
        {
            case 1:
                state.piso = 1;
                state.pos = new Vector3(0, alturaEscenaP1, 0);
                break;
            case 2:
                state.piso = 1;
                state.pos = new Vector3(0, alturaEscenaP1, 0);
                break;
            case 3:
                state.piso = 2;
                state.pos = new Vector3(0, alturaEscenaP2, 0);
                break;
        }
    }

    public void runElevator(Button btn)
    {
        btnUp = "BTNUP";
        btnDown = "BTNDOWN";
        pTag = btn.tag;
        if (state.available)
        {
            if (pTag.Equals(btnUp))
            {
                OnButtonUp();
            }
            else
            {
                OnButtonDown();
            }
        }
    }

    public void Update()
    {
        Debug.Log(pisoActual);
        Debug.Log(state.piso);

        if (pisoActual != state.piso)
        {
            elevator = GameObject.Find("PTK_Elevator");

            Vector3 newPos = new Vector3(escena.transform.localPosition.x, state.pos.y, escena.transform.localPosition.z);
            elevator.GetComponent<Animation>().Play(close);
            escena.transform.localPosition = Vector3.Lerp(escena.transform.localPosition, newPos, 0.1f);
            elevator.GetComponent<Animation>().Play(open);
            if (Vector3.Distance(escena.transform.localPosition ,newPos) < 0.1f)
            {
                escena.transform.localPosition = newPos;
                pisoActual = state.piso;
                state.available = true;
            }
            else
            {
                Debug.Log("no dispónible");
                state.available = false;
            }            
        }
    }


    /*public void runElevator(Button btn)
    {
        btnUp = "BTNUP";
        btnDown = "BTNDOWN";
        pTag = btn.tag;
        elevator = GameObject.Find("PTK_Elevator");


        //player = GameObject.Find("TestPlayer");
        escena = GameObject.Find("MainEscena");
        float psX = escena.transform.localPosition.x;
        float psZ = escena.transform.localPosition.z;
        bool termino = false;

        if (pisoActual == 1 && pTag.Equals(btnUp) && termino==false)
        {
            elevator.GetComponent<Animation>().Play(close);
            //Modificadores de Posicion
            escena.transform.localPosition = new Vector3(psX, alturaEscenaP2, psZ);
            pisoActual = 2;
            //Hasta aca
            elevator.GetComponent<Animation>().Play(open);
            termino = true;
        }
        else if (pisoActual == 1 && pTag.Equals(btnDown)&& termino == false)
        {
            //Nothing
            termino = true;
        }
        else if (pisoActual == 2 && pTag.Equals(btnUp) && termino == false)
        {
            elevator.GetComponent<Animation>().Play(close);
            //Modificadores de Posicion
            escena.transform.localPosition = new Vector3(psX, alturaEscenaP3, psZ);
            pisoActual = 3;
            //Hasta aca
            elevator.GetComponent<Animation>().Play(open);
            termino = true;
        }
        else if (pisoActual == 2 && pTag.Equals(btnDown) && termino == false)
        {
            elevator.GetComponent<Animation>().Play(close);
            //Modificadores de Posicion
            escena.transform.localPosition = new Vector3(psX, alturaEscenaP1, psZ);
            pisoActual = 1;
            //Hasta aca
            elevator.GetComponent<Animation>().Play(open);
            termino = true;
        }
        else if (pisoActual == 3 && pTag.Equals(btnUp) && termino == false)
        {
            //Nothing
            termino = true;
        }
        else if (pisoActual == 3 && pTag.Equals(btnDown) && termino == false)
        {
            elevator.GetComponent<Animation>().Play(close);
            //Modificadores de Posicion
            escena.transform.localPosition = new Vector3(psX, alturaEscenaP2, psZ);
            pisoActual = 2;
            //Hasta aca
            elevator.GetComponent<Animation>().Play(open);
            termino = true;
        }
        else
        {
            print("F");
        }




        /*
            if (pisoActual == 1)
            {
                if (pTag.Equals(btnUp))
                {
                    elevator.GetComponent<Animation>().Play(close);
                    //Modificadores de Posicion
                    escena.transform.localPosition = new Vector3(psX, alturaEscenaP2, psZ);
                    pisoActual = 2;
                    //Hasta aca
                    elevator.GetComponent<Animation>().Play(open);
                    return;
                }
                return;
            }


            else if (pisoActual == 2)
            {
                if (pTag.Equals(btnUp))
                {
                    elevator.GetComponent<Animation>().Play(close);
                    //Modificadores de Posicion
                    escena.transform.localPosition = new Vector3(psX, alturaEscenaP3, psZ);
                    pisoActual = 3;
                    //Hasta aca
                    elevator.GetComponent<Animation>().Play(open);
                    return;
                }


                else if (pTag.Equals(btnDown))
                {
                    elevator.GetComponent<Animation>().Play(close);
                    //Modificadores de Posicion
                    escena.transform.localPosition = new Vector3(psX, alturaEscenaP1, psZ);
                    pisoActual = 1;
                    //Hasta aca
                    elevator.GetComponent<Animation>().Play(open);
                    return;
                }
                return;
            }

            else if (pisoActual == 3)
            {
                if (pTag.Equals(btnUp))
                {
                    //Nothing
                    return;
                }
                else if (pTag.Equals(btnDown))
                {
                    pisoActual = 2;
                    elevator.GetComponent<Animation>().Play(close);
                    //Modificadores de Posicion
                    escena.transform.localPosition = new Vector3(psX, alturaEscenaP2, psZ);
                    //Hasta aca
                    elevator.GetComponent<Animation>().Play(open);
                    return;
                }
                return;
            }
            else
            {
                print("Error de piso");
            }

}*/

}
