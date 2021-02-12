using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDamage : DamageSystem
{
    [SerializeField] private bool buttonPressed = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 1000))
            {
                //Debug.Log(hit.transform.gameObject);
                if(hit.transform.gameObject != null)
                {
                    ApplyDamage(_damage, hit.transform.gameObject);
                }
            }
        }
    }
}
