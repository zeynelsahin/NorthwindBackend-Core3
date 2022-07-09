﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Abstract;

public interface IAuthService
{
    Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto,string password);
    Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto);
    Task<IResult> UserExists(string email);
    Task<IDataResult<AccessToken>> CreateAccessToken(User user);
    
}