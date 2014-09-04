using System;
using System.Collections.Generic;

namespace AgileZenApi.Models
{
    public class Story
    {
        public int Id { get; set; }

        /// <summary>
        /// Reason story is blocked
        /// </summary>
        public string BlockedReason { get; set; }

        /// <summary>
        /// The color of the story
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The details of the story in Markdown format
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// The title of the ticket
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The Agile Zen project that the story belongs to
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// The current phase of the story
        /// </summary>
        public Phase Phase { get; set; }

        /// <summary>
        /// The creator of the story
        /// </summary>
        public User Creator { get; set; }

        /// <summary>
        /// The owner of the story
        /// </summary>
        public User Owner { get; set; }

        /// <summary>
        /// The size of the story
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Status of the story
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The priority of the story
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        /// The deadline of the story
        /// </summary>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Tags associated with the story
        /// </summary>
        public List<Tag> Tags { get; set; }

        public List<Task> Tasks { get; set; }

        /// <summary>
        /// The different steps the story have been in
        /// </summary>
        //public List<Step> Steps { get; set; }
    }
}
