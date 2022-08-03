using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.Endless
{
    public class Player : MonoBehaviour, ICompChk
    {
        public float jumpForce;
        public LayerMask blockLayer;
        public float blockCheckingRadius;
        public float blockCheckingOffset;
        public GameObject landVfxPb;


        private Rigidbody2D m_rb;
        private Animator m_anim;
        private Vector2 m_centerPos;
        private bool m_isOnBlock;
        private int m_blockId;
        private bool m_isDead;


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
            if (m_isDead || IsComponentsNull()) return;
            transform.position = new Vector3(0, transform.position.y, 0f);

            Jump();

            if (m_rb.velocity.y < 0)
            {
                if (m_isOnBlock)
                {
                    m_anim.SetBool(ChacAnim.Jump.ToString(), false);
                    m_anim.SetBool(ChacAnim.Land.ToString(), true);
                }
                else
                {
                    m_anim.SetBool(ChacAnim.Jump.ToString(), false);
                }
            }
        }

        private void FixedUpdate()
        {
            IsOnBlock();
        }

        public bool IsComponentsNull()
        {
            bool checking = m_rb == null || m_anim == null;
            if (checking)
                Debug.LogError("Some component is null . please check!!!");

            return checking;
        }

        private void IsOnBlock()
        {
            m_centerPos = new Vector3(transform.position.x,
                transform.position.y - blockCheckingOffset, transform.position.z);
            Collider2D col = Physics2D.OverlapCircle(m_centerPos, blockCheckingRadius, blockLayer);
            // return col != null;
            m_isOnBlock = col != null ? true : false;

        }

        private void OnDrawGizmos()
        {
            m_centerPos = new Vector3(transform.position.x,
             transform.position.y - blockCheckingOffset, transform.position.z);
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(m_centerPos, blockCheckingRadius);
        }

        public void Jump()
        {
            if (!GamepadController.Ins.CanJump || !m_isOnBlock || IsComponentsNull()) return;

            GamepadController.Ins.CanJump = false;

            m_rb.velocity = Vector2.up * jumpForce;

            m_anim.SetBool(ChacAnim.Jump.ToString(), true);

            m_anim.SetBool(ChacAnim.Land.ToString(), false);

        }

        public void BackToIdle()
        {
            m_anim.SetBool(ChacAnim.Land.ToString(), false);
            m_anim.SetTrigger(ChacAnim.Idle.ToString());
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(GameTag.Block.ToString()))
            {
                Block block = collision.gameObject.GetComponent<Block>();
                if (block && block.Id != m_blockId)//ADD SCORE DUY NHAT 1 LAN
                {
                    m_blockId = block.Id;
                    GameManager.Ins.AddScore(block.CurScore);
                    block.PlayerLand();
                }
                if (collision != null && collision.contactCount > 0 && landVfxPb)
                {
                    Vector3 spawnPos = new Vector3(transform.position.x,
                        collision.contacts[0].point.y, 0f);

                    Instantiate(landVfxPb, spawnPos, Quaternion.identity);
                    
                }
                    Debug.Log("da va cham");
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(GameTag.DeadZone.ToString()) && !m_isDead)
            {
                if (IsComponentsNull()) return;
                m_isDead = true;
                m_anim.SetTrigger(ChacAnim.Dead.ToString());
                gameObject.layer = LayerMask.NameToLayer(GamePlayer.Dead.ToString());
                Debug.Log("Da va cham vao vung chet");
                GameManager.Ins.Gameover();

            }
        }
    }
}
