using System;
using Sekougi.MessagePack;

namespace Sekougi.Tarantool.Iproto.Requests
{
    public class DeleteRequest : RequestBase
    {
        public override CommandE Code => CommandE.Delete;

        protected override void SerializeBody(MessagePackWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}