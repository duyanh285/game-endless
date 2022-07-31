using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.Endless
{
    public class Player : MonoBehaviour ,ICompChk
    {
        public float jumpForce;
        public LayerMask blockLayer;
        public float blockCheckingRadius;
        public float blockCheckingOffset;
        public GameObject landVfx;


        private Rigidbody2D m_rb;
        private Animator m_anim;
        private int m_blockId;
        private bool m_isDead;
        private Vector2 m_centerPos;

        private void Awake()
        {
            m_rb = GetComponent<Rigidbody2D>();
            m_anim = GetComponent<Animator>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool IsComponentsNull()
        {
            return m_rb == null || m_anim == null;
        }

        private bool IsOnblock()
        {
            m_centerPos = new Vector3(transform.position.x,
                transform.position.y - blockCheckingOffset, transform.position.z);
            Collider2D col = Physics2D.OverlapCircle(m_centerPos, blockCheckingRadius, blockLayer);
            return col != null;
        }

        private void OnDrawGizmos()
        {
            m_centerPos = new Vector3(transform.position.x,
             transform.position.y - blockCheckingOffset, transform.position.z);
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(m_centerPos, blockCheckingRadius);
        }
    }
}
