﻿namespace HRMatrix.IdentityService.DTOs;

public class AuthResultDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}