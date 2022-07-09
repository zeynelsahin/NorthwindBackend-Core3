﻿using Core.DataAcccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserDal: EfEntityRepositoryBase<User,NorthwindContext>, IUserDal
{
    public async Task<List<OperationClaim>> GetClaimsAsync(User user)
    {
        await using var context = new NorthwindContext();
        var result = from operationClaim in context.OperationClaims
            join userOperationClaim in context.UserOperationClaims
                on operationClaim.Id equals userOperationClaim.OperationClaimId
            where userOperationClaim.UserId == user.Id
            select new OperationClaim {Id = operationClaim.Id, Name = operationClaim.Name};
        return result.ToList();
    }
}