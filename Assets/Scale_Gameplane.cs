using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale_Gameplane : MonoBehaviour
{

    public GameObject topLeft;
    public GameObject bottomRight;
    public GameObject plane;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (topLeft.activeSelf && bottomRight.activeSelf)
        {
            plane.SetActive(true);



            Vector3 scale = topLeft.transform.position - bottomRight.transform.position;
            scale.x = scale.x / 10;
            scale.y = 0.5f;
            scale.z = scale.z / 10;

            Vector3 center = (topLeft.transform.position + bottomRight.transform.position) * 0.5f;
            Vector3 halfExtents = scale;// * 0.5f; //Halfextents are units in each direction instead of total length

            plane.transform.position = center;
            plane.transform.localScale = halfExtents;

        }
        else
        {
            plane.SetActive(false);

        }
    }

}
