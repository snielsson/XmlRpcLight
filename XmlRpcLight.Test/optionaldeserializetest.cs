using System;
using NUnit.Framework;
using XmlRpcLight;
using XmlRpcLight.Attributes;
using XmlRpcLight.DataTypes;
using XmlRpcLight.Enums;
using XmlRpcLight.Test;

internal struct ChildStruct {
    public int x;
    public ChildStruct(int num) {
        x = num;
    }
}

internal class XmlRpcStruct1 : XmlRpcStruct {
    public int mi;
}

namespace ntest {
    [TestFixture]
    public class OptionalDeserializeTest {
        private struct Struct1 {
            public int mi;
            public string ms;
            public bool mb;
            public double md;
            public DateTime mdt;
            public byte[] mb64;
            public int[] ma;
            public XmlRpcInt xi;
            public XmlRpcBoolean xb;
            public XmlRpcDouble xd;
            public XmlRpcDateTime xdt;
            public XmlRpcStruct xstr;
#if !FX1_0
            public int? nxi;
            public bool? nxb;
            public double? nxd;
            public DateTime? nxdt;
            public ChildStruct? nxstr;
#endif
        }

        [XmlRpcMissingMapping(MappingAction.Ignore)]
        private struct Struct2 {
            public int mi;
            public string ms;
            public bool mb;
            public double md;
            public DateTime mdt;
            public byte[] mb64;
            public int[] ma;
            public XmlRpcInt xi;
            public XmlRpcBoolean xb;
            public XmlRpcDouble xd;
            public XmlRpcDateTime xdt;
            public XmlRpcStruct xstr;
#if !FX1_0
            public int? nxi;
            public bool? nxb;
            public double? nxd;
            public DateTime? nxdt;
            public ChildStruct? nxstr;
#endif
        }

        private struct Struct3 {
            [XmlRpcMissingMapping(MappingAction.Ignore)] public int mi;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public string ms;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public bool mb;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public double md;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public DateTime mdt;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public byte[] mb64;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public int[] ma;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public XmlRpcInt xi;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public XmlRpcBoolean xb;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public XmlRpcDouble xd;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public XmlRpcDateTime xdt;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public XmlRpcStruct xstr;
#if !FX1_0
            [XmlRpcMissingMapping(MappingAction.Ignore)] public int? nxi;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public bool? nxb;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public double? nxd;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public DateTime? nxdt;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public ChildStruct? nxstr;
#endif
        }

        [XmlRpcMissingMapping(MappingAction.Error)]
        private struct Struct4 {
            [XmlRpcMissingMapping(MappingAction.Ignore)] public int mi;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public string ms;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public bool mb;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public double md;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public DateTime mdt;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public byte[] mb64;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public int[] ma;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public XmlRpcInt xi;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public XmlRpcBoolean xb;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public XmlRpcDouble xd;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public XmlRpcDateTime xdt;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public XmlRpcStruct xstr;
#if !FX1_0
            [XmlRpcMissingMapping(MappingAction.Ignore)] public int? nxi;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public bool? nxb;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public double? nxd;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public DateTime? nxdt;
            [XmlRpcMissingMapping(MappingAction.Ignore)] public ChildStruct? nxstr;
#endif
        }

        [Test]
        public void Struct1_AllMissing_Error() {
            Type parsedType, parsedArrayType;
            var xml = @"<?xml version=""1.0"" ?><value><struct></struct></value>";
            Assert.Throws< XmlRpcTypeMismatchException>(()=>Utils.Parse(xml, typeof (Struct1), MappingAction.Error,
                out parsedType, out parsedArrayType));
            //Assert.Fail("didn't detect missing members");
        }

