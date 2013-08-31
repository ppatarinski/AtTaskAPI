using System.Collections.Generic;
using AtTaskAPI.JsonObjects;
using RestSharp;

namespace AtTaskAPI
{
    public class AtTaskApi
    {
        /// <summary>
        /// A constructor that takes in the root AtTask api url
        /// Example : https://{CompanyName}.attask-ondemand.com/attask/api/
        /// </summary>
        /// <param name="atTaskRootUrl"></param>
        public AtTaskApi(string atTaskRootUrl)
        {
            _client = new RestClient(atTaskRootUrl);
        }

        private readonly RestClient _client;

        /// <summary>
        /// Retrieves the session id by username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string GetSession(string username, string password)
        {
            var request = new RestRequest("{methodname}", Method.GET);

            request.AddUrlSegment("methodname", "login");

            request.AddParameter("username", username);
            request.AddParameter("password", password);

            IRestResponse<Rootobject> response = _client.Execute<Rootobject>(request);

            if (response.Data.data == null)
            {
                return null;
            }

            return response.Data.data.sessionID;
        }

        /// <summary>
        /// This method returns a list of tasks by a list of AtTask reference numbers(unique AtTask identifier)
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="referenceNumbers"></param>
        /// <returns></returns>
        public List<Task> GetTaskListByReferenceNumberList(string sessionId, List<int> referenceNumbers)
        {
            var request = new RestRequest("task/{methodname}", Method.GET);

            request.AddHeader("SessionID", sessionId);

            request.AddUrlSegment("methodname", "search");

            foreach (int referenceNumber in referenceNumbers)
            {
                request.AddParameter("referenceNumber", referenceNumber);
            }

            request.AddParameter("fields", "referenceNumber");

            IRestResponse<TaskCollection> taskCollection = _client.Execute<TaskCollection>(request);

            return taskCollection.Data.data;
        }

        public List<Task> GetMyWork(string sessionId)
        {
            var request = new RestRequest("work/{methodname}", Method.GET);

            request.AddHeader("SessionID", sessionId);

            request.AddUrlSegment("methodname", "myWork");
            request.AddParameter("fields", "referenceNumber");

            IRestResponse<TaskCollection> taskCollection = _client.Execute<TaskCollection>(request);

            return taskCollection.Data.data;
        }
    }
}
