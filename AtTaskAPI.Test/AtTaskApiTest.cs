using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtTaskAPI.Test
{
    [TestClass]
    public class AtTaskApiTest
    {
        private readonly string ATTASKROOTURL = Properties.Settings.Default.RootAtTaskUrl;
        private readonly string USERNAME =  Properties.Settings.Default.Username;
        private readonly string PASSWORD = Properties.Settings.Default.Password;

        private AtTaskApi _atTaskApi;

        [TestInitialize]
        public void Initialize()
        {
            _atTaskApi = new AtTaskApi(ATTASKROOTURL);
        }

        [TestMethod]
        public void GetTaskListByReferenceNumberList_ShouldReturnAListOfTasks()
        {
            var referenceNumbers = new List<int>
                {
                    38965,
                    17303
                };

            var result = _atTaskApi.GetTaskListByReferenceNumberList(_atTaskApi.GetSession(USERNAME, PASSWORD), referenceNumbers);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, referenceNumbers.Count);
        }

        [TestMethod]
        public void GetUserSession_ShouldRetrieveASessionId_IfCredentialsAreValid()
        {
            var sessionId = _atTaskApi.GetSession(USERNAME, PASSWORD);

            Assert.IsNotNull(sessionId);
        }
        
        [TestMethod]
        public void GetMyWork_ShouldReturnAllTheWorkItemsUnderMyWork()
        {
            var result = _atTaskApi.GetMyWork(_atTaskApi.GetSession(USERNAME, PASSWORD));
            
            Assert.IsNotNull(result);
        }
    }
}
