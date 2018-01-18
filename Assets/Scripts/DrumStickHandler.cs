using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.WSA.Input;

public class DrumStickHandler : MonoBehaviour {

    public bool isRightHand = false;

    private Vector3 controllerPos, controllerForward;
    private Quaternion controllerRot;

    // Use this for initialization
    void Start () {
        //InteractionManager.SourceDetected += InteractionManager_SourceDetected;
        InteractionManager.InteractionSourceUpdated += InteractionManager_InteractionSourceUpdated;
        //InteractionManager.SourceLost += InteractionManager_SourceLost;
        //InteractionManager.SourcePressed += InteractionManager_SourcePressed;
        //InteractionManager.SourceReleased += InteractionManager_SourceReleased;
    }

    private void InteractionManager_InteractionSourceUpdated(InteractionSourceUpdatedEventArgs obj)
    {
        var reading = InteractionManager.GetCurrentReading();
        foreach (var sourceState in reading)
        {
            var sourcePose = sourceState.sourcePose;
            Vector3 position = Vector3.zero;
            Quaternion rotation = Quaternion.identity;
            bool hasRotation, hasPosition;

            if (isRightHand && sourceState.source.handedness == InteractionSourceHandedness.Right)
            {
                hasRotation = sourcePose.TryGetRotation(out rotation, InteractionSourceNode.Grip);
                hasPosition = sourcePose.TryGetPosition(out position, InteractionSourceNode.Grip);
            }
            else if (!isRightHand && sourceState.source.handedness == InteractionSourceHandedness.Left)
            {
                hasRotation = sourcePose.TryGetRotation(out rotation, InteractionSourceNode.Grip);
                hasPosition = sourcePose.TryGetPosition(out position, InteractionSourceNode.Grip);
            }
            else
            {
                hasRotation = false;
                hasPosition = false;
            }

            if (hasRotation || hasPosition)
            {
                transform.rotation = rotation;
                transform.position = position;
            }
        }
    }

}
