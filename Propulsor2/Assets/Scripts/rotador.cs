using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotador : MonoBehaviour
{
    [SerializeField]
    float rotacionZ = 10f;
    void Update()
    {
        transform.Rotate(0.0f, rotacionZ * Time.deltaTime, 0f);
    }
}
