﻿namespace Identity.Domain;

public class AuthenticationModel
{
    public string Token { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Message { get; set; }
    public bool IsAuthenticated { get; set; }
    public List<string> Roles { get; set; }
    public DateTime ExpiresOn { get; set; }
}
