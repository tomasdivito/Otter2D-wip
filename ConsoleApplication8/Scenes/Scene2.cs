using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace ConsoleApplication8.Scenes
{
    class Scene2 : Scene
    {
        public Scene2() : base()
        {

        }

        public override void Update()
        {
            base.Update();

            if (Input.KeyPressed(Key.Return))
            {
                Game.SwitchScene(new Scene1());
            }
        }
    }
}
