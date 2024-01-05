using Core.Entity;
using Core.Entity.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public User()
        {
            PointsJson = "{}";
        }


        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
        public string PointsJson { get; set; }

        [NotMapped]
        public Dictionary<string, int> Points
        {
            get => JsonConvert.DeserializeObject<Dictionary<string, int>>(PointsJson);
            set => PointsJson = JsonConvert.SerializeObject(value);
        }
    }
}
