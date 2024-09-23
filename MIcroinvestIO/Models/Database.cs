using MIcroinvestIO;

namespace MIcroinvestIO.Models
{
    public class Database
    {
        //private string ip;
        //private string user;
        //private string password;
        //public Database(string ip,string user, string password)
        //{
        //    Ip = ip;
        //    User = user;
        //    Password = password;
        //}
        public string Ip { get; set; }
        public string DatabaseName {  get; set; }
        public string User {  get; set; }
        public string Password { get; set; }
        public string Success { get; set; }
        public string ConnectionString
        {
            get
            {
                return $"Server={Ip};Database={DatabaseName};User Id={User};Password={Password};encrypt=false;";
            }
        }

    }

}
