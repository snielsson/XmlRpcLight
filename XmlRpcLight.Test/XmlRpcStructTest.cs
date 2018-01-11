using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using XmlRpcLight.DataTypes;
namespace XmlRpcLight.Test {
    [TestFixture]
    public class XmlRpcStructTest {
        [Test]
        public void Set() {
            var xps = new XmlRpcStruct();
            xps["foo"] = "abcdef";
            Assert.AreEqual("abcdef", xps["foo"]);
        }

        //[Test]
        //public void SetInvalidKey() {
        //    var xps = new XmlRpcStruct();
        //  Assert.Throws< ArgumentException>(()=>  xps[1] = "abcdef");
        //}

        [Test]
        public void DoubleSet() {
            var xps = new XmlRpcStruct();
            xps["foo"] = "12345";
            xps["foo"] = "abcdef";
            Assert.AreEqual("abcdef", xps["foo"]);
        }

        //[Test]
        //public void AddInvalidKey() {
        //    Assert.Throws< ArgumentException>(()=> new XmlRpcStruct {
        //        {1, "abcdef"}
        //    });
        //}

        [Test]
        public void Add() {
            var xps = new XmlRpcStruct {
                {"foo", "abcdef"}
            };
            Assert.AreEqual("abcdef", xps["foo"]);
        }

        [Test]
        public void DoubleAdd() {
            Assert.Throws< ArgumentException>(()=> new XmlRpcStruct {
                {"foo", "123456"},
                {"foo", "abcdef"}
            });
        }

        [Test]
        public void OrderingEnumerator() {
            var xps = new XmlRpcStruct {
                {"1", "a"},
                {"3", "c"},
                {"2", "b"}
            };
            var enumerator = xps.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual("1", enumerator.Current.Key);
            Assert.AreEqual("a", enumerator.Current.Value);
            Assert.IsInstanceOf<KeyValuePair<string, object>>( enumerator.Current);
            var de = enumerator.Current;
            Assert.AreEqual("1", de.Key);
            Assert.AreEqual("a", de.Value);
            enumerator.MoveNext();
            Assert.AreEqual("3", enumerator.Current.Key);
            Assert.AreEqual("c", enumerator.Current.Value);
            Assert.IsInstanceOf< KeyValuePair<string, object>>( enumerator.Current);
            de =  enumerator.Current;
            Assert.AreEqual("3", de.Key);
            Assert.AreEqual("c", de.Value);
            enumerator.MoveNext();
            Assert.AreEqual("2", enumerator.Current.Key);
            Assert.AreEqual("b", enumerator.Current.Value);
            Assert.IsInstanceOf< KeyValuePair<string, object>>( enumerator.Current);
            de = enumerator.Current;
            Assert.AreEqual("2", de.Key);
            Assert.AreEqual("b", de.Value);
        }

        [Test]
        public void OrderingKeys() {
            var xps = new XmlRpcStruct {
                {"1", "a"},
                {"3", "c"},
                {"2", "b"}
            };

            var enumerator = xps.Keys.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual("1", enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual("3", enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual("2", enumerator.Current);
        }

        [Test]
        public void OrderingValues() {
            var xps = new XmlRpcStruct {
                {"1", "a"},
                {"3", "c"},
                {"2", "b"}
            };

            var enumerator = xps.Values.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual("a", enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual("c", enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual("b", enumerator.Current);
        }
    }
}