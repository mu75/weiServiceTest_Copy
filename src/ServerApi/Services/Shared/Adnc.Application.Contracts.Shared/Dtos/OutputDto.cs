﻿namespace Adnc.Application.Contracts.Shared.Dtos;

[Serializable]
public abstract class OutputDto : IOutputDto
{
    public virtual long Id { get; set; }
}