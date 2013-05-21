﻿using GW2DotNET.Events;

using NUnit.Framework;

namespace GW2.NET_Tests
{
    [TestFixture]
    class WorldDataTest
    {
        private WorldData data;

        [SetUp]
        public void Init()
        {
            data = new WorldData();
        }

        [Test]
        public void GetWorlds()
        {
            var worlds = data.GetWorlds();

            Assert.IsFalse(worlds == null);
        }

        [Test]
        public void GetMaps()
        {
            var maps = data.GetMaps();

            Assert.IsFalse(maps == null);
        }
    }
}
