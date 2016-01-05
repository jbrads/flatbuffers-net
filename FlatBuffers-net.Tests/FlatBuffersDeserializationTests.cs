﻿using System.Collections.Generic;
using System.Linq;
using FlatBuffers.Tests.TestTypes;
using NUnit.Framework;

namespace FlatBuffers.Tests
{
    [TestFixture]
    public class FlatBuffersDeserializationTests
    {
        [Test]
        public void Deserialize_FromOracleData_WithTestStruct1()
        {
            const int intProp = 42;
            const byte byteProp = 22;
            const short shortProp = 62;

            var oracle = new SerializationTestOracle();
            var oracleResult = oracle.GenerateTestStruct1(intProp, byteProp, shortProp);

            var serializer = new FlatBuffersSerializer();
            var o = serializer.Deserialize<TestStruct1>(oracleResult, 0, oracleResult.Length);

            Assert.AreEqual(intProp, o.IntProp);
            Assert.AreEqual(byteProp, o.ByteProp);
            Assert.AreEqual(shortProp, o.ShortProp);
        }

        [Test]
        public void Deserialize_FromOracleData_WithTestStruct2()
        {
            const int intProp = 42;

            var testStruct1 = new TestStruct1()
            {
                IntProp = 100,
                ByteProp = 50,
                ShortProp = 200
            };

            var oracle = new SerializationTestOracle();
            var oracleResult = oracle.GenerateTestStruct2(intProp, testStruct1);

            var serializer = new FlatBuffersSerializer();
            var o = serializer.Deserialize<TestStruct2>(oracleResult, 0, oracleResult.Length);

            Assert.AreEqual(intProp, o.IntProp);
            Assert.AreEqual(testStruct1.IntProp, o.TestStructProp.IntProp);
            Assert.AreEqual(testStruct1.ByteProp, o.TestStructProp.ByteProp);
            Assert.AreEqual(testStruct1.ShortProp, o.TestStructProp.ShortProp);
        }

        [Test]
        public void Deserialize_FromOracleData_WithTestTable1()
        {
            const int intProp = 42;
            const byte byteProp = 22;
            const short shortProp = 62;

            var oracle = new SerializationTestOracle();
            var oracleResult = oracle.GenerateTestTable1(intProp, byteProp, shortProp);

            var serializer = new FlatBuffersSerializer();
            var o = serializer.Deserialize<TestTable1>(oracleResult, 0, oracleResult.Length);

            Assert.AreEqual(intProp, o.IntProp);
            Assert.AreEqual(byteProp, o.ByteProp);
            Assert.AreEqual(shortProp, o.ShortProp);
        }

        [Test]
        public void Deserialize_FromOracleData_WithTestTableWithDefaults()
        {
            const int intProp = 123456;
            const byte byteProp = 42;
            const short shortProp = 1024;

            var oracle = new SerializationTestOracle();
            var oracleResult = oracle.GenerateTestTableWithDefaults();

            var serializer = new FlatBuffersSerializer();
            var o = serializer.Deserialize<TestTableWithDefaults>(oracleResult, 0, oracleResult.Length);

            Assert.AreEqual(intProp, o.IntProp);
            Assert.AreEqual(byteProp, o.ByteProp);
            Assert.AreEqual(shortProp, o.ShortProp);
        }

        [Test]
        public void Deserialize_FromOracleData_WithTestTableWithUserOrdering()
        {
            const int intProp = 42;
            const byte byteProp = 22;
            const short shortProp = 62;

            var oracle = new SerializationTestOracle();
            var oracleResult = oracle.GenerateTestTableWithUserOrdering(intProp, byteProp, shortProp);

            var serializer = new FlatBuffersSerializer();
            var o = serializer.Deserialize<TestTableWithUserOrdering>(oracleResult, 0, oracleResult.Length);

            Assert.AreEqual(intProp, o.IntProp);
            Assert.AreEqual(byteProp, o.ByteProp);
            Assert.AreEqual(shortProp, o.ShortProp);
        }

        [Test]
        public void Deserialize_FromOracleData_WithTestTable2()
        {
            const string stringProp = "Hello, FlatBuffers!";

            var oracle = new SerializationTestOracle();
            var oracleResult = oracle.GenerateTestTable2(stringProp);

            var serializer = new FlatBuffersSerializer();
            var o = serializer.Deserialize<TestTable2>(oracleResult, 0, oracleResult.Length);

            Assert.AreEqual(stringProp, o.StringProp);
        }

        [Test]
        public void Deserialize_FromOracleData_WithTestTable2_AndEmptyString()
        {
            var oracle = new SerializationTestOracle();
            var oracleResult = oracle.GenerateTestTable2(string.Empty);

            var serializer = new FlatBuffersSerializer();
            var o = serializer.Deserialize<TestTable2>(oracleResult, 0, oracleResult.Length);

            Assert.AreEqual(string.Empty, o.StringProp);
        }

        [Test]
        public void Deserialize_FromOracleData_WithTestTable2_AndNullString()
        {
            var oracle = new SerializationTestOracle();
            var oracleResult = oracle.GenerateTestTable2(null);

            var serializer = new FlatBuffersSerializer();
            var o = serializer.Deserialize<TestTable2>(oracleResult, 0, oracleResult.Length);

            Assert.AreEqual(null, o.StringProp);
        }

        [Test]
        public void Deserialize_FromOracleData_WithTestTableWithArray()
        {
            var intArray = new int[] {1, 2, 3, 4, 5};
            var intList = new List<int> {6, 7, 8, 9, 0};

            var oracle = new SerializationTestOracle();
            var oracleResult = oracle.GenerateTestTableWithArray(intArray, intList);

            var serializer = new FlatBuffersSerializer();
            var o = serializer.Deserialize<TestTableWithArray>(oracleResult, 0, oracleResult.Length);

            Assert.IsTrue(o.IntArray.SequenceEqual(intArray));
            Assert.IsTrue(o.IntList.SequenceEqual(intList));
        }

        [Test]
        public void Deserialize_FromOracleData_WithTestTableWithStruct()
        {
            var testStruct1 = new TestStruct1()
            {
                IntProp = 42,
                ByteProp = 22,
                ShortProp = 62,
            };

            var oracle = new SerializationTestOracle();
            var oracleResult = oracle.GenerateTestTableWithStruct(testStruct1, 1024);

            var serializer = new FlatBuffersSerializer();
            var o = serializer.Deserialize<TestTableWithStruct>(oracleResult, 0, oracleResult.Length);


        }
    }
}