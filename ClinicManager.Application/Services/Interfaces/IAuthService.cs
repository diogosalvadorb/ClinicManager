﻿namespace ClinicManager.Application.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(string login, string role);
    }
}
