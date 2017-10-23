using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BattleshipBot
{
    [TestFixture]
    class Test
    {
        [Test]
        public void test()
        {
            var IrishBot = new IrishBot();
            var shipPosition = IrishBot.GetShipPositions();
            Console.WriteLine();
        }
    }
}
