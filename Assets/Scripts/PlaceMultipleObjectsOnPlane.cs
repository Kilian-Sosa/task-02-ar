using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceMultipleObjectsOnPlane : PressInputBase
{
    [SerializeField] GameObject keyPrefab, lockPrefab;

    GameObject spawnedObject;

    public bool isOnFirstConf = true;
    public bool isPlaying = false;

    ARRaycastManager aRRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    protected override void Awake()
    {
        base.Awake();
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("mode") == 1) GetComponent<GameManager>().enabled = false;
    }

    protected override void OnPress(Vector3 position)
    {
        if (aRRaycastManager.Raycast(position, hits, TrackableType.PlaneWithinPolygon) && !isPlaying)
        {
            var hitPose = hits[0].pose;

            spawnedObject = isOnFirstConf ?
                Instantiate(keyPrefab, hitPose.position, hitPose.rotation) :
                Instantiate(lockPrefab, hitPose.position, hitPose.rotation);

            Vector3 lookPos = Camera.main.transform.position - spawnedObject.transform.position;
            lookPos.y = 0;
            spawnedObject.transform.rotation = Quaternion.LookRotation(lookPos);
            GameManager.instance.gameObjects.Add(spawnedObject);
        }
    }
}
