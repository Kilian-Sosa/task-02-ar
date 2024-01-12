using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceMultipleObjectsOnPlane : PressInputBase
{
    [SerializeField] GameObject keyPrefab, lockPrefab;

    GameObject spawnedObject;

    public bool isPlaying = false;

    ARRaycastManager aRRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    protected override void Awake()
    {
        base.Awake();
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }

    protected override void OnPress(Vector3 position)
    {
        if (PlayerPrefs.GetInt("mode") == 0) return;
        if (aRRaycastManager.Raycast(position, hits, TrackableType.PlaneWithinPolygon) && !isPlaying)
        {
            var hitPose = hits[0].pose;

            if (GameManager.instance.confStage == 0 && GameManager.instance.gameObjects.Count < PlayerPrefs.GetInt("keys"))
                spawnedObject = Instantiate(keyPrefab, hitPose.position, hitPose.rotation);
            else if (GameManager.instance.confStage == 1 && GameObject.Find("Lock") == null)
                spawnedObject = Instantiate(lockPrefab, hitPose.position, hitPose.rotation);

            Vector3 lookPos = Camera.main.transform.position - spawnedObject.transform.position;
            lookPos.y = 0;
            spawnedObject.transform.rotation = Quaternion.LookRotation(lookPos);
            GameManager.instance.gameObjects.Add(spawnedObject);
        }
    }
}
