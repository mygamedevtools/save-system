using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameDevTools.Persistence.Tests.Editor
{
    public class SaveSystemTests
    {
        const string _testKey = "test-key";

        static TestData _defaultTestData = new TestData
        {
            Name = "test",
            FloatValue = .123456789f,
            IntArray = new int[] { 1, 2, 3, 4 },
            Position = new Vector3(1, 2, 3),
            Color = new Color(.2f, .4f, .6f, .8f)
        };

        [Test]
        public void SetAndGetData()
        {
            var saveSystem = new SaveSystem();
            saveSystem.Set(_testKey, _defaultTestData);

            Assert.AreEqual(_defaultTestData, saveSystem.Get<TestData>(_testKey));
        }
    }

    [Serializable]
    public struct TestData
    {
        public string Name;
        public float FloatValue;
        public int[] IntArray;
        public Vector3 Position;
        public Color Color;

        public override bool Equals(object obj)
        {
            return obj is TestData data &&
                   Name == data.Name &&
                   FloatValue == data.FloatValue &&
                   EqualityComparer<int[]>.Default.Equals(IntArray, data.IntArray) &&
                   Position.Equals(data.Position) &&
                   Color.Equals(data.Color);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, FloatValue, IntArray, Position, Color);
        }
    }
}