using System;

namespace AgileZenApi.Models
{
    public class Task
    {
        public int Id { get; set; }

        /// <summary>
        /// Definition of the task
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Status of the task
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The creation time of the task
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
