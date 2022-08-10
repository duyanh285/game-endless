using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.Endless
{
    public class UnFollowCam : MonoBehaviour
    {
        private Vector3 m_startingPos;//rao chan voi nen ko di chuyen theo 

        private void Awake()
        {
            m_startingPos = transform.position;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = m_startingPos;
        }
    }
}
