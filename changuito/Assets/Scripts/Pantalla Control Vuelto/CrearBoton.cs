using UnityEngine;
using System.Collections;

public class CrearBoton : MonoBehaviour
{
    private int posY = 210;

    private int buttonWidth  = 80;
    private int buttonHeight = 80;
    private int msjWidth     = 300;
    private int msjHeight    = 40;

    private int montoPagado    = 50;
    private int montoOriginal  = 20;
    private int vueltoCorrecto = 30;
    private int vuelto1;
    private int vuelto2;
    private int vuelto3;

    private string msjExito;
    private string msjFalla;
    //public GUIText Mensaje;
    bool pressed1 = false;
    bool pressed2 = false;
    bool pressed3 = false;
    bool pressed4 = false;

    // Use this for initialization
    void Start()
    {
        msjExito = "¡VUELTO CORRECTO!";

        msjFalla = "Volvamos a intentar: \n A " + montoPagado.ToString() +
                   " hay que restarle " + montoOriginal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnGUI()
    {
        // Al presionar cada botón se muestra por pantalla un mensaje, sobre si fue correcta la elección o no
        // dcamardella.-

        vuelto1 = vueltoCorrecto - 10;
        vuelto2 = vueltoCorrecto + 15;
        vuelto3 = vueltoCorrecto + 30;

        //Botón 1: incorrecto
        if (GUI.Button(new Rect(100, posY, buttonWidth, buttonHeight), vuelto1.ToString()))
        {
            pressed1 = true;
            pressed2 = pressed3 = pressed4 = false;
        }

        if (pressed1)
        {
            GUI.Box(new Rect(230, 150, msjWidth, msjHeight), msjFalla);
        }
            
        
        //Botón 2: el correcto
        if (GUI.Button(new Rect(250, posY, buttonWidth, buttonHeight), vueltoCorrecto.ToString()))
        {
            pressed2 = true;
            pressed1 = pressed3 = pressed4 = false;
        }

        if (pressed2)
        {
            GUI.Box(new Rect(230, 150, msjWidth, msjHeight), msjExito);
        }


        //Botón 3: incorrecto
        if (GUI.Button(new Rect(400, posY, buttonWidth, buttonHeight), vuelto2.ToString()))
        {
            pressed3 = true;
            pressed1 = pressed2 = pressed4 = false;
        }

        if (pressed3)
        {
            GUI.Box(new Rect(230, 150, msjWidth, msjHeight), msjFalla);
        }


        //Botón 4: incorrecto
        if (GUI.Button(new Rect(550, posY, buttonWidth, buttonHeight), vuelto3.ToString()))
        {
            pressed4 = true;
            pressed1 = pressed2 = pressed3 = false;
        }

        if (pressed4)
        {
            GUI.Box(new Rect(230, 150, msjWidth, msjHeight), msjFalla);
        }

        }
    }

