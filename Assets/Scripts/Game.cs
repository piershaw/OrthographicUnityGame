//Game Class by pier shaw

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public GameObject targetPrfab;
    private GameObject target;
    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        target = Instantiate(targetPrfab) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {

        }

        Vector3 pos = new Vector3(mousePosition.x * 3, 0, mousePosition.z * 6);
        target.transform.position = pos;
        bool hitInfo = Physics.Raycast(target.transform.position, Camera.main.transform.position, 100.0f, 0);
        Debug.DrawRay(target.transform.position, Camera.main.transform.position, Color.red);

        if (hitInfo)
        {
            Debug.Log("yes");
        }
    }
}
