using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    public class IKFootSolver : MonoBehaviour
    {
        // [SerializeField] private LayerMask terrainLayer = default;
        // [SerializeField] private Transform body = default;
        // [SerializeField] private float speed = 0.1f;
        // [SerializeField] private float stepDistance = 0.5f;
        // [SerializeField] private float stepLength = 4;
        // [SerializeField] private float stepHeight = 1;
        // [SerializeField] private Vector3 footOffset = default;
        // [SerializeField] private bool isGroupA;
        // private FootSync footSync;
        // private float footSpacing;
        // private Vector3 oldPosition, currentPosition, newPosition;
        // private Vector3 oldNormal, currentNormal, newNormal;
        // private float lerp;

        // private void Start()
        // {
        //     footSpacing = transform.localPosition.x;
        //     currentPosition = newPosition = oldPosition = transform.position;
        //     currentNormal = newNormal = oldNormal = transform.up;
        //     lerp = 1;

        //     footSync = transform.parent.transform.parent.gameObject.GetComponent<FootSync>();
        // }

        // // Update is called once per frame

        // void Update()
        // {
        //     Debug.Log($"{lerp} - {isGroupA} == {footSync.CanMoveA()}");

        //     transform.position = currentPosition;
        //     transform.up = currentNormal;

        //     Ray ray = new Ray(body.position + (body.right * footSpacing), Vector3.down);

        //     if (Physics.Raycast(ray, out RaycastHit info, 10, terrainLayer.value))
        //     {
        //         if (Vector3.Distance(newPosition, info.point) > stepDistance && (isGroupA == footSync.CanMoveA()) && lerp >= 1)
        //         {
        //             lerp = 0;
        //             int direction = body.InverseTransformPoint(info.point).z > body.InverseTransformPoint(newPosition).z ? 1 : -1;
        //             newPosition = info.point + (body.forward * stepLength * direction) + footOffset;
        //             newNormal = info.normal;
        //         }
        //     }

        //     if (lerp < 1)
        //     {
        //         Vector3 tempPosition = Vector3.Lerp(oldPosition, newPosition, lerp);
        //         tempPosition.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;

        //         currentPosition = tempPosition;
        //         currentNormal = Vector3.Lerp(oldNormal, newNormal, lerp);
        //         lerp += Time.deltaTime * speed;
        //     }
        //     else
        //     {
        //         oldPosition = newPosition;
        //         oldNormal = newNormal;
        //     }
        // }

        // private void OnDrawGizmos()
        // {

        //     Gizmos.color = Color.red;
        //     Gizmos.DrawSphere(newPosition, 0.5f);
        // }



        // public bool IsMoving()
        // {
        //     return lerp < 1;
        // }



    }
}
