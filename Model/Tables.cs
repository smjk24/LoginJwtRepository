using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Model
{
    public class Tables
    {
        //pattishow
    }
    public class Account
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }
    }
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<State> StateCollection { get; set; }
    }
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country GetCountry { get; set; }
    }
}
