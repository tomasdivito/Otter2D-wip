using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication8.Scenes;

using Otter;

namespace ConsoleApplication8
{
    class Player : Entity
    {

        //variable declaration
        public float MoveSpeed;
        public float animationFlow = 10;
        public const float MoveSpeedSlow = 2;
        public const float MoveSpeedFast = 10;


        //Enum for the direction that the player is facing
        enum FacingPosition
        {
            Up,
            Down,
            Left,
            Right,
            TopLeft,
            TopRight,
            DownLeft,
            DownRight,
            Idle
        }

        //Enum for all the animations of the player
        enum Animation
        {
            WalkUp,
            WalkDown,
            WalkLeft,
            WalkRight,
            WalkTopLeft,
            WalkTopRight,
            WalkDownRight,
            WalkDownLeft,
            IdleLeft,
            IdleRight,
            IdleUp,
            IdleDown
        }

        // Create the Spritemap to use. Use Sprite.png as the texture, and define the cell size as 32 x 32.
        Spritemap<Animation> spritemap = new Spritemap<Animation>("sprite_g.png", 32, 32);
        FacingPosition direction = FacingPosition.Idle;

        //Constructor
        public Player(float x, float y) : base(x, y){

            spritemap.Add(Animation.WalkUp, "18,19,20,21,22,23", animationFlow);
            spritemap.Add(Animation.WalkRight, "12,13,14,15,16,17", animationFlow);
            spritemap.Add(Animation.WalkDown, "0,1,2,3,4,5", animationFlow);
            spritemap.Add(Animation.WalkLeft, "6,7,8,9,10,11", 4);
            spritemap.Add(Animation.WalkDownLeft, "24,25,26,27,28,20", animationFlow);
            spritemap.Add(Animation.WalkDownRight, "30,31,32,33,34,35", animationFlow);
            spritemap.Add(Animation.WalkTopLeft, "36,37,38,39,40,41", animationFlow);
            spritemap.Add(Animation.WalkTopRight, "42,43,44,45,46,47", animationFlow);

            spritemap.Add(Animation.IdleLeft, "6", animationFlow);
            spritemap.Add(Animation.IdleRight, "12", animationFlow);
            spritemap.Add(Animation.IdleUp, "18", animationFlow);
            spritemap.Add(Animation.IdleDown, "0", animationFlow);

            spritemap.CenterOrigin();

            AddGraphic(spritemap);

            MoveSpeed = MoveSpeedSlow;

            spritemap.Play(Animation.IdleDown);
        }

