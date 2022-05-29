namespace Chapter08.Activities.Activity01
{
    public record ApiResult<T>
    {
        public int Count { get; set; }

        public string Next { get; set; }

        public string Previous { get; set; }

        public T Data { get; set; }
    }
}