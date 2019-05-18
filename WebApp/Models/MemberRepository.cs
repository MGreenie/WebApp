using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Member> FindMemberByEmail(string email)
        {
            return DbSet.Where(h => h.email.Equals(email));
        }
    }
}