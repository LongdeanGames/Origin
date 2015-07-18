using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        // Use this for initialization
        private void Start()
        {
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
			Debug.Log ("x"+m_LastTargetPosition.x);
			Debug.Log ("y"+m_LastTargetPosition.y);
			Debug.Log ("z"+m_LastTargetPosition.z);
            // only update lookahead pos if accelerating or changed direction
			//The amount of movement.
            
			    Vector3 targetPosition = new Vector3 (target.position.x,target.position.y,target.position.z);
				
			if (targetPosition.y < -1.7f && targetPosition.x < -2f  ) {
				Debug.Log ("Too Far!");
				targetPosition = new Vector3 (m_LastTargetPosition.x,m_LastTargetPosition.y,target.position.z);
			} 
			else if (targetPosition.y > 0f && targetPosition.x > -2f ) {
				Debug.Log ("Too Far!");
				targetPosition = new Vector3 (m_LastTargetPosition.x,m_LastTargetPosition.y,target.position.z);
			} 
			else if (targetPosition.x < -2f) {
			Debug.Log ("Too Far!");
				targetPosition = new Vector3 (m_LastTargetPosition.x,target.position.y,target.position.z);
			} 
		 	//Edge of map
			else if (targetPosition.y < -1.7f) {
			Debug.Log ("Too Far!");
			targetPosition = new Vector3 (target.position.x,m_LastTargetPosition.y,target.position.z);
			} 
			else if (targetPosition.y > 0f) {
				Debug.Log ("Too Far!");
				targetPosition = new Vector3 (target.position.x,m_LastTargetPosition.y,target.position.z);
			} 


		    float xMoveDelta = (targetPosition - m_LastTargetPosition).x;
		    bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;

			if (updateLookAheadTarget) {
				m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
			} else {
				m_LookAheadPos = Vector3.MoveTowards (m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
			}
			
		    Vector3 aheadTargetPos = targetPosition + m_LookAheadPos + Vector3.forward * m_OffsetZ;
			Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

			transform.position = newPos;

			m_LastTargetPosition = targetPosition;
		
        }
    }
}
