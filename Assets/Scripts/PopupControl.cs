using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupControl : MonoBehaviour {


   


    // Update is called once per frame
    void Update()
    {
        //Control the rotation of the canvas
        transform.LookAt(Camera.main.transform.position);

        //Remove after 3 seconds
        Destroy(gameObject, 3f);
    }
}
