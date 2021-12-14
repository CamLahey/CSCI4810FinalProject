using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour {
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask grappleable;
    public Transform gunTip, camera, player;
    public float maxDistance = 100f;
    private SpringJoint joint;
    // Start is called before the first frame update
    private void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update() {
        
        if (Input.GetMouseButtonDown(0)) {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0)) {
            StopGrapple();
        }
    }
    private void LateUpdate() {
        DrawRope();
    }
    private void StartGrapple() {
        RaycastHit hit;
        if(Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, grappleable)) {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;
            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;
            lr.positionCount = 2;
            FindObjectOfType<AudioManager>().Play("Gun Noise");
        }
    }
    private void StopGrapple() {
        lr.positionCount = 0;
        Destroy(joint);
    }
    
    void DrawRope() {
        if (!joint) {
            return;
        }
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, grapplePoint);
    }
    public bool isGrappling() {
        return joint != null;
    }
    public Vector3 GetGrapplePoint() {
        return grapplePoint;
    }
}
