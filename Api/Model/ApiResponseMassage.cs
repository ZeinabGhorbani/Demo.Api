using System.Collections.Generic;
using System;

namespace Api.Model
{
    public class ApiResponseMassage<T>
    {
        public T Data { get; set; }
        public DateTime Time { get; private set; }

        public bool Success { get; private set; }
        public List<string> ErrorMessages { get; private set; }
        public ApiResponseMassage()
        {
            Time = DateTime.Now;
            Success = true;
            ErrorMessages = new List<string>();
        }
        public void AddError(string message)
        {
            Success = false;
            ErrorMessages.Add(message);
        }
    }
}
