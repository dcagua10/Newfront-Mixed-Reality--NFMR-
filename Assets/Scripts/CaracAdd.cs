using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaracAdd : MonoBehaviour {

    private GameObject caja;
    private GameObject cuerpo;
    private GameObject composicion;

    // Posicion de la caja
    private float pX;
    private float pY;
    private float pZ;

    // Propiedades de placa horizontal (Scale)
    private float psX;
    private float psY;
    private float psZ;

    // Propiedades de placa vertical (Scale)
    private float pvX;
    private float pvY;
    private float pvZ;

    // Tags para los botones de divisiones verticales
    private string idv1;
    private string idv2;
    private string idv3;
    private int cantPlacasVertical; // Cantidad de divisiones verticales actuales

    //Tags para los botones de divisiones horizontales
    private string idh1;
    private string idh2;
    private string idh3;
    private int cantPlacasHorizontal; // Cantidad de divisiones horizontales actuales

    private string pId; // ID del boton presionado

    //Metodo de destruccion de divisiones verticales

    //Metodo de destruccion de divisiones horizontales

    public void ChangeCaracAdd(Button btn)
    {
        // IDS Botones
        idv1 = "CVB1";
        idv2 = "CVB2";
        idv3 = "CVB3";

        idh1 = "CHB1";
        idh2 = "CHB2";
        idh3 = "CHB3";

        pId = btn.tag;

        caja = GameObject.Find("CajaCustom");
        cuerpo = GameObject.Find("Boxes");
        composicion = GameObject.Find("CajaP");

        // Posicion Actual de la Caja
        pX = caja.transform.position.x;
        pY = caja.transform.position.y;
        pZ = caja.transform.position.z;
        Vector3 PA = new Vector3(pX, pY, pZ);

        // Set Valores Scale - placaHorizontal
        psX = 30f;
        psY = 0.5f;  // Grosor de la lamina
        psZ = 30f; 
        Vector3 placaScale = new Vector3(psX, psY, psZ);

        // Set Valores Scale - placaVertical
        pvX = 1.0f;
        pvY = 52.4f;
        pvZ = 30.0f;
        Vector3 placaVScale = new Vector3(pvX, pvY, pvZ);


        // Comprueba las divisiones verticales y las genera

        if (pId.Equals(idv1))
        {
            cantPlacasVertical = 0;
            destruirPlacasVerticales();
        }
        else if (pId.Equals(idv2))
        {
            cantPlacasVertical = 1;
            destruirPlacasVerticales();
            crearPlacasVerticales(cantPlacasVertical, placaVScale);
        }
        else if (pId.Equals(idv3))
        {
            cantPlacasVertical = 2;
            destruirPlacasVerticales();
            crearPlacasVerticales(cantPlacasVertical, placaVScale);
        }
        else
        {
            cantPlacasVertical = -1;
            exitCode("Vertical",cantPlacasVertical);
        }


        // Comprueba las divisiones horizontales y las genera

        if (pId.Equals(idh1))
        {
            cantPlacasHorizontal = 0;
            destruirPlacasHorizontales();
        }
        else if (pId.Equals(idh2))
        {
            cantPlacasHorizontal = 1;
            destruirPlacasHorizontales();
            crearPlacasHorizontales(cantPlacasHorizontal, placaScale);
        }
        else if (pId.Equals(idh3))
        {
            cantPlacasHorizontal = 2;
            destruirPlacasHorizontales();
            crearPlacasHorizontales(cantPlacasHorizontal, placaScale);
        }
        else
        {
            cantPlacasHorizontal = -1;
            exitCode("Horizontal",cantPlacasHorizontal);
        }

        


    }

    private void exitCode(string tipo, int cant)
    {
        print("La cantidad de placas de tipo " + tipo + " son: " + cant);
    }

    private void crearPlacasHorizontales(int cant, Vector3 scale)
    {
        for (int i = 1; i <= cant; i++)
        {
            GameObject placa = GameObject.CreatePrimitive(PrimitiveType.Cube);
            placa.name = "PlacaH" + i;
            placa.transform.parent = composicion.transform;

            placa.transform.localScale = scale;
            placa.transform.localPosition = new Vector3(0.0f, 0.0f, 30.14f);
            if (cant == 2)
            {
                if (i == 1)
                {
                    placa.transform.localPosition = new Vector3(0.0f, 0.0f, 20.23f);
                }
                else if (i == 2)
                {
                    placa.transform.localPosition = new Vector3(0.0f, 0.0f, 40.46f);
                }
                else
                {
                    print("Se murio aca");
                }
            }
        }
    }

    private void crearPlacasVerticales(int cant, Vector3 scale)
    {
        for (int i = 1; i <= cant; i++)
        {
            GameObject placa = GameObject.CreatePrimitive(PrimitiveType.Cube);
            placa.name = "PlacaV" + i;
            placa.transform.parent = composicion.transform;

            placa.transform.localScale = scale;
            placa.transform.localPosition = new Vector3(0.0f, 0.2f, 30.79f);

            if (cant == 2)
            {
                if (i == 1)
                {
                    placa.transform.localPosition = new Vector3(4.66f, 0.2f, 30.79f);
                }
                else if (i == 2)
                {
                    placa.transform.localPosition = new Vector3(-4.66f, 0.2f, 30.79f);
                }
                else
                {
                    print("Se murio aca");
                }
            }
        }
    }

    private void destruirPlacasVerticales()
    {
        GameObject d1 = GameObject.Find("PlacaV1");
        GameObject d2 = GameObject.Find("PlacaV2");
        Destroy(d1, 0.0f);
        Destroy(d2, 0.0f);
    }

    private void destruirPlacasHorizontales()
    {
        GameObject d1 = GameObject.Find("PlacaH1");
        GameObject d2 = GameObject.Find("PlacaH2");
        Destroy(d1, 0.0f);
        Destroy(d2, 0.0f);

    }

}