        [Test]
        public void Struct1_AllMissing_Ignore() {
            Type parsedType, parsedArrayType;
            var xml = @"<?xml version=""1.0"" ?><value><struct></struct></value>";
            object obj = Utils.Parse(xml, typeof (Struct1), MappingAction.Ignore,
                out parsedType, out parsedArrayType);
            Assert.IsTrue(obj is Struct1, "obj is Struct1");
            Assert.AreEqual(0, ((Struct1) obj).mi, "int member");
            Assert.AreEqual(null, ((Struct1) obj).ms, "string member");
            Assert.AreEqual(false, ((Struct1) obj).mb, "boolean member");
            Assert.AreEqual(0.0, ((Struct1) obj).md, "double member");
            Assert.AreEqual(new DateTime(), ((Struct1) obj).mdt, "dateTime member");
            Assert.AreEqual(null, ((Struct1) obj).mb64, "base64 member");
            Assert.AreEqual(null, ((Struct1) obj).ma, "array member");
            Assert.AreEqual(null, ((Struct1) obj).xi, "XmlRpcInt member");
            Assert.AreEqual(null, ((Struct1) obj).xb, "XmlRpcBoolean member");
            Assert.AreEqual(null, ((Struct1) obj).xd, "XmlRpcDouble member");
            Assert.AreEqual(null, ((Struct1) obj).xdt, "XmlRpcDateTime member");
            Assert.AreEqual(null, ((Struct1) obj).xstr, "XmlRpcStructTime member");
#if !FX1_0
            Assert.AreEqual(null, ((Struct1) obj).nxi, "int? member");
            Assert.AreEqual(null, ((Struct1) obj).nxb, "bool? member");
            Assert.AreEqual(null, ((Struct1) obj).nxd, "double? member");
            Assert.AreEqual(null, ((Struct1) obj).nxdt, "DateTime? member");
            Assert.AreEqual(null, ((Struct1) obj).nxstr, "ChildStruct? member");
#endif
        }

        [Test]
        public void Struct1_AllExist() {
            Type parsedType, parsedArrayType;
            var xml = @"<?xml version=""1.0"" ?>
<value><struct>
<member><name>mi</name><value><i4>12345</i4></value></member>
<member><name>ms</name><value><string>Test String</string></value></member>
<member><name>mb</name><value><boolean>1</boolean></value></member>
<member><name>md</name><value><double>1234.567</double></value></member>
<member><name>mdt</name><value><dateTime.iso8601>20020707T11:25:37</dateTime.iso8601></value></member>
<member><name>mb64</name><value><base64>AQIDBAUGBwg=</base64></value></member>
<member><name>ma</name><value><array><data><value><i4>1</i4></value><value><i4>2</i4></value></data></array></value></member>
<member><name>xi</name><value><i4>23456</i4></value></member>
<member><name>xb</name><value><boolean>1</boolean></value></member>
<member><name>xd</name><value><double>2345.678</double></value></member>
<member><name>xdt</name><value><dateTime.iso8601>20030808T11:25:37</dateTime.iso8601></value></member>
<member><name>xstr</name><value><struct><member><name>key3</name><value><string>test</string></value></member></struct></value></member>"
#if !FX1_0
                      +
                      @"
<member><name>nxi</name><value><i4>34567</i4></value></member>
<member><name>nxb</name><value><boolean>1</boolean></value></member>
<member><name>nxd</name><value><double>3456.789</double></value></member>
<member><name>nxdt</name><value><dateTime.iso8601>20040909T11:25:37</dateTime.iso8601></value></member>
<member><name>nxstr</name><value><struct><member><name>x</name><value><i4>1234</i4></value></member></struct></value></member>
"
#endif
                      +
                      @"</struct></value>";
            object obj = Utils.Parse(xml, typeof (Struct1), MappingAction.Error,
                out parsedType, out parsedArrayType);
            Assert.IsTrue(obj is Struct1, "obj is Struct1");
            Assert.AreEqual(12345, ((Struct1) obj).mi, "int member");
            Assert.AreEqual("Test String", ((Struct1) obj).ms, "string member");
            Assert.AreEqual(true, ((Struct1) obj).mb, "boolean member");
            Assert.AreEqual(1234.567, ((Struct1) obj).md, "double member");
            Assert.AreEqual(new DateTime(2002, 7, 7, 11, 25, 37), ((Struct1) obj).mdt, "dateTime member");
// TODO:      Assert.AreEqual(null, ((Struct1)obj).mb64, "base64 member");
// TODO:       Assert.AreEqual(null, ((Struct1)obj).ma, "array member");
            Assert.AreEqual(23456, (int) ((Struct1) obj).xi, "XmlRpcInt member");
            Assert.IsTrue(true == ((Struct1) obj).xb);
            Assert.IsTrue(2345.678 == ((Struct1) obj).xd);
            Assert.IsTrue(new DateTime(2003, 8, 8, 11, 25, 37).Equals(((Struct1) obj).xdt));
#if !FX1_0
            Assert.AreEqual(34567, ((Struct1) obj).nxi, "int? member");
            Assert.AreEqual(true, ((Struct1) obj).nxb, "bool? member");
            Assert.AreEqual(3456.789, ((Struct1) obj).nxd, "double? member");
            Assert.AreEqual(new DateTime(2004, 9, 9, 11, 25, 37), ((Struct1) obj).nxdt, "DateTime? member");
            Assert.AreEqual(1234, ((ChildStruct) ((Struct1) obj).nxstr).x);
#endif
        }

