using System;

namespace Chapter08.Client.Models
{
    public class ApiResult<T>
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public T results { get; set; }
    }

    public class Planet
    {
        public string name { get; set; }
        public string rotation_period { get; set; }
        public string orbital_period { get; set; }
        public string diameter { get; set; }
        public string climate { get; set; }
        public string gravity { get; set; }
        public string terrain { get; set; }
        public string surface_water { get; set; }
        public string population { get; set; }
        public string[] residents { get; set; }
        public string[] films { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }
}
