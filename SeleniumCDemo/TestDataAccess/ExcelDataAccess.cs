using System.Data.OleDb;
using System.Linq;
using Dapper;
using System.Configuration;

namespace SeleniumCDemo.PageObjects
{
    // class taken from http://toolsqa.com/selenium-webdriver/c-sharp/data-driven-testing/
    class ExcelDataAccess
    {
        public static string TestDataFileConnection()
        {
            var fileName = ConfigurationManager.AppSettings["TestDataSheetPath"];
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        public static UserData GetTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where key='{0}'", keyName);
                var value = connection.Query<UserData>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
    class UserData
    {
        public string key { get; set; }
        public string targetURL { get; set; }
        public string userName { get; set; }
        public string userPass { get; set; }
        public string surveyName { get; set; }
        // how do I get question1.questionType?  create a question class?
        public string question1 { get; set; }
        public string question2 { get; set; }
        public string question3 { get; set; }
        public string question4 { get; set; }
        public string question5 { get; set; }

        public string getQuestionType(string questionToParse)
        {
            string[] questionArray = questionToParse.Split('|');
            return questionArray[0];
        }

        public string getQuestionTitle(string questionToParse)
        {
            string[] questionArray = questionToParse.Split('|');
            return questionArray[1];
        }

        public string getQuestionOptions(string questionToParse)
        {
            string[] questionArray = questionToParse.Split('?');
            return questionArray[1];
        }
    }
}