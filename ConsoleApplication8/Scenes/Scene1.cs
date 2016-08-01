using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace ConsoleApplication8.Scenes
{
    class Scene1 : Scene
    {
        public Scene1() : base() {

            var entity = new Player(Game.Instance.HalfWidth, Game.Instance.HalfHeight);

            this.Add(entity);
        }

        public override void Update()
        {
            base.Update();

            if (Input.KeyPressed(Key.Return))
            {
                Game.SwitchScene(new Scene2());
            }
        }
    }
}
