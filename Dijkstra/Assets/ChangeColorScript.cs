using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorScript : MonoBehaviour
{
    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.name == "Freg")
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.magenta;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.name == "Freg")
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
        }
    }
}
