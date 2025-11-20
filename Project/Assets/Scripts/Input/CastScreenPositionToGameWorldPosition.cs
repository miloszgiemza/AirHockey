using UnityEngine;

namespace GameHardwareAndInputClasses
{
    public static class CastScreenPositionToGameWorldPosition
    {
        public static Vector3 Cast(Vector2 screenPosition, Camera camera)
        {
            float cameraDistanceFromRaycastHitGroundPoint = 14.5f;


            int layerMask = LayerMask.GetMask(GameObjectsTags.GroundPlaneForCameraCalculations.ToString());

            Ray ray = new Ray(camera.transform.position, new Vector3(0, -1, 0));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, layerMask))
            {
                cameraDistanceFromRaycastHitGroundPoint = hit.distance;
            }

            Vector3 worldPoint = camera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, cameraDistanceFromRaycastHitGroundPoint));

            return worldPoint;
        }
    }
}
