using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha : MonoBehaviour
{
    public bool IsAlpha;
    public float Height = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        if (IsAlpha)
        {
            transform.localScale = new Vector3(Height, Height, Height);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
