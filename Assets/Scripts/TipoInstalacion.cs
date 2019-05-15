using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipoInstalacion : MonoBehaviour {

    private GameObject caja;
    private GameObject boxes;
    private GameObject plat;

    private float pX;
    private float pY;
    private float pZ;

    private float mX;
    private float mY;
    private float mZ;

    private float rX;
    private float rY;
    private float rZ;

    private string id1;
    private string id2;
    private string id3;

    private string pId; // Id del boton presionado
    private Vector3 vAddP; //Add al vector de posicion de la caja
  

    //Reset de Vectores Añadidos y Destruye la anterior plataforma
    private void destruirPlataforma ()
    {
        plat = GameObject.Find("Plat");
        Destroy(plat, 0.0f);
        vAddP = new Vector3(0.0f, 0.0f, 0.0f);
        boxes.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);    
    }
    public void ChangeTipoInst(Button btn)
    {
        // IDS Botones
        id1 = "TIB1";
        id2 = "TIB2";
        id3 = "TIB3";
        pId = btn.tag;

        caja = GameObject.Find("CajaCustom");
        boxes = GameObject.Find("Boxes");
        // Posicion Actual de la Caja
        pX = caja.transform.position.x;
        pY = caja.transform.position.y;
        pZ = caja.transform.position.z;
        Vector3 PA = new Vector3(pX, pY, pZ);

        //Posicion Inicial Caja
        Vector3 PI = new Vector3(4.048f, 0.781f, -20.574f);

        // Destruye la plataforma anterior
        destruirPlataforma();

        // Instanciacion de Objetos

        // (Evento con el Button)
        if (pId.Equals(id1)) // Tipo Inst 1
        {

            plat = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plat.name = "Plat";
            plat.transform.parent = caja.transform;

            plat.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            plat.transform.localScale = new Vector3(1.5f, 0.25f, 1.5f);

            vAddP = new Vector3(0.0f, 0.07f, 0.0f);
            Debug.Log("IT1 Detected");
        }
        else if (pId.Equals(id2)) // Tipo Inst 2 
        {
            plat = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plat.name = "Plat";
            plat.transform.parent = caja.transform;

            plat.transform.localPosition = new Vector3(0.0f, 0.5f, -0.2f);
            plat.transform.localScale = new Vector3(1.5f, 1.5f, 0.25f);

            vAddP = new Vector3(0.0f, 0.12f, 0.0f);
            Debug.Log("IT2 Detected");
        }
        else if (pId.Equals(id3)) // Tipo Inst 3
        {
            plat = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plat.name = "Plat";
            plat.transform.parent = caja.transform;

            plat.transform.localPosition = new Vector3(0.0f, 0.4f, 0.0f);
            plat.transform.localScale = new Vector3(0.75f, 0.8f, 0.750f);

            vAddP = new Vector3(0.0f, 0.8f, 0.0f);
            Debug.Log("IT3 Detected");
        }
        else
        {
            Debug.Log("El ID no corresponde a la instalacion seleccionada");
        }

        // Alterar la nueva posicion del objeto generado
        boxes.transform.localPosition += vAddP;
    }
}
