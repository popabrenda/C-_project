using System;

namespace TripNetworking
{
    [Serializable]
    public class Request
    {
        public RequestType Type { get; set; }

        public Object Data { get; set; }

        private Request()
        {
        }
        
        public class Builder
        {
            private Request request = new Request();

            public Builder SetType(RequestType type)
            {
                request.Type = type;
                return this;
            }

            public Builder SetData(Object data)
            {
                request.Data = data;
                return this;
            }

            public Request Build()
            {
                return request;
            }
        }

        public override string ToString()
        {
            return "Request{" +
                   "type=" + Type +
                   ", data=" + Data +
                   '}';
        }
    }
}