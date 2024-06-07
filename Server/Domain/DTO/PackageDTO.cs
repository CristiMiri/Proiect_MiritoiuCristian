using System;

namespace Server.Domain.DTO
{
    internal class PackageDTO
    {
        public bool Result { get;  set; }
        public string Message { get;  set; }
        public object Data { get;  set; }

        // Default constructor made private to enforce the use of the builder
        private PackageDTO() { }


        public PackageDTO (bool result, string message, object data)
        {
            Result = result;
            Message = message;
            Data = data;
        }
        // Builder class
        public class Builder
        {
            private readonly PackageDTO _packageDTO;

            public Builder()
            {
                _packageDTO = new PackageDTO();
            }

            public Builder SetResult(bool result)
            {
                _packageDTO.Result = result;
                return this;
            }

            public Builder SetMessage(string message)
            {
                _packageDTO.Message = message;
                return this;
            }

            public Builder SetData(object data)
            {
                _packageDTO.Data = data;
                return this;
            }

            public PackageDTO Build()
            {
                return _packageDTO;
            }
        }
    }
}
