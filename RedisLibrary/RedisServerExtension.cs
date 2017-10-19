using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Net;

namespace RedisLibrary
{
    public class RedisServerExtension
    {
        private static string connectString { get; set; }
        private string serverIP { get; set; }

        private ConfigurationOptions option;

        private ConnectionMultiplexer _connect;

        private IDatabase db;

        private IServer server;

        public RedisServerExtension(string connectionString, string IP)
        {
            connectString = connectionString;

            serverIP = IP;

            option = ConfigurationOptions.Parse(serverIP);
            option.AllowAdmin = true;

            _connect = ConnectionMultiplexer.Connect(option);
            _connect = ConnectionMultiplexer.Connect(connectionString);

            EndPoint[] endpoints = _connect.GetEndPoints();

            db = _connect.GetDatabase();
            server = _connect.GetServer(endpoints.First());
        }

        //解構子，釋放連線資源，Redis斷線
        ~RedisServerExtension()
        {
            _connect.Dispose();
        }

        /// <summary>
        /// 取得Server 資訊
        /// </summary>
        /// <returns></returns>
        public string GetServerInfo()
        {
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

            string serializeInfo = JsonConvert.SerializeObject(infoMation);

            return serializeInfo;
        }

        /// <summary>
        /// 取得所有KEY
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllKey()
        {
            List<string> keys = new List<string>();

            foreach (var key in server.Keys())
            {
                keys.Add(key.ToString());
            }
            return keys;
        }

        /// <summary>
        /// 取得單一KEY
        /// </summary>
        /// <param name="keyName">key名稱</param>
        /// <returns>key名稱</returns>
        public IEnumerable<string> GetFilterKey(string keyName)
        {
            var keys = server.Keys(pattern: keyName);

            List<string> keyList = new List<string>();

            foreach (var key in keys)
            {
                keyList.Add(key.ToString());
            }
            return keyList;
        }

        /// <summary>
        /// 取得Server上Cache總數
        /// </summary>
        /// <returns>Cache總數</returns>
        public long GetCacheTotalNumber()
        {
            return server.DatabaseSize();
        }

        /// <summary>
        /// Get summary statics associates with this server
        /// </summary>
        /// <returns>statics</returns>
        public ServerCounters GetServerStatic()
        {
            return server.GetCounters();
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="keyName">keyName</param>
        /// <returns>value</returns>
        public string GetValue(string keyName)
        {
            return db.StringGet(keyName);
        }

        /// <summary>
        /// Gets the value memory.
        /// </summary>
        /// <param name="keyName">keyName</param>
        /// <returns>byteMemory</returns>
        public long GetValueMemory(string keyName)
        {
            var value = db.StringGet(keyName);

            byte[] byteArray = System.Text.Encoding.Default.GetBytes(value);
            long memory = byteArray.LongLength;
            return memory;
        }

        /// <summary>
        /// Deletes the key.
        /// </summary>
        /// <param name="keyName">keyName</param>
        /// <returns>Is Success</returns>
        public bool DeleteKey(string keyName)
        {
            return db.KeyDelete(keyName);
        }

        /// <summary>
        /// CreateKeyAndValue
        /// </summary>
        /// <param name="keyName">keyName</param>
        /// <param name="value">value</param>
        /// <returns>Is Success</returns>
        public bool CreateKeyAndValue(string keyName,string value,TimeSpan expireTime)
        {
            return db.StringSet(keyName, value, expireTime);
            
        }

        /// <summary>
        /// Sets the key expire time.
        /// </summary>
        /// <param name="keyName">keyName</param>
        /// <param name="expire">expireTime</param>
        /// <returns>Is Success</returns>
        public bool SetKeyExpireTime(string keyName,TimeSpan expire)
        {
            return db.KeyExpire(keyName, expire);
        }

        /// <summary>
        /// Key 是否存在
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public bool KeyExisted(string keyName)
        {
            return db.KeyExists(keyName);
        }

       
    }
}
