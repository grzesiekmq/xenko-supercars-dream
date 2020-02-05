using Xenko.Core.Mathematics;
using Xenko.Engine;

namespace SupercarsDream
{
    public class Turn : SyncScript
    {
        // Start is called before the first frame update
        public override void Start()
        {
        }

        // Update is called once per frame
        public override void Update()
        {
            var dt = (float)Game.UpdateTime.Elapsed.TotalSeconds;
            float y = 45 * dt;

            Entity.Transform.RotationEulerXYZ = new Vector3(0, y, 0);
        }
    }
}