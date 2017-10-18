using Newtonsoft.Json;
using RedisLibrary;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTestExchangeRedis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings["Redis"];
            string IP = ConfigurationManager.AppSettings["RedisServer"];
            RedisServerExtension redisServer = new RedisServerExtension(setting.ConnectionString, IP);
            string serverInfo = redisServer.GetServerInfo();
            IEnumerable<string> allKey = redisServer.GetAllKey();
            IEnumerable<string> specifyKey1 = redisServer.GetFilterKey("Migration_Category_6");
            //show all keys in database 0 that include "Migration_Category" in their name
            IEnumerable<string> specifyKey2 = redisServer.GetFilterKey("*Migration_Category*");

            long allCahcheNumber = redisServer.GetCacheTotalNumber();
            ServerCounters statist = redisServer.GetServerStatic();



            TestExchangeRedis redis = new TestExchangeRedis();
            string conn = TestExchangeRedis.connect;

            Console.ReadLine();
        }
    }

    public class TestExchangeRedis
    {
        public static string connect { get; set; }

        public TestExchangeRedis()
        {


            ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings["Redis"];

            //connect = setting.ConnectionString.Concat(@",allowAdmin = true");
            //connect = string.Format("{0},{1}", setting.ConnectionString, "allowAdmin = true");
            connect = setting.ConnectionString;
            ConnectedRedis();
            Console.ReadLine();
        }

        public void ConnectedRedis()
        {
            //RedisServer IP & port
            string serverIP = ConfigurationManager.AppSettings["RedisServer"];
            //string port = ConfigurationManager.AppSettings["DefaultPort"];

            //Redis選項 需有管理員權限
            //var options = ConfigurationOptions.Parse("127.0.0.1:6379");
            var options = ConfigurationOptions.Parse(serverIP);
            options.AllowAdmin = true;


            using (ConnectionMultiplexer connOption = ConnectionMultiplexer.Connect(options))
            {
                using (ConnectionMultiplexer conn = ConnectionMultiplexer.Connect(connect))
                {
                    //連接到哪些Redis DataBase
                    EndPoint[] endpoints = conn.GetEndPoints();

                    var db = conn.GetDatabase();
                    var server = conn.GetServer(endpoints.First());

                    //取得所有Key                
                    foreach (var key in server.Keys())
                    {
                        Console.WriteLine(key);
                    }
                    IEnumerable<string> keys = server.Keys().Cast<string>();


                    //取得單一key資料
                    var scan = server.Keys(pattern: "Migration_Category_6");
                    foreach(var key in scan)
                    {
                        Console.WriteLine("單一Key值 : {0}",key);
                    }
                    string filterKey = scan.FirstOrDefault();


                    //ping Server時間
                    TimeSpan time= server.Ping();
                    double timeTrans = time.TotalSeconds;
                    //DateTime transTime = (new DateTime(1970, 1, 1)).AddSeconds(Convert.ToInt32(timeTrans));

                    var redisServerInfo = server.Info();

                    //取得Server 資訊
                    Dictionary<string, Dictionary<string, string>> infoMation = new Dictionary<string, Dictionary<string, string>>();

                    foreach (var info in server.Info())
                    {
                        var sub = new Dictionary<string, string>();
                        foreach (var detail in info)
                        {
                            sub.Add(detail.Key, detail.Value);
                        }
                        infoMation.Add(info.Key, sub);
                    }

                    //string SerializeInfoTest = JsonConvert.SerializeObject(redisServerInfo);
                    string SerializeInfo = JsonConvert.SerializeObject(infoMation);

                    Console.WriteLine(SerializeInfo);

                    //有多少Cache 在 Redis 裡面
                    long size = server.DatabaseSize();

                    //Get summary statics associates with this server
                    var statist = server.GetCounters();

                    //取得伺服器上指令查詢超過指定執行時間紀錄
                    var logs = server.SlowlogGet();
                    foreach(var log in logs)
                    {
                        Console.WriteLine("LOG : {0}",log);
                    }


                    #region Example LuaScript
                        //const string Script = "redis.call('set', @key, @value)";

                        //using (ConnectionMultiplexer conn = /* init code */)
                        //{
                        //    var db = conn.GetDatabase(0);

                        //    var prepared = LuaScript.Prepare(Script);
                        //    db.ScriptEvaluate(prepared, new { key = (RedisKey)"mykey", value = 123 });
                        //}
                    #endregion Example LuaScript

                    //可能(" ")裡面可以下Lua 指令
                    //db.ScriptEvaluate(LuaScript.Prepare(""));
                    string Luascript1 = "redis.call('set', @key, @value)";
                    string Luascript2 = "redis.call('get', Migration_Category_1)";
                    var serverInfo = LuaScript.Prepare(Luascript2);

                    string str_key1 = "Migration_Category_6";
                    //string str_key2 = "Migration_Category_6049";  //error
                    var Increment_key1 = db.StringIncrement(str_key1);
                    //var Increment_key2 = db.StringIncrement(str_key2); //error

                    byte[] b_key1 = Encoding.UTF8.GetBytes(str_key1);
                    //byte[] b_key2 = new byte[] { Convert.ToByte(str_key2) };
                    var bytesKey1 = db.StringIncrement(b_key1);
                    //db.StringIncrement(b_key2);
                    
                    //取得隨機的Key 值
                    string someKey = db.KeyRandom();

                    //新增 key & Value ，Key:可以是string 或 Byte ;Value:可以是Int32、Int64、Double、Boolean
                    db.StringSet("mykey", "myvalue");
                    db.StringSet("mykey1", 123);
                    db.StringSet("mykey2", 123.123);
                    db.StringSet("mykey3", true);

                    //刪除Key
                    db.KeyDelete("mykey2");
                    double getMykey2 = (double)db.StringGet("mykey2");//this is zero
                    
                    //刪除Key
                    db.KeyDelete("mykey");
                    var value0 = db.StringGet("mykey");
                    bool isNil = value0.IsNull; //this is true

                    //刪除Key
                    //提供Nullable<T>支援
                    db.KeyDelete("mykey1");
                    var value1 = (int?)db.StringGet("mykey1"); //be haves as you would expect

                }                    
            }
        }

    }
}
