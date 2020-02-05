using System;
using Xenko.Core.Mathematics;
using Xenko.Engine;

namespace SupercarsDream
{
    public class FollowCamera : SyncScript
    {
        public float targetDistance = 50f;
        public float targetHeight = 500f;

        private Entity followThis;

        public Vector3 lastLookat;

        // Start is called before the first frame update
        public override void Start()
        {
            followThis = Entity.GetParent();

            lastLookat = followThis.Transform.WorldMatrix.TranslationVector;
        }

        // Update is called once per frame
        public override void Update()
        {
            var deltaV = Entity.Transform.WorldMatrix.TranslationVector - followThis.Transform.WorldMatrix.TranslationVector;
            var targetPos = Entity.Transform.WorldMatrix.TranslationVector;

            var dt = (float)Game.UpdateTime.Elapsed.TotalSeconds;

            deltaV.Y = 0;

            //   Debug.Log("delta v" + deltaV);
            DebugText.Print("target pos" + targetPos, new Int2(100, 200));
            DebugText.Print(deltaV.Length().ToString(), new Int2(100, 300));

            if (deltaV.Length() > targetDistance)
            {
                deltaV = Vector3.Normalize(deltaV) * targetDistance;

                deltaV.Y = targetHeight;

                targetPos = followThis.Transform.WorldMatrix.TranslationVector + deltaV;
            }
            else
            {
                targetPos.Y = followThis.Transform.WorldMatrix.TranslationVector.Y + targetHeight;
            }

            Entity.Transform.WorldMatrix.TranslationVector = Vector3.Lerp(Entity.Transform.WorldMatrix.TranslationVector, targetPos, dt);

            // TODO: fix lastlookat
            lastLookat = Vector3.Lerp(lastLookat, followThis.Transform.WorldMatrix.TranslationVector, dt);
            Entity.LookAt(followThis.Transform.Position);
        }
    }

    public static class EntityExtensions
    {
        public static void LookAt(this Entity e, Vector3 target)
        {
            float altitude = 0;
            float azimuth = GetLookAtAngles(e.Transform.Position, target, out altitude);
            var result = Quaternion.RotationYawPitchRoll(azimuth, -altitude, 0);
            e.Transform.Rotation = result;
        }

        private static float GetLookAtAngles(Vector3 source, Vector3 destination, out float altitude)
        {
            var x = source.X - destination.X;
            var y = source.Y - destination.Y;
            var z = source.Z - destination.Z;

            altitude = (float)Math.Atan2(y, Math.Sqrt(x * x + z * z));
            var azimuth = (float)Math.Atan2(x, z);
            return azimuth;
        }
    }
}