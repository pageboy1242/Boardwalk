using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StampedeMotor.Tests.Repositories
{
    public class RepositoryTestBase
    {
        public RepositoryTestBase()
        {
            var appDataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../App_Data");

            AppDomain.CurrentDomain.SetData("DataDirectory", appDataDir);
        }
    }
}
