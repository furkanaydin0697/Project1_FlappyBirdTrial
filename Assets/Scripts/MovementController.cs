using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool IsTrigger;
    public GameObject Columns;
    
    // Start is called before the first frame update
    void Start()
    {
        IsTrigger = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (IsTrigger)
        {
            Invoke("MoveForward", 3f);
            IsTrigger = false;
        }
    }

    public void MoveForward()
    {
        transform.position = transform.position + new Vector3(22.8f, 0, 0);
        //-0.55 1.85 arasinda
        float yPos = Random.Range(-0.30f, 2.35f);
        Columns.transform.localPosition = new Vector3(0, yPos, 0);
    }
}
