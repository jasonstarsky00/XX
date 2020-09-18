using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Collection
{
    /// <summary>
    /// 采集任务安排类
    /// </summary>
    public class CollectionRegistry: Registry
    {
        public CollectionRegistry()
        {
            // 安排任务运行一次，由一个特定的时间间隔延迟。
            Schedule<CollectionJob>().ToRunOnceIn(5).Seconds();
        }
    }
}