        [Test]
        public void Struct2_AllMissing_ErrorStructIgnore() {
            Type parsedType, parsedArrayType;
            var xml = @"<?xml version=""1.0"" ?><value><struct></struct></value>";
            object obj = Utils.Parse(xml, typeof (Struct2), MappingAction.Error,
                out parsedType, out parsedArrayType);
            Assert.IsTrue(obj is Struct2, "obj is Struct2");
            Assert.AreEqual(0, ((Struct2) obj).mi, "int member");
            Assert.AreEqual(null, ((Struct2) obj).ms, "string member");
            Assert.AreEqual(false, ((Struct2) obj).mb, "boolean member");
            Assert.AreEqual(0.0, ((Struct2) obj).md, "double member");
            Assert.AreEqual(new DateTime(), ((Struct2) obj).mdt, "dateTime member");
            Assert.AreEqual(null, ((Struct2) obj).mb64, "base64 member");
            Assert.AreEqual(null, ((Struct2) obj).ma, "array member");
            Assert.AreEqual(null, ((Struct2) obj).xi, "XmlRpcInt member");
            Assert.AreEqual(null, ((Struct2) obj).xb, "XmlRpcBoolean member");
            Assert.AreEqual(null, ((Struct2) obj).xd, "XmlRpcDouble member");
            Assert.AreEqual(null, ((Struct2) obj).xdt, "XmlRpcDateTime member");
            Assert.AreEqual(null, ((Struct2) obj).xstr, "XmlRpcStructTime member");
#if !FX1_0
            Assert.AreEqual(null, ((Struct2) obj).nxi, "int? member");
            Assert.AreEqual(null, ((Struct2) obj).nxb, "bool? member");
            Assert.AreEqual(null, ((Struct2) obj).nxd, "double? member");
            Assert.AreEqual(null, ((Struct2) obj).nxdt, "DateTime? member");
            Assert.AreEqual(null, ((Struct2) obj).nxdt, "ChildStruct? member");
#endif
        }

