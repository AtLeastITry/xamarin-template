﻿namespace Example.Mobile.Infrastructure.Serialization
{
    public interface IEventSerializer
    {
        string Serialize<T>(T data);
    }
}
