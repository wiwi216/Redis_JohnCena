using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using RedisLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis_JohnCena.DataCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "127.0.0.1:6379,allowAdmin=true,abortConnect=false,syncTimeout=3000";
            var IP = "127.0.0.1:6379";

            RedisServerExtension RedisServerExtension = new RedisServerExtension(connectionString, IP);
            var info = RedisServerExtension.GetServerInfo();

            MongoClient _client = new MongoClient("mongodb://localhost");
            var db = _client.GetDatabase("RawData");

            var collection = db.GetCollection<RedisInfo>("RedisInfo");

            var document = BsonSerializer.Deserialize<RedisInfo>(info);
            collection.InsertOne(document);


            var info = "{"Server":{"redis_version":"3.0.503","redis_git_sha1":"00000000","redis_git_dirty":"0","redis_build_id":"d14575c6134f877","redis_mode":"standalone","os":"Windows","arch_bits":"64","multiplexing_api":"WinSock_IOCP","process_id":"12592","run_id":"87530e746ecdd15768a6514d72f8645da1386854","tcp_port":"6379","uptime_in_seconds":"95836","uptime_in_days":"1","hz":"10","lru_clock":"15223750","config_file":""},"Clients":{"connected_clients":"5","client_longest_output_list":"0","client_biggest_input_buf":"0","blocked_clients":"0"},"Memory":{"used_memory":"827328","used_memory_human":"807.94K","used_memory_rss":"789680","used_memory_peak":"2841296","used_memory_peak_human":"2.71M","used_memory_lua":"36864","mem_fragmentation_ratio":"0.95","mem_allocator":"jemalloc - 3.6.0"},"Persistence":{"loading":"0","rdb_changes_since_last_save":"0","rdb_bgsave_in_progress":"0","rdb_last_save_time":"1508312129","rdb_last_bgsave_status":"ok","rdb_last_bgsave_time_sec":"0","rdb_current_bgsave_time_sec":" - 1","aof_enabled":"0","aof_rewrite_in_progress":"0","aof_rewrite_scheduled":"0","aof_last_rewrite_time_sec":" - 1","aof_current_rewrite_time_sec":" - 1","aof_last_bgrewrite_status":"ok","aof_last_write_status":"ok"},"Stats":{"total_connections_received":"34","total_commands_processed":"4503","instantaneous_ops_per_sec":"18","total_net_input_bytes":"1837409","total_net_output_bytes":"3589518","instantaneous_input_kbps":"0.64","instantaneous_output_kbps":"3.02","rejected_connections":"0","sync_full":"0","sync_partial_ok":"0","sync_partial_err":"0","expired_keys":"96","evicted_keys":"0","keyspace_hits":"209","keyspace_misses":"96","pubsub_channels":"1","pubsub_patterns":"0","latest_fork_usec":"22910","migrate_cached_sockets":"0"},"Replication":{"role":"master","connected_slaves":"0","master_repl_offset":"0","repl_backlog_active":"0","repl_backlog_size":"1048576","repl_backlog_first_byte_offset":"0","repl_backlog_histlen":"0"},"CPU":{"used_cpu_sys":"0.20","used_cpu_user":"0.27","used_cpu_sys_children":"0.00","used_cpu_user_children":"0.00"},"Cluster":{"cluster_enabled":"0"},"Keyspace":{"db0":"keys = 25,expires = 0,avg_ttl = 0"}}"
             var document = BsonSerializer.Deserialize<RedisInfo>(info);
        }
    }


    public class RedisInfo
    {
        public Server Server { get; set; }
        public Clients Clients { get; set; }
        public Memory Memory { get; set; }
        public Persistence Persistence { get; set; }
        public Stats Stats { get; set; }
        public Replication Replication { get; set; }
        public CPU CPU { get; set; }
        public Cluster Cluster { get; set; }
        public Keyspace Keyspace { get; set; }
        public DateTime CollectTime { get; set; } = DateTime.Now;
    }

    public class Server
    {
        public string redis_version { get; set; }
        public string redis_git_sha1 { get; set; }
        public string redis_git_dirty { get; set; }
        public string redis_build_id { get; set; }
        public string redis_mode { get; set; }
        public string os { get; set; }
        public string arch_bits { get; set; }
        public string multiplexing_api { get; set; }
        public string process_id { get; set; }
        public string run_id { get; set; }
        public string tcp_port { get; set; }
        public string uptime_in_seconds { get; set; }
        public string uptime_in_days { get; set; }
        public string hz { get; set; }
        public string lru_clock { get; set; }
        public string config_file { get; set; }
    }

    public class Clients
    {
        public string connected_clients { get; set; }
        public string client_longest_output_list { get; set; }
        public string client_biggest_input_buf { get; set; }
        public string blocked_clients { get; set; }
    }

    public class Memory
    {
        public string used_memory { get; set; }
        public string used_memory_human { get; set; }
        public string used_memory_rss { get; set; }
        public string used_memory_peak { get; set; }
        public string used_memory_peak_human { get; set; }
        public string used_memory_lua { get; set; }
        public string mem_fragmentation_ratio { get; set; }
        public string mem_allocator { get; set; }
    }

    public class Persistence
    {
        public string loading { get; set; }
        public string rdb_changes_since_last_save { get; set; }
        public string rdb_bgsave_in_progress { get; set; }
        public string rdb_last_save_time { get; set; }
        public string rdb_last_bgsave_status { get; set; }
        public string rdb_last_bgsave_time_sec { get; set; }
        public string rdb_current_bgsave_time_sec { get; set; }
        public string aof_enabled { get; set; }
        public string aof_rewrite_in_progress { get; set; }
        public string aof_rewrite_scheduled { get; set; }
        public string aof_last_rewrite_time_sec { get; set; }
        public string aof_current_rewrite_time_sec { get; set; }
        public string aof_last_bgrewrite_status { get; set; }
        public string aof_last_write_status { get; set; }
    }

    public class Stats
    {
        public string total_connections_received { get; set; }
        public string total_commands_processed { get; set; }
        public string instantaneous_ops_per_sec { get; set; }
        public string total_net_input_bytes { get; set; }
        public string total_net_output_bytes { get; set; }
        public string instantaneous_input_kbps { get; set; }
        public string instantaneous_output_kbps { get; set; }
        public string rejected_connections { get; set; }
        public string sync_full { get; set; }
        public string sync_partial_ok { get; set; }
        public string sync_partial_err { get; set; }
        public string expired_keys { get; set; }
        public string evicted_keys { get; set; }
        public string keyspace_hits { get; set; }
        public string keyspace_misses { get; set; }
        public string pubsub_channels { get; set; }
        public string pubsub_patterns { get; set; }
        public string latest_fork_usec { get; set; }
        public string migrate_cached_sockets { get; set; }
    }

    public class Replication
    {
        public string role { get; set; }
        public string connected_slaves { get; set; }
        public string master_repl_offset { get; set; }
        public string repl_backlog_active { get; set; }
        public string repl_backlog_size { get; set; }
        public string repl_backlog_first_byte_offset { get; set; }
        public string repl_backlog_histlen { get; set; }
    }

    public class CPU
    {
        public string used_cpu_sys { get; set; }
        public string used_cpu_user { get; set; }
        public string used_cpu_sys_children { get; set; }
        public string used_cpu_user_children { get; set; }
    }

    public class Cluster
    {
        public string cluster_enabled { get; set; }
    }

    public class Keyspace
    {
        public string db0 { get; set; }
    }

}
