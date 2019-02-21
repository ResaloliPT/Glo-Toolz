using System;
using System.Net;

namespace GloToolz.Integration.GitKraken.Entities.API
{
    internal abstract class GKEntity<TGKEntity> : GKEntity
    {
        public static TGKEntity CreateEntity(HttpListenerRequest responseMessage)
        {
            throw new NotImplementedException("Must not call this method!");
        }
    }
}