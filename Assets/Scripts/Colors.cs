using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform childTransform = transform.Find("Beta_Joints");
        if (childTransform != null)
        {
            Renderer childRenderer = childTransform.GetComponent<Renderer>();

            if (childRenderer != null)
            {
                childRenderer.material.color = Color.red;
            }
        }
        else
        {
            Debug.LogError("Aucun enfant nommé 'Beta_Joints' trouvé !");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
