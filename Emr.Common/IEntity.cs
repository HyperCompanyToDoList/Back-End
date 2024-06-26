﻿namespace Emr.Common;

public interface IEntity<TKey> where TKey : struct
{
    TKey Id { get; set; }
}
