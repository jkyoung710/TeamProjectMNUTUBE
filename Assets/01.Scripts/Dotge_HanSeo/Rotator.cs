using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HanSeoDotge
{
    public class Rotator : MonoBehaviour
    {

        public float rotationSpeed = 60f;


        void Update()
        {

            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        }
    }
}
