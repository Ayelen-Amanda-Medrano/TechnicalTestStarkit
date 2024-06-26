﻿using Starkit.Client.Api.Contracts.Enums;

namespace Starkit.Client.Domain.Entities;

public class Client
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
}
