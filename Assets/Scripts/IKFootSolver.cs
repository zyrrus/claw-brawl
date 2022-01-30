using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    public class IKFootSolver : MonoBehaviour
    {
        [SerializeField] private LayerMask terrainLayer;
        [SerializeField] private Transform body;
        // [SerializeField] IKFootSolver otherFoot;
        private Vector3 newPosition;
        private Vector3 oldPosition;
        private Vector3 currentPosition;
        // private Vector3 newNormal;
        // private Vector3 oldNormal;
        // private Vector3 currentNormal;
        [SerializeField] private Vector3 footOffset;
        private float footSpacing;
        [SerializeField] private float stepDistance;
        [SerializeField] private float stepHeight;
        [SerializeField] private float speed;
        private float lerp;


        private void Start()
        {
            footSpacing = transform.localPosition.x;
            currentPosition = newPosition = oldPosition = transform.position;
            // currentNormal = newNormal = oldNormal = transform.up;
            lerp = 1;
        }

        private void Update()
        {
            transform.position = currentPosition;

            Ray ray = new Ray(body.position + (body.right * footSpacing), Vector3.down);
            if (Physics.Raycast(ray, out RaycastHit info, 10, terrainLayer.value))
                if (Vector3.Distance(newPosition, info.point) > stepDistance)
                {
                    newPosition = info.point; lerp = 0;
                }
            if (lerp < 1)
            {
                Vector3 footPosition = Vector3.Lerp(oldPosition, newPosition, lerp);
                footPosition.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;

                currentPosition = footPosition;
                lerp += Time.deltaTime * speed;
            }
            else
            {
                oldPosition = newPosition;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(newPosition, 0.5f);
        }
    }
}
