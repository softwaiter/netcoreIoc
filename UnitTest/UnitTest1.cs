using CodeM.Common.Ioc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BuildByClassName()
        {
            string testlibraryPath = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\..\\TestLibrary\\bin\\Debug\\netcoreapp2.1");
            DirectoryInfo di = new DirectoryInfo(testlibraryPath);

            IocUtils.AddSearchPath(di.FullName);

            object a = IocUtils.GetObject("TestLibrary.Person");
            Assert.IsNotNull(a);
            Console.WriteLine("a: " + a);

            object b = IocUtils.GetObject("TestLibrary.Person", "����");
            Assert.IsNotNull(b);
            Console.WriteLine("b: " + b);

            object c = IocUtils.GetObject("TestLibrary.Person", "����", true);
            Assert.IsNotNull(c);
            Console.WriteLine("c: " + c);

            object d = IocUtils.GetObject("TestLibrary.Person", "����", (Int16)18, true);
            Assert.IsNotNull(d);
            Console.WriteLine("d: " + d);

            IocUtils.RemoveSearchPath(di.FullName);
        }

        [DataTestMethod]
        [DataRow("aaa")]
        [DataRow("bbb")]
        [DataRow("ccc")]
        [DataRow("ddd")]
        [DataRow("eee")]
        [DataRow("fff")]
        public void BuildByConfigId(string objectId)
        {
            string testlibraryPath = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\..\\TestLibrary\\bin\\Debug\\netcoreapp2.1");
            DirectoryInfo di = new DirectoryInfo(testlibraryPath);

            IocUtils.AddSearchPath(di.FullName);

            string config = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\ioc.xml");
            IocUtils.LoadConfig(config);

            object obj = IocUtils.GetObjectById(objectId);
            Assert.IsNotNull(obj);

            Console.WriteLine(objectId + ": " + obj);

            IocUtils.RemoveSearchPath(di.FullName);
        }

        [DataTestMethod]
        [DataRow("ggg")]
        [DataRow("hhh")]
        public void BuildByConfigIdWithObjectReference(string objectId)
        {
            string testlibraryPath = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\..\\TestLibrary\\bin\\Debug\\netcoreapp2.1");
            DirectoryInfo di = new DirectoryInfo(testlibraryPath);

            IocUtils.AddSearchPath(di.FullName);

            string config = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\ioc.xml");
            IocUtils.LoadConfig(config);

            object obj = IocUtils.GetObjectById(objectId);
            Assert.IsNotNull(obj);

            Console.WriteLine(objectId + ": " + obj);

            IocUtils.RemoveSearchPath(di.FullName);
        }
    }
}