using System;
using Basket.Domain;
using Basket.Persistence;
using NUnit.Framework;
using StackExchange.Redis;

namespace Basket.Tests
{
    [TestFixture]
    public class RedisTests
    {
        [Test]
        public void TestRedis()
        {
            ConnectionMultiplexer conn = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = conn.GetDatabase();

            string result = db.StringGet("mykey");
            Assert.AreEqual("myvalue", result);
        }
    }
}