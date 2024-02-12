using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class ImageViewModel
    {
        public string Name { get; set; }

        public string? Title { get; set; }

        public string? Alt { get; set; }

        public string HtmlId { get; set; }
        public string HtmlClass { get; set; }
    }
}