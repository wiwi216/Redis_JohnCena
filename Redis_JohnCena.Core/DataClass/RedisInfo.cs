using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis_JohnCena.Core.DataClass
{
    public class RedisInfo
    {
        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }
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
