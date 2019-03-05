using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RiskFirst.Hateoas.Models;

namespace SampleLink.Model
{
    public class Location: LinkContainer
    {
        public int Id { get; set; }
    }
}
