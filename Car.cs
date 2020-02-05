using System;
using Xenko.Core.Mathematics;
using Xenko.Engine;
using Xenko.Physics;

namespace SupercarsDream
{
    public class Car : SyncScript
    {
        private RigidbodyComponent rb;

        public float horizontalInput;
        public float verticalInput;

        public float steerAngle;

        public float steerInput;

        public float turnSpeed = 10f;

        public float maxSteerAngle = 30f;
        public float engineForce = 20;

        public const int topSpeed = 300;

        private double speed = 0.0;

        public void GetInput()
        {
            horizontalInput = Input.GetVirtualButton(0, "Horizontal");
            verticalInput = Input.GetVirtualButton(0, "Vertical");
        }

        private void Steer()
        {
            var dt = (float)Game.UpdateTime.Elapsed.TotalSeconds;
            steerAngle = maxSteerAngle * horizontalInput * dt;

            rb.ApplyTorque(Entity.Transform.WorldMatrix.Up * turnSpeed * steerAngle);

            //  FR.steerAngle = -steerAngle;
            //  FL.steerAngle = -steerAngle;
        }

        private void Accelerate()
        {
            speed = rb.LinearVelocity.X * 3.6;
            if (speed < topSpeed)
            {
                rb.ApplyForce(Entity.Transform.WorldMatrix.Forward * engineForce * verticalInput);
                DebugText.Print("speed " + Math.Round(speed), new Int2(100, 200));
                if (speed < 0 && speed > -100)
                {
                    DebugText.Print(Math.Abs(Math.Round(speed)) + " (R)", new Int2(100, 200));
                }
            }
        }

        // Start is called before the first frame update
        public override void Start()
        {
            rb = Entity.Get<RigidbodyComponent>();
            // stop rotating
            Entity.Remove<Turn>();

            Entity.Transform.WorldMatrix.TranslationVector = new Vector3(-30, 0, 0);
        }

        // Update is called once per frame
        public override void Update()
        {
            GetInput();

            Accelerate();

            Steer();
        }
    }
}