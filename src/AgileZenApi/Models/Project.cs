using System;

namespace AgileZenApi.Models
{
    public class Project
    {
        /// <summary>
        /// The ID of the Agile Zen project
        /// </summary>
        public int Id { get; set; }

        public DateTime CreateTime { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
