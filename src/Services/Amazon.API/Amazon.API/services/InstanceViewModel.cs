using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace Amazon.API.services
{
    public class InstanceViewModel
    {
        public string Name { get; set; }
        public string Subtitle { get; set; }

        public string InstanceId { get; set; }

        public string IsOnline { get; set; }

        public DateTime Timetstarted { get; set; }
    }
}