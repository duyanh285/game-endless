using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.Endless
{
    public class DestroyDelay : MonoBehaviour
    {
        public float timeToDestroy;
        public bool isAutoDestroy;

        private void Awake()
        {
            if (isAutoDestroy)
                DestroyObj();
        }

        public void DestroyObj()
        {
            Destroy(gameObject, timeToDestroy);
        }
    }
}