        [Test]
        public void Struct3_AllMissing_ErrorMemberIgnore() {
            Type parsedType, parsedArrayType;
            var xml = @"<?xml version=""1.0"" ?><value><struct></struct></value>";
            object obj = Utils.Parse(xml, typeof (Struct3), MappingAction.Error,
                out parsedType, out parsedArrayType);
            Assert.IsTrue(obj is Struct3, "obj is Struct3");
            Assert.AreEqual(0, ((Struct3) obj).mi, "int member");
            Assert.AreEqual(null, ((Struct3) obj).ms, "string member");
            Assert.AreEqual(false, ((Struct3) obj).mb, "boolean member");
            Assert.AreEqual(0.0, ((Struct3) obj).md, "double member");
            Assert.AreEqual(new DateTime(), ((Struct3) obj).mdt, "dateTime member");
            Assert.AreEqual(null, ((Struct3) obj).mb64, "base64 member");
            Assert.AreEqual(null, ((Struct3) obj).ma, "array member");
            Assert.AreEqual(null, ((Struct3) obj).xi, "XmlRpcInt member");
            Assert.AreEqual(null, ((Struct3) obj).xb, "XmlRpcBoolean member");
            Assert.AreEqual(null, ((Struct3) obj).xd, "XmlRpcDouble member");
            Assert.AreEqual(null, ((Struct3) obj).xdt, "XmlRpcDateTime member");
            Assert.AreEqual(null, ((Struct3) obj).xstr, "XmlRpcStructTime member");
#if !FX1_0
            Assert.AreEqual(null, ((Struct3) obj).nxi, "int? member");
            Assert.AreEqual(null, ((Struct3) obj).nxb, "bool? member");
            Assert.AreEqual(null, ((Struct3) obj).nxd, "double? member");
            Assert.AreEqual(null, ((Struct3) obj).nxdt, "DateTime? member");
            Assert.AreEqual(null, ((Struct3) obj).nxdt, "ChildStruct? member");
#endif
        }

        [Test]
        public void Struct4_AllMissing_ErrorStructErrorMemberIgnore() {
            Type parsedType, parsedArrayType;
            var xml = @"<?xml version=""1.0"" ?><value><struct></struct></value>";
            object obj = Utils.Parse(xml, typeof (Struct4), MappingAction.Error,
                out parsedType, out parsedArrayType);
            Assert.IsTrue(obj is Struct4, "obj is Struct4");
            Assert.AreEqual(0, ((Struct4) obj).mi, "int member");
            Assert.AreEqual(null, ((Struct4) obj).ms, "string member");
            Assert.AreEqual(false, ((Struct4) obj).mb, "boolean member");
            Assert.AreEqual(0.0, ((Struct4) obj).md, "double member");
            Assert.AreEqual(new DateTime(), ((Struct4) obj).mdt, "dateTime member");
            Assert.AreEqual(null, ((Struct4) obj).mb64, "base64 member");
            Assert.AreEqual(null, ((Struct4) obj).ma, "array member");
            Assert.AreEqual(null, ((Struct4) obj).xi, "XmlRpcInt member");
            Assert.AreEqual(null, ((Struct4) obj).xb, "XmlRpcBoolean member");
            Assert.AreEqual(null, ((Struct4) obj).xd, "XmlRpcDouble member");
            Assert.AreEqual(null, ((Struct4) obj).xdt, "XmlRpcDateTime member");
            Assert.AreEqual(null, ((Struct4) obj).xstr, "XmlRpcStructTime member");
#if !FX1_0
            Assert.AreEqual(null, ((Struct4) obj).nxi, "int? member");
            Assert.AreEqual(null, ((Struct4) obj).nxb, "bool? member");
            Assert.AreEqual(null, ((Struct4) obj).nxd, "double? member");
            Assert.AreEqual(null, ((Struct4) obj).nxdt, "DateTime? member");
            Assert.AreEqual(null, ((Struct4) obj).nxstr, "ChildStruct? member");
#endif
        }

