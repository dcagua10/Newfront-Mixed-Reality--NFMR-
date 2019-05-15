using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HTC.UnityPlugin.Utility;


public class CerraduraSC : MonoBehaviour {

    private GameObject caja;
    private GameObject puerta;
    private GameObject destruir;
    private GameObject cerradura;
    private GameObject instanciaC;

    private int tipo;

    private float pX;
    private float pY;
    private float pZ;

    private float rX;
    private float rY;
    private float rZ;

    private string id1;
    private string id2;
    private string id3;
    private string id4;

    private string pId;
    private Vector3 vAddP;
    private Vector3 vAddR;

    private void destruirCerradura ()
    {
        vAddP = new Vector3(0.0f, 0.0f, 0.0f);
        vAddR = new Vector3(0.0f, 0.0f, 0.0f);
        destruir = GameObject.Find("CopiaC");
        Destroy(destruir, 0.0f);
    }

    public void ChangeCerradura(Button btn)
    {
        // IDS Botones
        id1 = "TCB1";
        id2 = "TCB2";
        id3 = "TCB3";
        id4 = "TCB4";
        pId = btn.tag;

        caja = GameObject.Find("CajaP");
        destruir = GameObject.Find("CopiaC");

        // Posicion Actual de la Caja
        pX = caja.transform.position.x;
        pY = caja.transform.position.y;
        pZ = caja.transform.position.z;
        Vector3 PA = new Vector3(pX, pY, pZ);

        // Instanciacion de Objetos
        // (Evento con el Button)
        if (pId.Equals(id1)) // Cerradura Digital T1
        {
            cerradura = GameObject.Find("DT1");
            vAddP = new Vector3 (0.06f, 0.0f, 0.2f);
            vAddR = new Vector3(0.0f, -40.0f, 0.0f);
            tipo = 1;
            Debug.Log("DT1 Detected");
        }
        else if (pId.Equals(id2)) // Cerradura Digital T2
        {
            cerradura = GameObject.Find("DT2");
            vAddP = new Vector3(0.06f, 0.0f, 0.2f);
            vAddR = new Vector3(0.0f, -40.0f, 0.0f);
            tipo = 2;
            Debug.Log("DT2 Detected");
        }
        else if (pId.Equals(id3)) // Cerradura Mecanica T1
        {
            cerradura = GameObject.Find("MT1");
            cerradura.transform.localScale = new Vector3(0.5f, 0.65f, 0.5f);
            vAddP = new Vector3(-0.253f, 0.471f, 0.242f);
            vAddR = new Vector3(0.0f, 0.0f, 0.0f);
            tipo = 3;

            Debug.Log("MT1 Detected");
        }
        else if (pId.Equals(id4)) // Cerradura Mecanica T2
        {
            cerradura = GameObject.Find("MT2");
            vAddP = new Vector3(0.0f, 0.0f, 0.0f);
            vAddR = new Vector3(-90.0f, 0.0f, 0.0f);
            tipo = 4;
            Debug.Log("MT2 Detected");
        }
        else
        {
            tipo = -1;
            Debug.Log("El ID no corresponde a la cerradura seleccionada");
        }

        if (cerradura != null)
        {
            // Posicion de la cerradura Original
            float cX = cerradura.transform.position.x;
            float cY = cerradura.transform.position.y;
            float cZ = cerradura.transform.position.z;
            Vector3 cV = new Vector3(cX, cY, cZ);

            // Rotacion Actual de la Cerradura
            rX = cerradura.transform.rotation.x;
            rY = cerradura.transform.rotation.y;
            rZ = cerradura.transform.rotation.z;
            Vector3 RA = new Vector3(rX, rY, rZ);

            Vector3 VR = RA + vAddR;
            Quaternion rotation = Quaternion.Euler(VR);

            // Alterar la nueva posicion del objeto generado
            Vector3 VS = PA + vAddP;

            checkPuerta();
            crearObjeto(VS, rotation);
            

        }
        else
        {
            Debug.Log("Cerradura Nula");
        }

    }

    private void crearObjeto(Vector3 pos, Quaternion paramR)
    {
        destruirCerradura();
        instanciaC = Instantiate(cerradura, pos, paramR) as GameObject;
        instanciaC.name = "CopiaC";
        GameObject CC = GameObject.Find("CajaCustom");
        instanciaC.transform.parent = CC.transform;
    }

    private void checkPuerta()
    {
        GameObject puertaC2 = new GameObject(); 

        if (pId == id1 || pId == id2) // Cerradura Digital T1 & T2
        {
            puertaC2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            puertaC2.name = "puertaC2";
            GameObject boxes = GameObject.Find("Boxes");
            puertaC2.transform.parent = boxes.transform;
            puertaC2.transform.localPosition = new Vector3(-0.072f, 0.458f, 0.337f);
            Vector3 R = new Vector3(0.0f, -40.0f, 0.0f);
            Quaternion rotation = Quaternion.Euler(R);
            puertaC2.transform.localRotation = rotation;
            puertaC2.transform.localScale = new Vector3(0.4509973f, 0.7672177f, 0.037367f);      
        }
        else if (pId == id3 || pId == id4) // Cerradura Mecanica T1 & T2
        {
            GameObject pDestruir = GameObject.Find("puertaC2");
            Destroy(pDestruir, 0.0f);
        }
        else
        {
            Debug.Log("No hace nada con la puerta");
        }

    }
}
