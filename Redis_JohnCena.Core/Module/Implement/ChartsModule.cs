using Newtonsoft.Json;
using Redis_JohnCena.Core.DataClass;
using Redis_JohnCena.Core.Module.Interface;
using Redis_JohnCena.Models;
using RedisLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis_JohnCena.Core.Module.Implement
{
    public class ChartsModule : IChartsModule
    {
        /// <summary>
        /// 取得Redis Server資料
        /// </summary>
        /// <returns></returns>
        public List<RedisInfo> GetRedisInfoData()
        {
            //RedisServerExtension redis = new RedisServerExtension("127.0.0.1:6379,allowAdmin=true,abortConnect=false,syncTimeout=3000", "127.0.0.1:6379");
            //var info = redis.GetServerInfo();

            string collection1 = "{\"Server\":{\"redis_version\":\"3.2.100\",\"redis_git_sha1\":\"00000000\",\"redis_git_dirty\":\"0\",\"redis_build_id\":\"dd26f1f93c5130ee\",\"redis_mode\":\"standalone\",\"os\":\"Windows\",\"arch_bits\":\"64\",\"multiplexing_api\":\"WinSock_IOCP\",\"process_id\":\"13240\",\"run_id\":\"aab7020d1cc6003c0185f99bbb61c0730cb5ad21\",\"tcp_port\":\"6379\",\"uptime_in_seconds\":\"517\",\"uptime_in_days\":\"0\",\"hz\":\"10\",\"lru_clock\":\"15248349\",\"executable\":\"C:\\\\Users\\\\user\\\\Downloads\\\\redis\\\\redis-server.exe\",\"config_file\":\"\"},\"Clients\":{\"connected_clients\":\"4\",\"client_longest_output_list\":\"0\",\"client_biggest_input_buf\":\"0\",\"blocked_clients\":\"0\"},\"Memory\":{\"used_memory\":\"607540\",\"used_memory_human\":\"735.10K\",\"used_memory_rss\":\"714960\",\"used_memory_rss_human\":\"698.20K\",\"used_memory_peak\":\"946272\",\"used_memory_peak_human\":\"924.09K\",\"total_system_memory\":\"0\",\"total_system_memory_human\":\"0B\",\"used_memory_lua\":\"37888\",\"used_memory_lua_human\":\"37.00K\",\"maxmemory\":\"0\",\"maxmemory_human\":\"0B\",\"maxmemory_policy\":\"noeviction\",\"mem_fragmentation_ratio\":\"0.95\",\"mem_allocator\":\"jemalloc-3.6.0\"},\"Persistence\":{\"loading\":\"0\",\"rdb_changes_since_last_save\":\"0\",\"rdb_bgsave_in_progress\":\"0\",\"rdb_last_save_time\":\"1508420056\",\"rdb_last_bgsave_status\":\"ok\",\"rdb_last_bgsave_time_sec\":\"-1\",\"rdb_current_bgsave_time_sec\":\"-1\",\"aof_enabled\":\"0\",\"aof_rewrite_in_progress\":\"0\",\"aof_rewrite_scheduled\":\"0\",\"aof_last_rewrite_time_sec\":\"-1\",\"aof_current_rewrite_time_sec\":\"-1\",\"aof_last_bgrewrite_status\":\"ok\",\"aof_last_write_status\":\"ok\"},\"Stats\":{\"total_connections_received\":\"16\",\"total_commands_processed\":\"13\",\"instantaneous_ops_per_sec\":\"0\",\"total_net_input_bytes\":\"3246\",\"total_net_output_bytes\":\"16226\",\"instantaneous_input_kbps\":\"0.00\",\"instantaneous_output_kbps\":\"0.00\",\"rejected_connections\":\"0\",\"sync_full\":\"0\",\"sync_partial_ok\":\"0\",\"sync_partial_err\":\"0\",\"expired_keys\":\"0\",\"evicted_keys\":\"0\",\"keyspace_hits\":\"0\",\"keyspace_misses\":\"12\",\"pubsub_channels\":\"1\",\"pubsub_patterns\":\"0\",\"latest_fork_usec\":\"0\",\"migrate_cached_sockets\":\"0\"},\"Replication\":{\"role\":\"master\",\"connected_slaves\":\"0\",\"master_repl_offset\":\"0\",\"repl_backlog_active\":\"0\",\"repl_backlog_size\":\"1048576\",\"repl_backlog_first_byte_offset\":\"0\",\"repl_backlog_histlen\":\"0\"},\"CPU\":{\"used_cpu_sys\":\"0.08\",\"used_cpu_user\":\"0.09\",\"used_cpu_sys_children\":\"0.00\",\"used_cpu_user_children\":\"0.00\"},\"Cluster\":{\"cluster_enabled\":\"0\"},\"Keyspace\":{\"db0\":\"keys=6,expires=0,avg_ttl=0\"}}";
            string collection2 = "{\"Server\":{\"redis_version\":\"3.2.100\",\"redis_git_sha1\":\"00000000\",\"redis_git_dirty\":\"0\",\"redis_build_id\":\"dd26f1f93c5130ee\",\"redis_mode\":\"standalone\",\"os\":\"Windows\",\"arch_bits\":\"64\",\"multiplexing_api\":\"WinSock_IOCP\",\"process_id\":\"13240\",\"run_id\":\"aab7020d1cc6003c0185f99bbb61c0730cb5ad21\",\"tcp_port\":\"6379\",\"uptime_in_seconds\":\"517\",\"uptime_in_days\":\"0\",\"hz\":\"10\",\"lru_clock\":\"15248349\",\"executable\":\"C:\\\\Users\\\\user\\\\Downloads\\\\redis\\\\redis-server.exe\",\"config_file\":\"\"},\"Clients\":{\"connected_clients\":\"4\",\"client_longest_output_list\":\"0\",\"client_biggest_input_buf\":\"0\",\"blocked_clients\":\"0\"},\"Memory\":{\"used_memory\":\"752744\",\"used_memory_human\":\"735.10K\",\"used_memory_rss\":\"714960\",\"used_memory_rss_human\":\"698.20K\",\"used_memory_peak\":\"946272\",\"used_memory_peak_human\":\"924.09K\",\"total_system_memory\":\"0\",\"total_system_memory_human\":\"0B\",\"used_memory_lua\":\"37888\",\"used_memory_lua_human\":\"37.00K\",\"maxmemory\":\"0\",\"maxmemory_human\":\"0B\",\"maxmemory_policy\":\"noeviction\",\"mem_fragmentation_ratio\":\"0.95\",\"mem_allocator\":\"jemalloc-3.6.0\"},\"Persistence\":{\"loading\":\"0\",\"rdb_changes_since_last_save\":\"0\",\"rdb_bgsave_in_progress\":\"0\",\"rdb_last_save_time\":\"1508420056\",\"rdb_last_bgsave_status\":\"ok\",\"rdb_last_bgsave_time_sec\":\"-1\",\"rdb_current_bgsave_time_sec\":\"-1\",\"aof_enabled\":\"0\",\"aof_rewrite_in_progress\":\"0\",\"aof_rewrite_scheduled\":\"0\",\"aof_last_rewrite_time_sec\":\"-1\",\"aof_current_rewrite_time_sec\":\"-1\",\"aof_last_bgrewrite_status\":\"ok\",\"aof_last_write_status\":\"ok\"},\"Stats\":{\"total_connections_received\":\"16\",\"total_commands_processed\":\"16\",\"instantaneous_ops_per_sec\":\"0.27\",\"total_net_input_bytes\":\"3246\",\"total_net_output_bytes\":\"16226\",\"instantaneous_input_kbps\":\"0.00\",\"instantaneous_output_kbps\":\"0.00\",\"rejected_connections\":\"0\",\"sync_full\":\"0\",\"sync_partial_ok\":\"0\",\"sync_partial_err\":\"0\",\"expired_keys\":\"0\",\"evicted_keys\":\"0\",\"keyspace_hits\":\"0\",\"keyspace_misses\":\"12\",\"pubsub_channels\":\"1\",\"pubsub_patterns\":\"0\",\"latest_fork_usec\":\"0\",\"migrate_cached_sockets\":\"0\"},\"Replication\":{\"role\":\"master\",\"connected_slaves\":\"0\",\"master_repl_offset\":\"0\",\"repl_backlog_active\":\"0\",\"repl_backlog_size\":\"1048576\",\"repl_backlog_first_byte_offset\":\"0\",\"repl_backlog_histlen\":\"0\"},\"CPU\":{\"used_cpu_sys\":\"0.18\",\"used_cpu_user\":\"0.09\",\"used_cpu_sys_children\":\"0.00\",\"used_cpu_user_children\":\"0.00\"},\"Cluster\":{\"cluster_enabled\":\"0\"},\"Keyspace\":{\"db0\":\"keys=6,expires=0,avg_ttl=0\"}}";
            string collection3 = "{\"Server\":{\"redis_version\":\"3.2.100\",\"redis_git_sha1\":\"00000000\",\"redis_git_dirty\":\"0\",\"redis_build_id\":\"dd26f1f93c5130ee\",\"redis_mode\":\"standalone\",\"os\":\"Windows\",\"arch_bits\":\"64\",\"multiplexing_api\":\"WinSock_IOCP\",\"process_id\":\"13240\",\"run_id\":\"aab7020d1cc6003c0185f99bbb61c0730cb5ad21\",\"tcp_port\":\"6379\",\"uptime_in_seconds\":\"517\",\"uptime_in_days\":\"0\",\"hz\":\"10\",\"lru_clock\":\"15248349\",\"executable\":\"C:\\\\Users\\\\user\\\\Downloads\\\\redis\\\\redis-server.exe\",\"config_file\":\"\"},\"Clients\":{\"connected_clients\":\"4\",\"client_longest_output_list\":\"0\",\"client_biggest_input_buf\":\"0\",\"blocked_clients\":\"0\"},\"Memory\":{\"used_memory\":\"112749\",\"used_memory_human\":\"735.10K\",\"used_memory_rss\":\"714960\",\"used_memory_rss_human\":\"698.20K\",\"used_memory_peak\":\"946272\",\"used_memory_peak_human\":\"924.09K\",\"total_system_memory\":\"0\",\"total_system_memory_human\":\"0B\",\"used_memory_lua\":\"37888\",\"used_memory_lua_human\":\"37.00K\",\"maxmemory\":\"0\",\"maxmemory_human\":\"0B\",\"maxmemory_policy\":\"noeviction\",\"mem_fragmentation_ratio\":\"0.95\",\"mem_allocator\":\"jemalloc-3.6.0\"},\"Persistence\":{\"loading\":\"0\",\"rdb_changes_since_last_save\":\"0\",\"rdb_bgsave_in_progress\":\"0\",\"rdb_last_save_time\":\"1508420056\",\"rdb_last_bgsave_status\":\"ok\",\"rdb_last_bgsave_time_sec\":\"-1\",\"rdb_current_bgsave_time_sec\":\"-1\",\"aof_enabled\":\"0\",\"aof_rewrite_in_progress\":\"0\",\"aof_rewrite_scheduled\":\"0\",\"aof_last_rewrite_time_sec\":\"-1\",\"aof_current_rewrite_time_sec\":\"-1\",\"aof_last_bgrewrite_status\":\"ok\",\"aof_last_write_status\":\"ok\"},\"Stats\":{\"total_connections_received\":\"16\",\"total_commands_processed\":\"25\",\"instantaneous_ops_per_sec\":\"0.23\",\"total_net_input_bytes\":\"3246\",\"total_net_output_bytes\":\"16226\",\"instantaneous_input_kbps\":\"0.00\",\"instantaneous_output_kbps\":\"0.00\",\"rejected_connections\":\"0\",\"sync_full\":\"0\",\"sync_partial_ok\":\"0\",\"sync_partial_err\":\"0\",\"expired_keys\":\"0\",\"evicted_keys\":\"0\",\"keyspace_hits\":\"0\",\"keyspace_misses\":\"12\",\"pubsub_channels\":\"1\",\"pubsub_patterns\":\"0\",\"latest_fork_usec\":\"0\",\"migrate_cached_sockets\":\"0\"},\"Replication\":{\"role\":\"master\",\"connected_slaves\":\"0\",\"master_repl_offset\":\"0\",\"repl_backlog_active\":\"0\",\"repl_backlog_size\":\"1048576\",\"repl_backlog_first_byte_offset\":\"0\",\"repl_backlog_histlen\":\"0\"},\"CPU\":{\"used_cpu_sys\":\"0.13\",\"used_cpu_user\":\"0.09\",\"used_cpu_sys_children\":\"0.00\",\"used_cpu_user_children\":\"0.00\"},\"Cluster\":{\"cluster_enabled\":\"0\"},\"Keyspace\":{\"db0\":\"keys=6,expires=0,avg_ttl=0\"}}";
            string collection4 = "{\"Server\":{\"redis_version\":\"3.2.100\",\"redis_git_sha1\":\"00000000\",\"redis_git_dirty\":\"0\",\"redis_build_id\":\"dd26f1f93c5130ee\",\"redis_mode\":\"standalone\",\"os\":\"Windows\",\"arch_bits\":\"64\",\"multiplexing_api\":\"WinSock_IOCP\",\"process_id\":\"13240\",\"run_id\":\"aab7020d1cc6003c0185f99bbb61c0730cb5ad21\",\"tcp_port\":\"6379\",\"uptime_in_seconds\":\"517\",\"uptime_in_days\":\"0\",\"hz\":\"10\",\"lru_clock\":\"15248349\",\"executable\":\"C:\\\\Users\\\\user\\\\Downloads\\\\redis\\\\redis-server.exe\",\"config_file\":\"\"},\"Clients\":{\"connected_clients\":\"4\",\"client_longest_output_list\":\"0\",\"client_biggest_input_buf\":\"0\",\"blocked_clients\":\"0\"},\"Memory\":{\"used_memory\":\"98750\",\"used_memory_human\":\"735.10K\",\"used_memory_rss\":\"714960\",\"used_memory_rss_human\":\"698.20K\",\"used_memory_peak\":\"946272\",\"used_memory_peak_human\":\"924.09K\",\"total_system_memory\":\"0\",\"total_system_memory_human\":\"0B\",\"used_memory_lua\":\"37888\",\"used_memory_lua_human\":\"37.00K\",\"maxmemory\":\"0\",\"maxmemory_human\":\"0B\",\"maxmemory_policy\":\"noeviction\",\"mem_fragmentation_ratio\":\"0.95\",\"mem_allocator\":\"jemalloc-3.6.0\"},\"Persistence\":{\"loading\":\"0\",\"rdb_changes_since_last_save\":\"0\",\"rdb_bgsave_in_progress\":\"0\",\"rdb_last_save_time\":\"1508420056\",\"rdb_last_bgsave_status\":\"ok\",\"rdb_last_bgsave_time_sec\":\"-1\",\"rdb_current_bgsave_time_sec\":\"-1\",\"aof_enabled\":\"0\",\"aof_rewrite_in_progress\":\"0\",\"aof_rewrite_scheduled\":\"0\",\"aof_last_rewrite_time_sec\":\"-1\",\"aof_current_rewrite_time_sec\":\"-1\",\"aof_last_bgrewrite_status\":\"ok\",\"aof_last_write_status\":\"ok\"},\"Stats\":{\"total_connections_received\":\"16\",\"total_commands_processed\":\"57\",\"instantaneous_ops_per_sec\":\"0.11\",\"total_net_input_bytes\":\"3246\",\"total_net_output_bytes\":\"16226\",\"instantaneous_input_kbps\":\"0.00\",\"instantaneous_output_kbps\":\"0.00\",\"rejected_connections\":\"0\",\"sync_full\":\"0\",\"sync_partial_ok\":\"0\",\"sync_partial_err\":\"0\",\"expired_keys\":\"0\",\"evicted_keys\":\"0\",\"keyspace_hits\":\"0\",\"keyspace_misses\":\"12\",\"pubsub_channels\":\"1\",\"pubsub_patterns\":\"0\",\"latest_fork_usec\":\"0\",\"migrate_cached_sockets\":\"0\"},\"Replication\":{\"role\":\"master\",\"connected_slaves\":\"0\",\"master_repl_offset\":\"0\",\"repl_backlog_active\":\"0\",\"repl_backlog_size\":\"1048576\",\"repl_backlog_first_byte_offset\":\"0\",\"repl_backlog_histlen\":\"0\"},\"CPU\":{\"used_cpu_sys\":\"0.29\",\"used_cpu_user\":\"0.09\",\"used_cpu_sys_children\":\"0.00\",\"used_cpu_user_children\":\"0.00\"},\"Cluster\":{\"cluster_enabled\":\"0\"},\"Keyspace\":{\"db0\":\"keys=6,expires=0,avg_ttl=0\"}}";
            string collection5 = "{\"Server\":{\"redis_version\":\"3.2.100\",\"redis_git_sha1\":\"00000000\",\"redis_git_dirty\":\"0\",\"redis_build_id\":\"dd26f1f93c5130ee\",\"redis_mode\":\"standalone\",\"os\":\"Windows\",\"arch_bits\":\"64\",\"multiplexing_api\":\"WinSock_IOCP\",\"process_id\":\"13240\",\"run_id\":\"aab7020d1cc6003c0185f99bbb61c0730cb5ad21\",\"tcp_port\":\"6379\",\"uptime_in_seconds\":\"517\",\"uptime_in_days\":\"0\",\"hz\":\"10\",\"lru_clock\":\"15248349\",\"executable\":\"C:\\\\Users\\\\user\\\\Downloads\\\\redis\\\\redis-server.exe\",\"config_file\":\"\"},\"Clients\":{\"connected_clients\":\"4\",\"client_longest_output_list\":\"0\",\"client_biggest_input_buf\":\"0\",\"blocked_clients\":\"0\"},\"Memory\":{\"used_memory\":\"622710\",\"used_memory_human\":\"735.10K\",\"used_memory_rss\":\"714960\",\"used_memory_rss_human\":\"698.20K\",\"used_memory_peak\":\"946272\",\"used_memory_peak_human\":\"924.09K\",\"total_system_memory\":\"0\",\"total_system_memory_human\":\"0B\",\"used_memory_lua\":\"37888\",\"used_memory_lua_human\":\"37.00K\",\"maxmemory\":\"0\",\"maxmemory_human\":\"0B\",\"maxmemory_policy\":\"noeviction\",\"mem_fragmentation_ratio\":\"0.95\",\"mem_allocator\":\"jemalloc-3.6.0\"},\"Persistence\":{\"loading\":\"0\",\"rdb_changes_since_last_save\":\"0\",\"rdb_bgsave_in_progress\":\"0\",\"rdb_last_save_time\":\"1508420056\",\"rdb_last_bgsave_status\":\"ok\",\"rdb_last_bgsave_time_sec\":\"-1\",\"rdb_current_bgsave_time_sec\":\"-1\",\"aof_enabled\":\"0\",\"aof_rewrite_in_progress\":\"0\",\"aof_rewrite_scheduled\":\"0\",\"aof_last_rewrite_time_sec\":\"-1\",\"aof_current_rewrite_time_sec\":\"-1\",\"aof_last_bgrewrite_status\":\"ok\",\"aof_last_write_status\":\"ok\"},\"Stats\":{\"total_connections_received\":\"16\",\"total_commands_processed\":\"93\",\"instantaneous_ops_per_sec\":\"0.16\",\"total_net_input_bytes\":\"3246\",\"total_net_output_bytes\":\"16226\",\"instantaneous_input_kbps\":\"0.00\",\"instantaneous_output_kbps\":\"0.00\",\"rejected_connections\":\"0\",\"sync_full\":\"0\",\"sync_partial_ok\":\"0\",\"sync_partial_err\":\"0\",\"expired_keys\":\"0\",\"evicted_keys\":\"0\",\"keyspace_hits\":\"0\",\"keyspace_misses\":\"12\",\"pubsub_channels\":\"1\",\"pubsub_patterns\":\"0\",\"latest_fork_usec\":\"0\",\"migrate_cached_sockets\":\"0\"},\"Replication\":{\"role\":\"master\",\"connected_slaves\":\"0\",\"master_repl_offset\":\"0\",\"repl_backlog_active\":\"0\",\"repl_backlog_size\":\"1048576\",\"repl_backlog_first_byte_offset\":\"0\",\"repl_backlog_histlen\":\"0\"},\"CPU\":{\"used_cpu_sys\":\"0.50\",\"used_cpu_user\":\"0.09\",\"used_cpu_sys_children\":\"0.00\",\"used_cpu_user_children\":\"0.00\"},\"Cluster\":{\"cluster_enabled\":\"0\"},\"Keyspace\":{\"db0\":\"keys=6,expires=0,avg_ttl=0\"}}";
            string collection6 = "{\"Server\":{\"redis_version\":\"3.2.100\",\"redis_git_sha1\":\"00000000\",\"redis_git_dirty\":\"0\",\"redis_build_id\":\"dd26f1f93c5130ee\",\"redis_mode\":\"standalone\",\"os\":\"Windows\",\"arch_bits\":\"64\",\"multiplexing_api\":\"WinSock_IOCP\",\"process_id\":\"13240\",\"run_id\":\"aab7020d1cc6003c0185f99bbb61c0730cb5ad21\",\"tcp_port\":\"6379\",\"uptime_in_seconds\":\"517\",\"uptime_in_days\":\"0\",\"hz\":\"10\",\"lru_clock\":\"15248349\",\"executable\":\"C:\\\\Users\\\\user\\\\Downloads\\\\redis\\\\redis-server.exe\",\"config_file\":\"\"},\"Clients\":{\"connected_clients\":\"4\",\"client_longest_output_list\":\"0\",\"client_biggest_input_buf\":\"0\",\"blocked_clients\":\"0\"},\"Memory\":{\"used_memory\":\"752744\",\"used_memory_human\":\"735.10K\",\"used_memory_rss\":\"714960\",\"used_memory_rss_human\":\"698.20K\",\"used_memory_peak\":\"946272\",\"used_memory_peak_human\":\"924.09K\",\"total_system_memory\":\"0\",\"total_system_memory_human\":\"0B\",\"used_memory_lua\":\"37888\",\"used_memory_lua_human\":\"37.00K\",\"maxmemory\":\"0\",\"maxmemory_human\":\"0B\",\"maxmemory_policy\":\"noeviction\",\"mem_fragmentation_ratio\":\"0.95\",\"mem_allocator\":\"jemalloc-3.6.0\"},\"Persistence\":{\"loading\":\"0\",\"rdb_changes_since_last_save\":\"0\",\"rdb_bgsave_in_progress\":\"0\",\"rdb_last_save_time\":\"1508420056\",\"rdb_last_bgsave_status\":\"ok\",\"rdb_last_bgsave_time_sec\":\"-1\",\"rdb_current_bgsave_time_sec\":\"-1\",\"aof_enabled\":\"0\",\"aof_rewrite_in_progress\":\"0\",\"aof_rewrite_scheduled\":\"0\",\"aof_last_rewrite_time_sec\":\"-1\",\"aof_current_rewrite_time_sec\":\"-1\",\"aof_last_bgrewrite_status\":\"ok\",\"aof_last_write_status\":\"ok\"},\"Stats\":{\"total_connections_received\":\"16\",\"total_commands_processed\":\"93\",\"instantaneous_ops_per_sec\":\"0.20\",\"total_net_input_bytes\":\"3246\",\"total_net_output_bytes\":\"16226\",\"instantaneous_input_kbps\":\"0.00\",\"instantaneous_output_kbps\":\"0.00\",\"rejected_connections\":\"0\",\"sync_full\":\"0\",\"sync_partial_ok\":\"0\",\"sync_partial_err\":\"0\",\"expired_keys\":\"0\",\"evicted_keys\":\"0\",\"keyspace_hits\":\"0\",\"keyspace_misses\":\"12\",\"pubsub_channels\":\"1\",\"pubsub_patterns\":\"0\",\"latest_fork_usec\":\"0\",\"migrate_cached_sockets\":\"0\"},\"Replication\":{\"role\":\"master\",\"connected_slaves\":\"0\",\"master_repl_offset\":\"0\",\"repl_backlog_active\":\"0\",\"repl_backlog_size\":\"1048576\",\"repl_backlog_first_byte_offset\":\"0\",\"repl_backlog_histlen\":\"0\"},\"CPU\":{\"used_cpu_sys\":\"0.33\",\"used_cpu_user\":\"0.09\",\"used_cpu_sys_children\":\"0.00\",\"used_cpu_user_children\":\"0.00\"},\"Cluster\":{\"cluster_enabled\":\"0\"},\"Keyspace\":{\"db0\":\"keys=6,expires=0,avg_ttl=0\"}}";

            var redisInfo1 = JsonConvert.DeserializeObject<RedisInfo>(collection1);
            var redisInfo2 = JsonConvert.DeserializeObject<RedisInfo>(collection2);
            var redisInfo3 = JsonConvert.DeserializeObject<RedisInfo>(collection3);
            var redisInfo4 = JsonConvert.DeserializeObject<RedisInfo>(collection4);
            var redisInfo5 = JsonConvert.DeserializeObject<RedisInfo>(collection5);
            var redisInfo6 = JsonConvert.DeserializeObject<RedisInfo>(collection6);

            var list = new List<RedisInfo> { redisInfo1, redisInfo2, redisInfo3, redisInfo4, redisInfo5, redisInfo6 };

            return list;
        }

        /// <summary>
        /// 取得Redis CPU資訊
        /// </summary>
        /// <returns></returns>
        public CPUChart GetCPUInfo(List<RedisInfo> list)
        {
            var result = new CPUChart();

            result.Title = "CPU Usage";
            result.XAxisName = "Time";
            result.XAxisList = new List<string>
            {
                "00:00", "04:00", "08:00", "12:00", "16:00", "20:00"
            };
            result.YAxisName = "Byte";
            result.YAxisList = new List<string>
            {
                "10", "20", "30", "40", "50", "60", "70", "80", "90", "100"
            };
            //result.DataList = new List<decimal>
            //{
            //    81, 90, 96, 81, 86, 93, 90, 81, 90, 96, 81, 86, 93, 90, 100
            //};

            result.DataList = new List<decimal>();
            decimal accumulationBytes = 0;
            foreach (var info in list)
            {
                decimal usedBytes = Convert.ToDecimal(info.CPU.used_cpu_sys);
                decimal bytes = (usedBytes - accumulationBytes) / 60;
                result.DataList.Add(bytes);
            }

            return result;
        }

        /// <summary>
        /// 取得Redis Memory資訊
        /// </summary>
        /// <returns></returns>
        public MemoryChart GetMemoryInfo(List<RedisInfo> list)
        {
            var result = new MemoryChart();

            result.Title = "Memory Usage";
            result.XAxisName = "Time";
            result.XAxisList = new List<string>
            {
                "00:00", "04:00", "08:00", "12:00", "16:00", "20:00"
            };
            result.YAxisName = "Kilo Byte";
            result.YAxisList = new List<string>
            {
                "300", "600", "900", "1200", "1500"
            };
            //result.DataList = new List<decimal>
            //{
            //    1200, 1400, 1008, 1411, 1026, 1288, 1300, 800, 1100, 1000, 1118, 1322
            //};

            result.DataList = new List<decimal>();
            decimal accumulationBytes = 0;
            foreach (var info in list)
            {
                decimal usedBytes = Convert.ToDecimal(info.Memory.used_memory);
                decimal bytes = (usedBytes - accumulationBytes) / 1000; //Byte轉成Kb
                result.DataList.Add(bytes);
            }

            return result;
        }

        /// <summary>
        /// 取得Redis執行指令次數
        /// </summary>
        /// <returns></returns>
        public CommandProcessedChart GetCommandProcessedCount(List<RedisInfo> list)
        {
            var result = new CommandProcessedChart();

            result.Title = "Command Processed";
            result.XAxisName = "Time";
            result.XAxisList = new List<string>
            {
                "00:00", "04:00", "08:00", "12:00", "16:00", "20:00"
            };
            result.YAxisName = "Count";
            result.YAxisList = new List<string>
            {
                "300", "600", "900", "1200", "1500"
            };
            //result.DataList = new List<decimal>
            //{
            //    1200, 1400, 1008, 1411, 1026, 1288, 1300, 800, 1100, 1000, 1118, 1322
            //};

            result.DataList = new List<decimal>();
            decimal accumulationNumber = 0;
            foreach (var info in list)
            {
                decimal totalNumber = Convert.ToDecimal(info.Stats.total_commands_processed);
                decimal count = (totalNumber - accumulationNumber);
                result.DataList.Add(count);
            }

            return result;
        }

        /// <summary>
        /// 取得Redis ThroughPut Data
        /// </summary>
        /// <returns></returns>
        public ThroughputChart GetThroughPutData(List<RedisInfo> list)
        {
            var result = new ThroughputChart();

            result.Title = "Throughput";
            result.XAxisName = "Time";
            result.XAxisList = new List<string>
            {
                "00:00", "04:00", "08:00", "12:00", "16:00", "20:00"
            };
            result.YAxisName = "ops/sec";
            result.YAxisList = new List<string>
            {
                "300", "600", "900", "1200", "1500"
            };
            //result.DataList = new List<decimal>
            //{
            //    1200, 1400, 1008, 1411, 1026, 1288, 1300, 800, 1100, 1000, 1118, 1322
            //};

            result.DataList = new List<decimal>();
            foreach (var info in list)
            {
                decimal frequency = Convert.ToDecimal(info.Stats.instantaneous_ops_per_sec);
                result.DataList.Add(frequency);
            }

            return result;
        }
    }
}