        [Test]
        public void Struct4_AllMissing_IgnoreStructErrorMemberIgnore() {
            Type parsedType, parsedArrayType;
            var xml = @"<?xml version=""1.0"" ?><value><struct></struct></value>";
            object obj = Utils.Parse(xml, typeof (Struct4), MappingAction.Ignore,
                out parsedType, out parsedArrayType);
            Assert.IsTrue(obj is Struct4, "obj is Struct4");
            Assert.AreEqual(0, ((Struct4) obj).mi, "int member");
            Assert.AreEqual(null, ((Struct4) obj).ms, "string member");
            Assert.AreEqual(false, ((Struct4) obj).mb, "boolean member");
            Assert.AreEqual(0.0, ((Struct4) obj).md, "double member");
            Assert.AreEqual(new DateTime(), ((Struct4) obj).mdt, "dateTime member");
            Assert.AreEqual(null, ((Struct4) obj).mb64, "base64 member");
            Assert.AreEqual(null, ((Struct4) obj).ma, "array member");
            Assert.AreEqual(null, ((Struct4) obj).xi, "XmlRpcInt member");
            Assert.AreEqual(null, ((Struct4) obj).xb, "XmlRpcBoolean member");
            Assert.AreEqual(null, ((Struct4) obj).xd, "XmlRpcDouble member");
            Assert.AreEqual(null, ((Struct4) obj).xdt, "XmlRpcDateTime member");
            Assert.AreEqual(null, ((Struct4) obj).xstr, "XmlRpcStructTime member");
#if !FX1_0
            Assert.AreEqual(null, ((Struct4) obj).xi, "XmlRpcInt member");
            Assert.AreEqual(null, ((Struct4) obj).xb, "XmlRpcBoolean member");
            Assert.AreEqual(null, ((Struct4) obj).xd, "XmlRpcDouble member");
            Assert.AreEqual(null, ((Struct4) obj).xdt, "XmlRpcDateTime member");
#endif
        }

        [XmlRpcMissingMapping(MappingAction.Ignore)]
        private struct StructOuter1 {
            public StructInner1 mstruct;
        }

        private struct StructInner1 {
            public int mi;
        }

        [Test, Ignore("StructOuter1 has a MappingIgnore attribute, thus this test is invalid")]
        public void NoInnerStructOverrideIgnoreError() {
            Type parsedType, parsedArrayType;
            var xml = @"<?xml version=""1.0"" ?>
      <value>
        <struct>
          <member>
            <name>mstruct</name>
            <value><struct></struct></value>
          </member>
        </struct>
      </value>";
            Assert.Throws< XmlRpcTypeMismatchException>(()=> Utils.Parse(xml, typeof (StructOuter1), MappingAction.Error,
                out parsedType, out parsedArrayType) );
           // Assert.Fail("didn't detect missing members");
        }

        [XmlRpcMissingMapping(MappingAction.Error)]
        private struct StructOuter2 {
            public StructInner2 mstruct;
        }

        private struct StructInner2 {
            public int mi;
        }

        [Test]
        public void NoInnerStructOverrideErrorIgnore() {
            Type parsedType, parsedArrayType;
            var xml = @"<?xml version=""1.0"" ?>
      <value>
        <struct>
          <member>
            <name>mstruct</name>
            <value><struct></struct></value>
          </member>
        </struct>
      </value>";
            object obj = Utils.Parse(xml, typeof (StructOuter2),
                MappingAction.Ignore,
                out parsedType, out parsedArrayType);
        }

        //-------------------------------------------------------------------------/
        private struct StructHung {
            [XmlRpcMissingMapping(MappingAction.Ignore)] public int mi;
            public string ms;
            [XmlRpcMissingMapping(MappingAction.Ignore)]
            public int pi { get; set; }
            public string ps { get; set; }
        }

        [Test]
        public void HungStruct() {
            Type parsedType, parsedArrayType;
            var xml = @"<?xml version=""1.0"" ?>
      <value>
        <struct>
          <member>
            <name>mi</name>
            <value><int>0</int></value>
          </member>
          <member>
            <name>ms</name>
            <value><string></string></value>
          </member>
          <member>
            <name>ps</name>
            <value><string>property</string></value>
          </member>
        </struct>
      </value>";
            object obj = Utils.Parse(xml, typeof (StructHung), MappingAction.Error,
                out parsedType, out parsedArrayType);
            Assert.IsTrue(obj is StructHung);
            var strct = (StructHung) obj;
            Assert.AreEqual(strct.mi, 0);
            Assert.AreEqual(strct.ms, "");
            Assert.AreEqual(strct.pi, 0);
            Assert.AreEqual(strct.ps, "property");
        }
    }
}