        public override void Update()
        {
            base.Update();
            //Input to move the character

            if (Input.KeyDown(Key.W))
            {
                Y -= MoveSpeed;
            }

            if (Input.KeyDown(Key.A))
            {
                X -= MoveSpeed;
            }

            if (Input.KeyDown(Key.D))
            {
                X += MoveSpeed;
            }

            if (Input.KeyDown(Key.S))
            {
                Y += MoveSpeed;
            }

            //Input to play animations when moving

            if (Input.KeyPressed(Key.S))
            {
                if (direction == FacingPosition.Left)
                {
                    spritemap.Play(Animation.WalkDownLeft);
                    direction = FacingPosition.DownLeft;
                }
                else if (direction == FacingPosition.Right)
                {
                    spritemap.Play(Animation.WalkDownRight);
                    direction = FacingPosition.DownRight;
                }
                else
                {
                    spritemap.Play(Animation.WalkDown);
                    direction = FacingPosition.Down;
                }
            }

            else if (Input.KeyPressed(Key.D))
            {
                if (direction == FacingPosition.Up)
                {
                    spritemap.Play(Animation.WalkTopRight);
                    direction = FacingPosition.TopRight;
                }
                else if (direction == FacingPosition.Down)
                {
                    spritemap.Play(Animation.WalkDownRight);
                    direction = FacingPosition.DownRight;
                }
                else
                {
                    spritemap.Play(Animation.WalkRight);
                    direction = FacingPosition.Right;
                }
            }

            else if (Input.KeyPressed(Key.A))
            {
                if (direction == FacingPosition.Up)
                {
                    spritemap.Play(Animation.WalkTopLeft);
                    direction = FacingPosition.TopLeft;
                }
                else if (direction == FacingPosition.Down)
                {
                    spritemap.Play(Animation.WalkDownLeft);
                    direction = FacingPosition.DownLeft;
                }
                else
                {
                    spritemap.Play(Animation.WalkLeft);
                    direction = FacingPosition.Left;
                }

            }

            else if (Input.KeyPressed(Key.W))
            {
                if (direction == FacingPosition.Left)
                {
                    spritemap.Play(Animation.WalkTopLeft);
                    direction = FacingPosition.TopLeft;
                }
                else if (direction == FacingPosition.Right)
                {
                    spritemap.Play(Animation.WalkTopRight);
                    direction = FacingPosition.TopRight;
                }
                else
                {
                    spritemap.Play(Animation.WalkUp);
                    direction = FacingPosition.Up;
                }
            }

            else if (Input.KeyReleased(Key.W))
            {
                if (direction == FacingPosition.Up)
                {
                    direction = FacingPosition.Idle;
                    spritemap.Play(Animation.IdleUp);
                }
                else if (direction == FacingPosition.TopLeft)
                {
                    direction = FacingPosition.Left;
                    spritemap.Play(Animation.WalkLeft);
                }
                else if (direction == FacingPosition.TopRight)
                {
                    direction = FacingPosition.Right;
                    spritemap.Play(Animation.WalkRight);
                }
            }

            else if (Input.KeyReleased(Key.S))
            {
                if (direction == FacingPosition.Down)
                {
                    direction = FacingPosition.Idle;
                    spritemap.Play(Animation.IdleDown);
                }
                else if (direction == FacingPosition.DownLeft)
                {
                    direction = FacingPosition.Left;
                    spritemap.Play(Animation.WalkLeft);
                }
                else if (direction == FacingPosition.DownRight)
                {
                    direction = FacingPosition.Right;
                    spritemap.Play(Animation.WalkRight);
                }
            }

            else if (Input.KeyReleased(Key.A))
            {
                if (direction == FacingPosition.Left)
                {
                    direction = FacingPosition.Idle;
                    spritemap.Play(Animation.IdleLeft);
                }
                else if (direction == FacingPosition.DownLeft)
                {
                    direction = FacingPosition.Down;
                    spritemap.Play(Animation.WalkDown);
                }
                else if (direction == FacingPosition.TopLeft)
                {
                    direction = FacingPosition.Up;
                    spritemap.Play(Animation.WalkUp);
                }
            }

            else if (Input.KeyReleased(Key.D))
            {
                if (direction == FacingPosition.Right)
                {
                    direction = FacingPosition.Idle;
                    spritemap.Play(Animation.IdleRight);
                }
                else if (direction == FacingPosition.DownRight)
                {
                    direction = FacingPosition.Down;
                    spritemap.Play(Animation.WalkDown);
                }
                else if (direction == FacingPosition.TopRight)
                {
                    direction = FacingPosition.Up;
                    spritemap.Play(Animation.WalkUp);
                }
            }
            //other inputs

            if (Input.KeyPressed(Key.Space))
            {
                if (MoveSpeed == MoveSpeedSlow)
                {
                    Flashe(Color.Red);
                    MoveSpeed = MoveSpeedFast;
                    Graphic.Color = Color.Red;
                }
                else
                {
                    Flashe(Color.White);
                    MoveSpeed = MoveSpeedSlow;
                    Graphic.Color = Color.White;
                }
            }
        }

        public void Flashe(Color color)
        {
            Flash f = new Flash(color);
            f.Alpha = 0.5f;
            f.FinalAlpha = 0;
            f.LifeSpan = 10;

            Game.Scene.Add(f);
        }

    }

}
